# ElevenLabs (and external TTS) for NPC Chat — design notes

**Audience:** engineers implementing or reviewing TTS for **AIInfluence**’s NPC chat UI (and optionally sibling surfaces), without assuming the audio provider is the game engine or the LLM.

**Tone:** this document records *intent* and *constraints* from design discussion. It is **not** a task list for a single PR. **No implementation in this repo is implied complete** until slices below are explicitly marked done.

---

## Two TTS consumption paths (precision, not “TTS”)

The mod does **not** have one generic “speak this string” pipeline. Any design must name which path applies.

**NPC Chat path (this document’s focus)** — Audio tied to **player↔NPC chat window** output: streamed or final `response` text from the **NPC Chat** LLM completion, typewriter-visible text, and optional **player-typed** line. Snapshots are **conversation-scoped** (current `Hero`, current NPC, and the **native voice attributes** those entities use for lookup). If ElevenLabs is used here, API keys and rate limits are **mod** policy; **`voice_id`** values come from the **lookup table**, not from the LLM.

**Other TTS paths (out of scope unless explicitly bridged)** — Examples: **NPC initiative** (“NPC ready”) flows, **mission conversation** audio, or any future surface. They may use **different** providers, **optional lip-sync** in a future slice, and **different** threading assumptions. **Do not** silently merge those paths with NPC Chat without a written decision in this doc’s “Bridging” section.

In the rest of this document, **utterance** means **one speakable unit** our system sends to a provider for the **NPC Chat path** only.

---

## What we are actually building

We are **not** simulating dialogue. We are adding a **bounded audio channel**: text that the player already sees (or will see under defined rules) is converted to **PCM/OGG (or provider-native)** and played via the same **main-thread** playback hook the mod already uses (`OnConversationPlay` or successor), with **no requirement** for third-party lip-sync tooling on the **new chat UI** path unless a future slice explicitly adds it.

The **LLM** produces **text** (and any JSON the chat feature already uses). The **TTS provider** produces **audio**. **Our system** (mod code + data) decides **when** a clip is requested, **how** `voice_id` is resolved (see **Voice resolution**), and **when** playback starts. The model does **not** output ElevenLabs `voice_id` strings.

---

## Hard constraints from Bannerlord + this mod

1. **Campaign / UI mutation** (including starting sound playback that touches `CampaignMission` or Gauntlet-bound state) must follow the same **main-thread marshaling** pattern as the rest of the mod: enqueue onto **`MainThreadDispatcher.Queue`** (see `AIClient` streaming, `NpcChatWindowVM`, `AIInfluenceBehavior` tick dequeue). **Do not** invoke conversation/UI/audio entry points from arbitrary thread-pool threads without that queue (or an equivalent documented hook).

2. **Network** (ElevenLabs HTTP/WebSocket) stays **async** on worker threads. **Never** block the main simulation thread waiting on `HttpClient`.

3. **New chat UI path:** **Lip-sync** is **not** a goal for the initial NPC Chat ElevenLabs slice. Playback should be **audio-first** (skip body/lip-sync animation hooks unless a future slice wires them). Re-enabling lip-sync is a **separate slice** with its own performance and UX acceptance.

4. **Errors must not be swallowed** in a way that hides provider or serialization failures from logs; mod log should record HTTP status, truncated body, and correlation context (e.g. NPC id, chunk index).

---

## Voice resolution (Bannerlord attributes → ElevenLabs)

ElevenLabs **`voice_id`** is **never** chosen by the LLM. **Our system** resolves it with a **simple lookup**: **native Bannerlord voice-related attributes** (for the relevant entity and line **role**) → one of a **pregenerated list** of ElevenLabs `voice_id` values shipped in mod data (e.g. a JSON table under `ModuleData`).

| Utterance **role** | Source text | How `voice_id` is chosen |
|--------------------|-------------|---------------------------|
| **Player** | The string the player submitted in the chat input | Lookup from the **Hero**’s native voice attributes (same keying as below). |
| **Narrator** | Segments in `*…*` (stage direction / emote) | Lookup using a **dedicated narrator profile** (fixed keys in the same table), so emotes are not read in the NPC’s diegetic voice. |
| **NPC** | Ordinary dialogue outside `*…*` | Lookup from the **current conversation NPC**’s native voice attributes. |

**Lookup table:** rows are **pregenerated** by us (curated ElevenLabs voices); columns/keys are whatever attribute tuple the mod standardizes on (culture, gender, pitch/timbre classes, etc.—whatever Bannerlord exposes and we decide to key). **Changing** those native aspects **changes** the resolved ElevenLabs voice when the table has a matching row.

**Fallback:** if no row matches, use a documented **default** `voice_id` and **log** with enough context (attributes used, role, chunk index) so the table can be extended. **Do not** silently pick a random voice.

**Chunk ↔ voice binding:** For each **committed chunk**, `[start, end)` indices come from **our** parser on the raw `response` string. The **`voice_id`** for that chunk is **`ResolveVoiceId(role, entityContext)`** where `entityContext` is Hero, NPC, or narrator profile—**no** parallel model-owned segment list; one string, one parser, one resolution path per chunk.

