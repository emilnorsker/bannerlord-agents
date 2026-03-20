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

The cleaner long-term approach is: **the active completion path** emits a **structured plan** (command identifier, positional fields, named pairs, explicit “needs quoting” strings). **Your code** serializes that into the exact BLGM line. Then spacing and colon rules are **not** something the weights need to learn; they are **one serializer** you test once. On **OpenRouter**, use **structured outputs** (the API’s `response_format`, including **`json_schema`** / provider-specific **grammars** where supported) so the model cannot emit arbitrary keys; host validation remains mandatory. **Implementation direction:** **generate and ship JSON Schemas** aligned to BLGM command **families** or **individual commands** (args shape, enums, optional `story_intent`)—built from the pinned command index + serializer rules, versioned with the mod. At request time, select the schema that matches the intended family or command; fallback to a **base plan schema** plus host-side narrowing. This is not “one giant schema for all 139 commands” on day one—start with **query** and **one mutate family**, expand as the story tools mature.

**Backend direction — OpenRouter only for GM work:** all **new** BLGM agent features (plans, observation injection, strict schemas, snapshots tuned for automation) are specified and implemented **only against OpenRouter**. Other AI backends remain for **non-GM** dialogue and analysis until intentionally retired; they must **not** receive new GM-specific prompt plumbing or plan execution paths. This keeps one gateway contract, one set of `response_format` behaviors, and one place to debug.

**Backend direction (legacy note):** the mod still ships multiple backends for general chat; **schema guarantees differ by gateway**. For **GM plans**, treat **OpenRouter as the sole supported provider** going forward.

---

## The general program (six layers)

This is the architecture we converged on. It scales across the whole library without writing a short story per command.

**First — inject a structured snapshot.** Your code derives this from `Campaign` (and related objects). For **NPC Chat**, bias the snapshot toward the **current NPC** (and player): their hero id, clan, kingdom role, prisoner state, party. **NPC-only (important):** when **this NPC** is the one “driving” GM queries (dialogue path), add **API-backed** social facts vs the player—relation, trust, influence where available—**bounded to a few lines**. These exist so the model knows **who is asking** and **what leverage they have in fiction**; they are **not** required for pure execution. For **World Events** (and diplomacy-scale completions), **do not** inject that NPC social appendix: bias instead toward **factions, wars, active events, and aggregates** the prompt already uses—**different lens, no duplicate “friendship stats”** unless the event explicitly centers a named hero. In both cases the completion must not guess membership or authority; it **reads** the snapshot each request or when state changes.

**Second — route intent using a full index plus a hazard index.** BLGM organizes commands into families (hero, clan, kingdom, settlement, bandit, caravan, troop, item, query). Maintain a **machine index** of all commands with tags (primary entity, rough scope). **Separately**, maintain a **curated hazard index**: commands that are often wrong in practice (kingdom policy, ruler-only actions, ownership transfers, diplomacy, mass spawn, destroy/remove). Those entries carry **explicit preconditions** derived from `Hero` / `Clan` / `Kingdom` / settlement APIs—not prose from the wiki. The prompt (or tool text) should steer the completion to **consult the hazard index first** when the task touches those areas; the serializer still validates every line regardless.

**Third — enforce syntax and allowlists locally.** Even with a serializer, keep a gate: allowed prefixes (`gm.` only), max length, rate limits, and “this command is disabled for automation.” Log **schema validation failures** separately from **BLGM execution failures**; they are different bugs.

**Fourth — default to query and help before destructive mutates.** BLGM’s own docs describe a workflow: find entities, verify, modify, confirm. Running a command **without required arguments** is supposed to surface **help**—that should be standard operating procedure when arity is uncertain. We accept **mod-stack risk**: a badly behaved command could theoretically mutate on a “help” probe. Mitigation is **operational**, not formal verification: **log every GM interaction end-to-end** (proposed structured plan, serialized line, raw return string from `CallFunction`, timestamp, completion path id) so a bad probe is diagnosable from `mod_log` or a dedicated GM log file.

**Fifth — execute and append only runtime-returned text as the next context item.** After `CallFunction` (or equivalent), append what the engine actually returned. The **next** call on the same path (or the next message in the thread) must treat that block as ground truth—not as optional flavor text.

**Sixth — let structured outputs govern the plan while BLGM governs the effect.** The schema should encode **control flow** (`continue`, `stop`, `probe_help`, `query_only`, `mutate`) and **targets** (ids, family), not English improvisation for execution.

