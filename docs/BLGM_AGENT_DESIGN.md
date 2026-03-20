# Bannerlord.GameMaster (BLGM) agent integration — design notes

**Audience:** engineers working on AIInfluence (or a sibling mod) who want an LLM-driven operator on top of [Bannerlord.GameMaster](https://github.com/SolWayward/Bannerlord.GameMaster) without pretending the language model is the game engine.

**Tone:** this document records *intent* and *constraints* agreed in design discussion. It is not a task list for a single PR.

---

## Two LLM completion paths (precision, not “the model”)

AIInfluence does **not** have one generic brain. It has **two named families of LLM calls**, and any BLGM design must say which path you mean (or both, with different rules).

**NPC Chat path** — Completions driven by **player↔NPC dialogue**: chat window, messenger-style prompts, conversation-scoped JSON, prompts keyed to a **specific hero** and their `NPCContext`. If this path is ever allowed to emit BLGM plans, the snapshot and allowlist must match **that character’s** situation (prisoner, clan, kingdom role), not a free-floating narrator.

**World Events path** — Completions driven by **campaign- and diplomacy-scale** work: dynamic events, kingdom/ruler statements, diplomatic analysis, and similar prompts built from **world aggregates** rather than a single interlocutor. The same serializer and observation channel may apply, but the **injected snapshot** is world-shaped; **policy** (which commands are legal from this path) may legitimately differ from NPC Chat.

In the rest of this document, **plan** means **structured output from whichever path is active** for that request. We avoid the phrase “the model” where it would blur these two.

---

## What we are actually building

BLGM is not a second simulation. It is a **large, documented console** over TaleWorlds’ campaign: commands follow `gm.<category>.<command>` with positional and `name:value` arguments, plus a **query** subsystem for finding heroes, clans, kingdoms, settlements, items, troops, and more. The player-facing wiki and the published developer API reference are the authoritative catalog; as of the wiki snapshot we used, the surface is on the order of **nine command families** and **~139 commands** ([wiki API reference](https://github.com/SolWayward/Bannerlord.GameMaster/wiki), [developer API docs](https://solwayward.github.io/Bannerlord.GameMaster/api/index)).

An “agent” loop here means: **the active completion path (NPC Chat or World Events) proposes a structured plan**, the host executes **effects** on the main thread, and only **effects** may change save state. Neither path’s raw assistant text may be treated as proof that a command ran or what it returned.

---

## Hard constraints from Bannerlord

Campaign state is **not safe to mutate from arbitrary worker threads**. Anything that touches `CommandLineFunctionality` / BLGM execution belongs on the **game main thread**, scheduled in **small slices** if needed so a long script does not hitch the frame loop.

That does **not** mean blocking on the LLM. Network and inference stay asynchronous. When a response arrives, the host **enqueues** work; the simulation **consumes** it under a budget. The LLM can take a minute; the map should keep moving.

---

## First-order implementation: threading and queue discipline

“Main thread” does **not** mean there is no concurrency. On Bannerlord, **UI, dialogue, and tick callbacks** can still interleave on that thread while **HTTP completions** usually finish on **thread-pool threads**. If the completion handler mutates shared queue state without a thread-safe queue (or equivalent), you race. **Practical rule:** use a **concurrent queue** for pending GM work; **produce** from the async completion path (or any worker); **consume** only from a **known drain site** that already runs each frame on the simulation/UI thread—e.g. **`SubModule.OnApplicationTick` → `AIInfluenceBehavior.Tick`**—not from arbitrary callbacks. Do **not** block the main thread waiting on the network; do **not** run unbounded `CallFunction` batches in a single drain pass if you care about frame time.

**Correlation:** each enqueued batch should carry an id so observations can be matched to the right session when multiple completions are in flight (chat vs world pipeline). Without that, ground-truth text can land on the wrong prompt.

---

## “Observations” (plain language)

When we say **observations must not be authored by the completion**, we mean something very concrete.

Whichever path ran—**NPC Chat** or **World Events**—only **assistant** completions come from the weights. If the transcript contains a line that claims to be the **result of running a command**, and that line was **written by the same completion** as its plan, the system can **confabulate** success or failure. The fix is to insert the next context item from **your runtime**: the string returned by BLGM (or your wrapper), optionally wrapped as a small JSON envelope (`source`, `stdout`, `stderr`, `error_code`) if that helps logging. **Provenance matters more than format.** In API terms this is the same slot as a **tool result** in OpenAI-style chat: the server attaches it; the completion does not invent it.

Structured outputs govern **plans** from the active path; BLGM governs **effects**.

---

## Structured outputs vs console syntax

TaleWorlds’ console has picky rules: **single quotes** for multi-word tokens (double quotes are stripped), **named arguments** as `name:value` with **no spaces** around the colon, **comma-separated** culture lists without stray spaces, culture groups like `main_cultures`, and so on. These are spelled out in BLGM’s [command syntax guide](https://github.com/SolWayward/Bannerlord.GameMaster/wiki).

You can validate those rules in a **local preflight** and return deterministic error strings—and you should still enforce **policy** (allowlists, rate limits, scope checks) regardless of how perfect the JSON is.

The cleaner long-term approach is: **the active completion path** emits a **structured plan** (command identifier, positional fields, named pairs, explicit “needs quoting” strings). **Your code** serializes that into the exact BLGM line. Then spacing and colon rules are **not** something the weights need to learn; they are **one serializer** you test once. Vendor “structured outputs” / schema-constrained decoding is how you keep the plan parseable; it does not replace server-side policy.

**Backend direction (implementation, not this doc’s POC scope):** the mod currently supports several AI backends; **schema guarantees differ by gateway**. The intended end state is to **standardize on OpenRouter** (or a single provider that exposes reliable JSON Schema / tool-style constraints) for any code path that emits BLGM plans. Trimming legacy backends for those paths belongs in the same bucket as other future implementation work (cf. MissionGM)—not a requirement to solve every adapter on day one.

---

## The general program (six layers)

This is the architecture we converged on. It scales across the whole library without writing a short story per command.

**First — inject a structured snapshot.** Your code derives this from `Campaign` (and related objects). For **NPC Chat**, bias the snapshot toward the **current NPC** (and player): their hero id, clan, kingdom role, prisoner state, party. For **World Events**, bias toward **factions, events, and aggregates** the prompt already uses. In both cases the completion must not guess membership or authority; it **reads** the snapshot each request or when state changes. Tooling stacks increasingly separate **LLM-visible context** from **local runtime state**; the snapshot is the bridge you choose to show.

**Second — route intent using a full index plus a hazard index.** BLGM organizes commands into families (hero, clan, kingdom, settlement, bandit, caravan, troop, item, query). Maintain a **machine index** of all commands with tags (primary entity, rough scope). **Separately**, maintain a **curated hazard index**: commands that are often wrong in practice (kingdom policy, ruler-only actions, ownership transfers, diplomacy, mass spawn, destroy/remove). Those entries carry **explicit preconditions** derived from `Hero` / `Clan` / `Kingdom` / settlement APIs—not prose from the wiki. The prompt (or tool text) should steer the completion to **consult the hazard index first** when the task touches those areas; the serializer still validates every line regardless.

**Third — enforce syntax and allowlists locally.** Even with a serializer, keep a gate: allowed prefixes (`gm.` only), max length, rate limits, and “this command is disabled for automation.” Log **schema validation failures** separately from **BLGM execution failures**; they are different bugs.

**Fourth — default to query and help before destructive mutates.** BLGM’s own docs describe a workflow: find entities, verify, modify, confirm. Running a command **without required arguments** is supposed to surface **help**—that should be standard operating procedure when arity is uncertain. We accept **mod-stack risk**: a badly behaved command could theoretically mutate on a “help” probe. Mitigation is **operational**, not formal verification: **log every GM interaction end-to-end** (proposed structured plan, serialized line, raw return string from `CallFunction`, timestamp, completion path id) so a bad probe is diagnosable from `mod_log` or a dedicated GM log file.

**Fifth — execute and append only runtime-returned text as the next context item.** After `CallFunction` (or equivalent), append what the engine actually returned. The **next** call on the same path (or the next message in the thread) must treat that block as ground truth—not as optional flavor text.

**Sixth — let structured outputs govern the plan while BLGM governs the effect.** The schema should encode **control flow** (`continue`, `stop`, `probe_help`, `query_only`, `mutate`) and **targets** (ids, family), not English improvisation for execution.

---

## Identity and disambiguation

BLGM accepts partial names and string ids; **ambiguous matches can drive interactive UI** in the normal game console. For an unattended agent, that is dangerous. The operational rule remains: **resolve ids through `gm.query.*` (or equivalent)** until you hold a unique handle, **then** mutate.

**Implementation note (not spec):** a small Harmony patch or alternate execution path that **never opens selection UI** and instead returns a textual “ambiguous: N matches” result would align console behavior with automation. Treat this as follow-up engineering once the loop is proven.

---

## RAG

Retrieval over the full wiki is **useful after a POC** for rare flags and examples. It should not be the primary router. The POC should stand on: **snapshot + tagged command index + structured plan + serializer + real observations**.

---

## Accepted risks (for now)

Some kingdom-scoped commands may exist in the catalog while the **player’s character is not authorized** in fiction or in hidden game rules. Help-first, hazard-index preconditions, and honest error text reduce but do not eliminate that. Accept residual edge cases until telemetry shows otherwise.

**Product choice:** we are **not** specifying a separate security / capability matrix (tiers, per-day caps, audit hashes) for an initial version; treat GM as a trusted mod feature like BLGM itself.

**Automated testing:** a full serializer golden suite and mock-`CallFunction` integration grid is **not** a gate for the first delivery; reliance is on **logging**, manual smoke tests, and incremental hardening. Revisit if the surface stabilizes.

---

## Out of scope for now (explicit deferrals)

**MissionGM** — A separate idea worth exploring later: an operator that runs **during** or **against** mission state (agents, equipment, spawn, scene logic) with the same “plan → execute → observation” discipline, but using **mission-native** APIs rather than campaign console commands. That is **not** part of the current BLGM-on-campaign design; conflating the two early guarantees the wrong abstraction. Settlement-combat LLM completions today are narrative/gameplay-shaped; any world fix they imply should stay **queued until campaign is authoritative again** until a real MissionGM exists.

**Death history (`history_gen`)** and similar **pure prose** paths do not get GM agent access.

**Campaign lifecycle and pending queues** — Behavior when `Campaign.Current` is null, during **save load**, at **mission boundaries**, or on teardown (flush vs cancel vs persist queued GM work) is **out of scope for the initial implementation**. **Future TODO:** define a single policy (e.g. cancel all pending on load; gate `CallFunction` on “campaign ready”; optionally persist queue with save version) before shipping wide.

---

## References (external)

- BLGM repository and wiki: <https://github.com/SolWayward/Bannerlord.GameMaster>  
- BLGM developer API reference: <https://solwayward.github.io/Bannerlord.GameMaster/api/index>  
- OpenAI structured outputs (schema-constrained responses): <https://platform.openai.com/docs/guides/structured-outputs>  
- OpenAI Agents SDK — context separation (LLM vs local): <https://openai.github.io/openai-agents-python/context/>  
- Anthropic — engineering note on effective agents: <https://www.anthropic.com/engineering/building-effective-agents>  

---

*Document status: design agreement captured for implementation phases. Update when POC results change assumptions.*

---

## POC progress (implementation)

**Slice 1 (done in repo):** MCM → Debug & Fixes → **GM POC (query kingdoms)** enqueues a single read-only `gm.query.kingdom` on `GameMasterPocQueue`; `AIInfluenceBehavior.Tick` drains **one** action per application tick before the lip-sync main-thread queue. Results are **log-only** (`[GM_POC] observation …`). Requires **Bannerlord.GameMaster** loaded. No LLM.

**Next slices (planned):** multi-line budget; correlation id in log; JSON plan from a debug OpenRouter call; serializer; then path-specific wiring.