---

## Two text timelines (must not be confused)

**Internal stream** — The growing `response` field (or whole JSON buffer) as returned by **OpenRouter streaming** (or another backend). This can run **tens of characters ahead** of what the player reads.

**External typewriter** — The substring actually shown in the chat bubble, advanced on a **timer** (`ChatStreamCharacterInterval` or instant fallback).

**External audio** — PCM/OGG playback the player hears.

**Design rule:** prefetch and **committed chunk** boundaries are derived from the **internal** stream. **Visibility** (typewriter) must **not** reveal characters **past the end of committed text** while the model is still inside an **uncommitted** tail (e.g. mid-sentence without a closing boundary). **Playback** for chunk *N* starts when the **first character** of chunk *N* is **about to be shown** (immediately before reveal). **Chunk *N+1*** must not begin displaying until **every character** of chunk *N* has been shown (strict; no skipping). **Per-chunk cadence:** time to reveal all characters of chunk *N* should match **measured audio duration** *T_audio(N)* for that chunk (see implementation slices).

---

## Committed chunks (normative rules)

Chunking is **deterministic mod logic** on the **plain text** `response` string, not model output.

1. **Emote / narrator segment:** A pair of asterisks `*…*` with a **closing** `*` commits one **narrator-role** utterance. Inner text (trimmed) is sent to TTS with the `voice_id` from **Voice resolution** for **narrator** (lookup narrator profile). Indices `[start, end)` in the raw `response` string are **stable** for alignment with the typewriter.

2. **NPC speech segment:** Text outside `*…*` uses **NPC** role resolution. While the LLM stream is **not** finished, only **complete sentences** commit as separate utterances, where “complete” is defined as ending with `.` `!` or `?` followed by end-of-string or whitespace (same rule family as today’s parser; edge cases like `Mr.` belong in a **hazard list** slice).

3. **Final flush:** When the LLM signals **end of stream**, any **remaining** speech tail (even without terminal punctuation) commits as **one** final NPC utterance.

4. **No committed chunk** may **shrink** or **change** inner text without invalidating prefetch from that chunk index forward (see **Invalidation** below).

---

## Prefetch

When a **new** committed chunk appears (or an existing committed chunk’s **text or span** changes), our system **starts** a provider request **asynchronously** for that utterance. Multiple chunks may prefetch **in parallel** subject to:

- **Rate limits** (provider + fair use),
- **Cancellation** when the user sends a new message or leaves the chat,
- **Generation id** (`_gen` or equivalent): completions from stale generations must **not** write into current **prepared-audio** slots for the active chat session (whatever structure the implementation uses; name is illustrative).

**Invalidation:** If chunk *i* changes, cancel or ignore in-flight work for indices `>= i`, clear prepared audio slots `>= i`, and re-queue prefetch.

---

## Typewriter gating

Let `committed_end` be the exclusive end index in the raw `response` string of the **last committed** character. While `!llm_done`, `visible_length` must satisfy `visible_length <= committed_end` (and `<= current_response_length`). The typewriter pump **stalls** at `committed_end` until either:

- a new partial **extends** committed text (increasing `committed_end`), or  
- `llm_done` (then `committed_end` covers the final tail).

When ElevenLabs is enabled and the first character of chunk *k* would be revealed, if audio for *k* is **not** ready, the typewriter **waits** (same timer reschedules; no busy-loop on main thread).

**Duration matching:** while revealing characters **inside** chunk *k*, effective per-character timing should target **total reveal time ≈ *T_audio(k)*** (measured from the prepared clip). Stall rules still apply if audio was not ready at chunk start.

---

## Provider surface (ElevenLabs)