**Narrative intent — GM as story engine, not a dumb pipe:** BLGM execution is **not** an end in itself. Every automated plan should carry **why** it exists for the player’s story: a short, schema-backed **`story_intent`** (or equivalent) that states the **dramatic purpose** (e.g. “create pressure on the player’s clan,” “surface information this NPC could not know in dialogue alone,” “resolve a hook from the last event”). The host **logs** intent with the plan and observation; the **next** completion can treat intent + observation together so the arc stays coherent. **World Events** paths especially should use intent to tie console effects to **emergent narrative** (rumors, stakes, fallout), not only state changes. **NPC Chat** paths tie intent to **this character’s** goals and social reality. Pure “button pusher” behavior without intent is considered a **design failure** for this mod’s GM integration.

**Schema validation vs BLGM execution (two different failures):** **Schema validation** means “did we get parseable JSON with the fields we expect?” For NPC Chat, that is the usual **`AIResponse` JSON** (fields like `response`, `decision`, `blgm_plan`, etc.) after `JsonCleaner` and `JsonConvert.DeserializeObject<AIResponse>` — there is no file named `chat.json`; it is the **same structured dialogue payload** the mod already uses. **BLGM execution failure** means “the serialized line was rejected or `CommandLineFunctionality.CallFunction` returned an error string or threw.” Log and surface these **separately**: a bad JSON shape is a **prompt/schema bug**; a bad command is a **game policy or BLGM semantics bug**.

**NPC authority vs extra social context (NPC Chat path only):** “This NPC’s authority” (clan/kingdom/ruler alignment) is enough for **permission fiction**. Optional **hard rules** when **this NPC** is querying the system (dialogue / initiative / messenger—not World Events): (1) **bounded** — never more than a few lines of GM-specific context; (2) **facts only** — relation/trust/influence from **campaign APIs** for **this** `Hero` vs **MainHero**; (3) **no** social appendix on **World Events** completions—use world aggregates there instead. **Skill checks:** high-impact mutates may require a **successful opposed skill check** before enqueue; queries/help usually skip (see slice 25).

**Structured grammars (OpenRouter) for GM commands:** Prefer OpenRouter’s **`response_format`** with **`json_schema`** (and provider “grammar” features where available) so each **family** or **command** has a **generated** schema: allowed `gm_command` values, `args` item shapes, `intent`, `story_intent`, `probe_help_first`. **Generate** these artifacts in the repo (from the tagged command index + BLGM version pin) so drift is visible in review. Narrow schemas beat one loose `json_object` for reliability; the host serializer remains canonical.

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

## Module dependency

