# Bannerlord.GameMaster (BLGM) agent integration — design notes

**Audience:** engineers working on AIInfluence (or a sibling mod) who want an LLM-driven operator on top of [Bannerlord.GameMaster](https://github.com/SolWayward/Bannerlord.GameMaster) without pretending the language model is the game engine.

**Tone:** this document records *intent* and *constraints* agreed in design discussion. It is not a task list for a single PR.

---

## What we are actually building

BLGM is not a second simulation. It is a **large, documented console** over TaleWorlds’ campaign: commands follow `gm.<category>.<command>` with positional and `name:value` arguments, plus a **query** subsystem for finding heroes, clans, kingdoms, settlements, items, troops, and more. The player-facing wiki and the published developer API reference are the authoritative catalog; as of the wiki snapshot we used, the surface is on the order of **nine command families** and **~139 commands** ([wiki API reference](https://github.com/SolWayward/Bannerlord.GameMaster/wiki), [developer API docs](https://solwayward.github.io/Bannerlord.GameMaster/api/index)).

An “agent” in our sense is a loop: the model proposes **plans**, the game executes **effects**, and only **effects** may change save state. The model must never be the source of truth for whether a command worked.

---

## Hard constraints from Bannerlord

Campaign state is **not safe to mutate from arbitrary worker threads**. Anything that touches `CommandLineFunctionality` / BLGM execution belongs on the **game main thread**, scheduled in **small slices** if needed so a long script does not hitch the frame loop.

That does **not** mean blocking on the LLM. Network and inference stay asynchronous. When a response arrives, the host **enqueues** work; the simulation **consumes** it under a budget. The LLM can take a minute; the map should keep moving.

---

## “Observations” (plain language)

When we say **observations must not be authored by the model**, we mean something very concrete.

The model only ever produces **assistant** text. If the transcript contains a line that claims to be the **result of running a command**, and that line was **written by the model in the same breath** as its plan, the model can **confabulate** success or failure. The fix is to insert the next context item from **your runtime**: the string returned by BLGM (or your wrapper), optionally wrapped as a small JSON envelope (`source`, `stdout`, `stderr`, `error_code`) if that helps logging. **Provenance matters more than format.** In API terms this is the same slot as a **tool result** in OpenAI-style chat: the server attaches it; the model does not invent it.

Structured outputs govern **plans**; BLGM governs **effects**.

---

## Structured outputs vs console syntax

TaleWorlds’ console has picky rules: **single quotes** for multi-word tokens (double quotes are stripped), **named arguments** as `name:value` with **no spaces** around the colon, **comma-separated** culture lists without stray spaces, culture groups like `main_cultures`, and so on. These are spelled out in BLGM’s [command syntax guide](https://github.com/SolWayward/Bannerlord.GameMaster/wiki).

You can validate those rules in a **local preflight** and return deterministic error strings—and you should still enforce **policy** (allowlists, rate limits, scope checks) regardless of how perfect the JSON is.

The cleaner long-term approach is: the model emits a **structured plan** (command identifier, positional fields, named pairs, explicit “needs quoting” strings). **Your code** serializes that into the exact BLGM line. Then spacing and colon rules are **not** something the weights need to learn; they are **one serializer** you test once. Vendor “structured outputs” / schema-constrained decoding is how you keep the plan parseable; it does not replace server-side policy.

---

## The general program (six layers)

This is the architecture we converged on. It scales across the whole library without writing a short story per command.

**First — inject a structured world snapshot.** Your code derives this from `Campaign` (and related objects): player hero, clan id and tier, whether the clan has a kingdom, ruler vs vassal vs mercenary vs independent, relevant string ids, maybe a compact settlement or party summary when the task needs it. The model should not guess membership or authority; it should **read** the snapshot each turn or when state changes. Tooling stacks increasingly separate **LLM-visible context** from **local runtime state**; the snapshot is the bridge you choose to show.

**Second — route intent to a BLGM family using tags and state.** BLGM already organizes commands into families (hero, clan, kingdom, settlement, bandit, caravan, troop, item, query). Maintain a **machine index** of commands enriched with tags: primary entity type, preconditions (`requires_kingdom`, `requires_ruler`, settlement scope, etc.). Filter that index against the snapshot **before** suggesting lines. This generalizes the “clan vs kingdom” confusion: the same pattern applies whenever a verb belongs to settlement vs party vs hero.

**Third — enforce syntax and allowlists locally.** Even with a serializer, keep a gate: allowed prefixes (`gm.` only), max length, rate limits, and “this command is disabled for automation.” Log **schema validation failures** separately from **BLGM execution failures**; they are different bugs.

**Fourth — default to query and help before destructive mutates.** BLGM’s own docs describe a workflow: find entities, verify, modify, confirm. Running a command **without required arguments** is supposed to surface **help**—that should be standard operating procedure when arity is uncertain. This especially reduces bad kingdom- or ruler-scoped calls.

**Fifth — execute and append only runtime-returned text as the next context item.** After `CallFunction` (or equivalent), append what the engine actually returned. The model’s next turn must treat that block as ground truth.

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

Some kingdom-scoped commands may exist in the catalog while the **player’s character is not authorized** in fiction or in hidden game rules. Help-first and honest error text reduce but do not eliminate that. Accept residual edge cases until telemetry shows otherwise.

---

## References (external)

- BLGM repository and wiki: <https://github.com/SolWayward/Bannerlord.GameMaster>  
- BLGM developer API reference: <https://solwayward.github.io/Bannerlord.GameMaster/api/index>  
- OpenAI structured outputs (schema-constrained responses): <https://platform.openai.com/docs/guides/structured-outputs>  
- OpenAI Agents SDK — context separation (LLM vs local): <https://openai.github.io/openai-agents-python/context/>  
- Anthropic — engineering note on effective agents: <https://www.anthropic.com/engineering/building-effective-agents>  

---

*Document status: design agreement captured for implementation phases. Update when POC results change assumptions.*