Authoritative docs: [ElevenLabs API](https://elevenlabs.io/docs/api-reference/text-to-speech/stream), [streaming guide](https://elevenlabs.io/docs/eleven-api/guides/how-to/text-to-speech/streaming), [WebSocket](https://elevenlabs.io/docs/api-reference/websocket).

**HTTP `POST …/text-to-speech/{voice_id}/stream`** — One **complete** utterance string per request; response is streamed bytes (e.g. PCM with `output_format` query param). Fits **one utterance = one request**; **parallel** requests per chunk.

**WebSocket `stream-input`** — Incremental text into **one** generation per connection; typically **one voice per socket**. Using it for **alternating** narrator/NPC requires **multiple connections** or a **hybrid** (HTTP narrator, WS NPC, etc.). Any choice must be recorded in a slice.

**This spec does not mandate** HTTP vs WebSocket; it mandates **observable behavior** (chunking, prefetch, gating, attribute-based voice resolution).

---

## Configuration philosophy (agree before coding)

**Voice table:** the **attribute → `voice_id`** map lives in **mod data** (JSON or similar), not in the LLM. **Secrets:** API key in MCM and/or env. **Model / output format** for ElevenLabs can be constants or MCM—document per slice.

Options (pick in slice 1):

- **MCM-heavy:** API key plus model/output format in MCM; large table still in `ModuleData`.
- **MCM-minimal:** API key (or env) only; model/format and **voice lookup file** in `ModuleData` — edit file to change mappings.
- **Hybrid:** secrets in MCM; **full** lookup table in `ModuleData` keyed by native attributes.

Document the **chosen** approach in the slice table; do not mix styles without updating this doc.

---

## Observations and logging

When a clip **fails** (HTTP 4xx/5xx, empty body, invalid PCM), the next **observation** for debugging is a **log line** with: npc string id, chunk index, role (player/narrator/NPC), resolved **`voice_id`** (or “fallback” + attributes used), utterance length, HTTP status or exception message. **Do not** pretend playback succeeded.

---

## Explicitly out of scope (initial delivery)

- **Lip-sync** for the NPC Chat ElevenLabs path (audio-only first).
- **Synching** NPC Chat TTS with **other** mod audio surfaces (e.g. initiative / mission) in one unified queue (unless a slice explicitly defines bridging).
- **Per-token** alignment between LLM tokenizer and TTS (chunks are **string/sentence**-based).
- **MissionGM** or **non-chat** surfaces.
- **Automatic** voice cloning from Bannerlord native assets.

---

## Accepted risks

- **Estimated** audio duration vs **true** playback end is **not** measured by the engine in current hooks; if a future slice gates on “audio finished,” it needs a **real** completion signal or acceptable drift.
- **Provider** outages mid-stream: visible text may **stall** at chunk boundary; UX copy or timeout policy is product choice.
- **Ambiguous punctuation** (`3.14`, `Mr. Smith`) may split sentences wrong until a **hazard** list or smarter parser lands.

---

## Implementation slices (ordered)

Later slices assume earlier unless noted. **None are “done”** until explicitly checked in after implementation.

| # | Slice | Outcome |
|---|--------|--------|
| **1** | **Config + secret** | Decide MCM vs constants; store API key safely; document in mod hint text. |
| **1b** | **Voice lookup table** | `ModuleData` JSON (or equivalent): native attribute keys → ElevenLabs `voice_id`; narrator profile row(s); load/validate at startup; used by `ResolveVoiceId`. |
| **2** | **HTTP client minimal** | One method: `voice_id`, `text`, `model_id`, `output_format` → `byte[]` PCM on thread pool; structured errors logged. |
| **3** | **PCM → playable file** | Reuse or add **one** small path: PCM → playable asset, **audio-first** playback, enqueue **playback start** on the main thread via **`MainThreadDispatcher.Queue`** (same pattern as existing UI callbacks). |
| **4** | **Chunk parser unit** | Pure function: `(string partial, bool llm_done) → List<Chunk>` with rules in **Committed chunks**; each chunk carries **role** for voice resolution; golden tests or fixed strings in dev menu. |
| **5** | **Prefetch + generation id** | On chunk list change, parallel fetch; stale generation discarded. |
| **6** | **Typewriter cap** | `visible_length` bounded by `committed_end` until `llm_done`; pump schedules retries when stalled. |
| **6b** | **Duration-matched cadence** | Per chunk, measure *T_audio* from decoded PCM/OGG; set reveal interval so chunk text displays over ~*T_audio* (handle edge cases). |
| **7** | **Play on first char about to show** | When `visible_index == chunk.start`, require prepared audio or stall; start playback then; call play once per chunk. |
| **8** | **OpenRouter streaming integration** | Wire partial callback → parser → prefetch; final `llm_done` flush. |
| **9** | **Non-streaming fallback** | Full reply at once: same parser with `llm_done=true`; either same typewriter cap or sequential play-only mode (document choice). |
| **10** | **Player line optional TTS** | On send, optional utterance using **player** role + Hero attribute lookup; cancel on new turn. |
| **11** | **WebSocket evaluation (optional)** | Spike: single-voice WS vs parallel HTTP for latency; decision recorded. |
| **12** | **Hazard list for chunking** | `Mr.`, decimals, ellipses…; reduce bad sentence splits. |
| **13** | **Rate limit + backoff** | Respect 429; don’t DOS the provider from rapid partials. |

**Review gate:** After slice **8**, playtest streaming + stall behavior; after **10**, player + NPC + narrator paths with **lookup** table; after **6b**, duration-matched text vs audio.

---

## References (external)

- ElevenLabs — Text to speech API: `https://elevenlabs.io/docs/api-reference/text-to-speech/stream`  
- ElevenLabs — Streaming guide: `https://elevenlabs.io/docs/eleven-api/guides/how-to/text-to-speech/streaming`  
- ElevenLabs — WebSocket: `https://elevenlabs.io/docs/api-reference/websocket`  

---

## Module / dependency note

ElevenLabs is **cloud**; no extra Bannerlord module dependency. If a future slice uses a **NuGet** client, record version and update policy (user rule: verify latest when adding dependencies).

---

*Document status: design agreement. Update when POC results or product choices change.*