`SubModule.xml` lists **Bannerlord.GameMaster** in `DependedModules` with `LoadBeforeThis` so `gm.*` commands exist before AIInfluence runs. Players must install [Bannerlord.GameMaster](https://github.com/SolWayward/Bannerlord.GameMaster) alongside this mod.

**Compile-time:** `AIInfluence.csproj` references `ref/Bannerlord.GameMaster-v1.3.14.11/Bannerlord.GameMaster.dll` (from release **v1.3.14.11**) with `<Private>false</Private>` so the runtime DLL still comes from the player’s **Modules** folder, not a duplicate copy in AIInfluence output.

---

## References (external)

- BLGM repository and wiki: <https://github.com/SolWayward/Bannerlord.GameMaster>  
- BLGM developer API reference: <https://solwayward.github.io/Bannerlord.GameMaster/api/index>  
- OpenAI structured outputs (schema-constrained responses; OpenRouter-compatible `response_format`): <https://platform.openai.com/docs/guides/structured-outputs>  
- OpenRouter — API / models (check current docs for `response_format` + structured outputs): <https://openrouter.ai/docs>  
- OpenAI Agents SDK — context separation (LLM vs local): <https://openai.github.io/openai-agents-python/context/>  
- Anthropic — engineering note on effective agents: <https://www.anthropic.com/engineering/building-effective-agents>  

---

*Document status: design agreement captured for implementation phases. Update when POC results change assumptions.*

---

## Implementation slices (POC → full)

Ordered steps. Later slices assume earlier ones unless noted. **Slices 1–8** are the original POC queue/serializer/diagnostics; **9–17** add path wiring, hazard/audit, OpenRouter gating, and optional strict schema for the POC OpenRouter button (see table).

| # | Slice | Outcome |
|---|--------|--------|
| **1** | **Fixed read-only probe + queue + drain** | `ConcurrentQueue`, drain **one** item per application tick in `AIInfluenceBehavior.Tick` (before lip-sync queue). MCM button enqueues `gm.query.kingdom`. **Log-only** observations (`[GM_POC]`). No LLM. **Status: done.** |
| **2** | **Correlation id** | Every enqueue receives a **Guid**; enqueue, each serialized line, and each `CallFunction` return log under that id so parallel completions can be untangled later. **Status: done.** |
| **3** | **Drain budget** | MCM or const: max **N** queue actions per tick (default 1); prevents multi-line jobs from stalling one frame once slices add batches. **Status: done** (MCM Debug: **GM POC: max queue drains per tick**, 1–50). |
| **4** | **Async producer stress** | Enqueue from `Task.Run` (or a stub “LLM completed” callback on a thread-pool thread) to prove the queue + logging behave under the same pattern real HTTP uses. **Status: done** — MCM **GM POC async enqueue**. |
| **5** | **Batch enqueue lock** | When one plan maps to **multiple** lines, `lock` while enqueueing the whole batch so two concurrent completions cannot interleave lines. **Status: done** — MCM **GM POC batch ×3** (`EnqueueBatchReadOnlyKingdomProbesLocked`). |
| **6** | **Serializer v1** | C# DTO / record (positional + named-arg fields + “needs single quotes”) → one exact BLGM string. Validate locally before `CallFunction`. **Status: done** — `GameMasterCommandSerializer` (`SerializeLine`, `TryParseOpenRouterJson`). |
| **7** | **Debug OpenRouter hop** | Dev-only: one completion (OpenRouter) with a frozen system prompt returning **JSON** matching the DTO; parse → serialize → enqueue → observe in log. Proves LLM → game loop with no NPC Chat UI yet. **Status: done** — MCM **GM POC OpenRouter plan**. |
| **8** | **Observation visibility** | Surface last observation in-game (MCM readonly text, debug overlay, or message) so testers see the loop without `mod_log` only. **Status: done** — `GameMasterPocDiagnostics` + MCM **GM POC last observation**. |
| **9** | **NPC Chat path (opt-in)** | **Status: done** — MCM **NPC Chat: allow blgm_plan**; prompt appendix with NPC/player snapshot; `AIResponse.blgm_plan`; enqueue after dialogue + chat-window + initiative/messenger/letter paths; correlation = `NPCContext.StringId`. |
| **10** | **World Events path (opt-in)** | **Status: done** — MCM toggles for **World Events** and **Diplomacy** + **query-only** flags; prompt appendix injected in `SendAIRequestWithBackend` for dynamic/diplomatic request types; `blgm_plan` on `DynamicEventsResponse`, `DiplomaticStatementResponse`, `PlayerStatementAnalysisResponse`. |
| **11** | **Hazard index v1** | **Status: done (v1 subset)** — `GameMasterHazardIndex`: `gm.kingdom.*` requires player kingdom + ruler; blocks `gm.troop.*` / `gm.bandit.*` for automation; MCM **Enforce hazard preconditions**. |
| **12** | **Full tagged command index** | **Status: partial** — `GameMasterTaggedCommandIndex.BuildPromptAppendix()` documents families/tags in prompts; full ~139-command generated table still future work. |
| **13** | **Dedicated GM audit log** | **Status: done** — MCM **GM audit log** → `logs/gm_audit.log` (tab-separated); enqueue + complete rows when audit enabled. |
| **14** | **Help-before-mutate workflow** | **Status: done** — `BlgmPlanDto`: `intent` + `probe_help_first`; `probe_help` intent → no-arg line; `probe_help_first` on non-query → help line then primary line. |
| **15** | **No UI disambiguation (stub)** | **Status: stub only** — no-op Harmony patch documents intent. **Real implementation: slice 26.** |
| **16** | **OpenRouter-only for GM plans** | **Status: done** — `GameMasterPlanExecutor` ignores `blgm_plan` unless backend name is **OpenRouter** (per path: main AI, Dynamic Events AI, or Diplomacy AI as applicable). |
| **17** | **Schema-constrained plans** | **Status: partial** — see **“When to use json_schema vs json_object”** below. |
| **18** | **RAG (optional)** | After the loop is stable: retrieve wiki paragraphs for rare flags; never replace hazard index + serializer. |
| **19** | **Campaign lifecycle** | Define policy for pending queue on save load, mission transition, teardown (cancel, flush, or persist with version). Previously deferred. |
| **20** | **MissionGM** | Separate operator for mission-time APIs; do not overload campaign `gm.*` queue. |
| **21** | **Observation loop (tool results)** | After each `CallFunction`, persist last **N** observations per **correlation** (NPC `StringId`, event/kingdom id, etc.); **inject** that block into the **next** OpenRouter completion for that path so the model sees ground truth, not only logs. |
| **22** | **Host allowlist policy (layer 3)** | Enforce before enqueue: **`gm.` prefix only**, **max serialized line length**, **rate limits** (e.g. max `blgm_plan` executions per in-game day or per real-time window), optional **max queue depth**; log **policy rejections** with a dedicated tag vs schema vs BLGM runtime. |
| **23** | **Hazard index v2** | Replace blanket `gm.kingdom.*` / `gm.troop.*` / `gm.bandit.*` rules with **per-command or per-family entries** where possible; use **`Hero` (interlocutor + MainHero)** for NPC-path preconditions; remove or implement the unused interlocutor parameter; align with wiki/API semantics so safe subcommands are not rejected blindly. |
| **24** | **NPC GM appendix v2 (social stats)** | **NPC Chat path only** — optional bounded lines: relation / trust / influence (API-backed) for NPC ↔ player when `blgm_plan` is enabled; **not** used for World Events / world-shaped prompts. OpenRouter-only. |
| **25** | **Skill-check gates for mutates (optional)** | Before selected **mutate** lines, require passing the mod’s **opposed skill check** (configurable per hazard tier); queries and read-only plans skip checks unless explicitly enabled. |
| **26** | **No UI disambiguation (real implementation)** | **Future** — replace the deferred Harmony stub: ambiguous console entity resolution returns **text** to the agent instead of opening an in-game picker (engine/BLGM hook TBD). **Does not replace** slice **15** row history; slice **15** remains the POC placeholder until this lands. |
| **27** | **Generated OpenRouter grammars (per GM command / family)** | **Build-time or CI** generation of **JSON Schema** (structured grammars) from the tagged command index + BLGM version pin: one schema per **family** first, then per **command** as needed; ship under e.g. `schemas/gm/`; runtime selects `response_format` / schema **id** by intended command family. Keeps completions aligned with serializer rules. |
| **28** | **`story_intent` in plan schema + pipeline** | Extend the plan DTO with **`story_intent`** (short string, schema-required or optional by path); log with plan + observation; feed into observation loop so the **next** completion keeps narrative purpose visible. World Events especially use this to tie effects to **story**, not only state. |

### When to use `json_schema` vs `json_object` (OpenRouter)

- **`json_object`** (what **`GetOpenRouterResponse`** uses for **non-streaming** NPC chat today): tells the provider “return a single JSON object.” It does **not** pin every field of `AIResponse`; the model can omit or add keys subject to your cleaner. Use for **full dialogue JSON** when you want flexibility and already validate in C#.

- **`json_schema` with `strict: true`** (what the **MCM “GM POC OpenRouter plan”** path can use): constrains the **small standalone object** `{ gm_command, args, intent, probe_help_first }` to an exact shape. Use when the **only** purpose of the request is to emit a **plan DTO** (dev button, or a future **plan-only** micro-call).

- **Per-command / per-family grammars (slice 27):** the end state is **generated** schemas—**different** JSON Schemas for **query** vs **item** vs **kingdom** plans—selected before the request so the model cannot emit illegal `gm_command` tokens for that turn. Overlaps with slice **17**; slice **27** is the **pipeline** to produce and version those files.

- **Full dialogue + strict schema for the entire `AIResponse`:** only practical if you maintain a **large** JSON Schema and accept provider limits; otherwise keep **`blgm_plan` as an optional nested object** validated in the host and use **`json_object`** for the outer message, or split **two OpenRouter calls** (dialogue vs plan) — product choice.

**Review:** After slice **10**, pause for playtesting; slices **11–17** are where reliability and ops mature; **18–20** are scale and future scope; **21–28** extend the loop, policy, UX hardening, **story intent**, and **generated grammars** (**OpenRouter-only** for new GM slices unless explicitly excepted).
