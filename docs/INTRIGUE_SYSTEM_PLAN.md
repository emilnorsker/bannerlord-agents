# Intrigue system — design plan

Consolidated plan for a **living-world intrigue layer** in the AI Influence / Bannerlord stack: mix **Crusader Kings III–style** secrets and leverage, **Dwarf Fortress–style** long-horizon plots and graphs, and **Disco Elysium–style** asymmetric dialogue—while **Bannerlord remains the authority** for consequences and **existing dynamic events** stay the pulse of a living world.

---

## 1. Vision

- The world **moves without the player in every room**: plots and rumors **spawn, spread, decay**, and tie into **diplomacy** the same way `dynamic_events` already do.
- **Secrets** stay objects (who knows, severity, optional hook use); **plots** are **intent + phases + participants**, not only prose.
- The **LLM is the creative engine** (beats, plausibility, voice, pressure); the **save layer stores typed state** (events, knowledge, patches) so campaigns stay consistent and debuggable.

---

## 2. Design principles

1. **Split fact from fiction in data** — Secrets = *known facts*; plots = *goals and phases*. Prompts combine both per NPC, filtered by what they plausibly know.
2. **Three layers**  
   - **Ledger** — Durable records: plots, phases, participants, links to events/secrets.  
   - **Simulation** — Ticks and triggers advance phases and emit **Bannerlord-safe** effects.  
   - **Presentation** — Dialogue LLM only **interprets** the slice + pressure variables; it does not silently own world truth.
3. **Bannerlord as physics** — Read clan, kingdom, war, relation, gold, settlements, battles, crime, quests; write consequences through **normal game channels** (relations, wars, missions, incidents, statements).
4. **Living world = same rhythm as dynamic events** — New intrigue should **extend or attach to** `dynamic_events` (and related diplomacy files), reuse **propagation**, **importance**, **expiry**, **spread_speed**, and **per-NPC `DynamicEvents`**.
5. **LLM used to the fullest** — Rich context in; **structured patches** out (event rows, knowledge updates, diplomatic intents). Soft “is this plausible?” reasoning lives in the model; **hard invariants** live in code.
6. **No masking errors** — Failed parses, invalid actions, or API failures surface clearly (logs, UI, or explicit fallback behavior)—never silent success.

---

## 3. Architecture overview

```
Triggers (time, battle, travel, diplomacy, …)
    → Context bundle (Bannerlord snapshot + recent events + relations)
    → LLM Pass A — world beat (structured proposals)
    → Validate & commit (schema + engine invariants)
    → Propagation (who gets DynamicEvents / knowledge updates)
    → [Player talks]
    → LLM Pass B — dialogue (NPC slice + pressure only)
```

**Directed graph (DF-style)** — `mastermind → lieutenants → pawns → target` (target often player or clan), stored as references to **heroes/clans/kingdoms** where the game provides ids.

**Phases (example)** — `gather_intel → position → strike → cover_up` (template-specific). Advancement is **trigger-driven** + optional checks (battle outcome, visits, companions left in settlement, etc.).

**Pressure variables (Disco-style)** — Per-NPC scalars or tags: e.g. fear_of_exposure, greed, loyalty_to_faction. Same ledger row produces **different speech** without hand-authored branches for every line.

---

## 4. Data model (target shape)

*Exact field names can follow existing mod conventions; this is the logical model.*

| Concept | Purpose |
|--------|---------|
| **Secret** (existing + optional extensions) | `id`, description, severity, `knowledgeChance`, `applicableNPCs`, `accessLevel`, tags; optional: `leverage`, `contradicts`, `implicates` |
| **Plot instance** | `id`, `template_id` (murder, coup, blackmail, fabricate_claim, …), `phase`, `phase_started_day`, `deadline_day`, `status` (active/failed/exposed/resolved), links to `dynamic_event_id`(s) |
| **Plot participants** | Roles: mastermind, lieutenant, pawn, target; map to game entities + optional anonymity flags |
| **Knowledge sync** | Per NPC: which plot **roles** they know about; which **secrets**; which **event ids** in `DynamicEvents` |
| **Pressure** | Per NPC (or per NPC–plot): small structured block updated by analysis or rules |
| **Hook** (player- or NPC-held) | First-class leverage object: `id`, `target_hero_id` (or clan), `basis` (`secret_id` and/or `evidence_event_id`), **`strength`** (`weak` / `strong`), optional `decay_campaign_days` or use limits. **Strong** = defensible proof, hard to deny, large relation / diplomatic / coercion range. **Weak** = hearsay, single witness, forged or partial—usable but may **backfire**, be **disputed**, or **burn** on use. Hooks are **not** free-text; the LLM role-plays around **committed** hook state. |
| **Player knowledge** | Track what the **player** has verified: `PlayerKnownSecretIds`, `PlayerHooks` (owned hooks only). Distinguish **verified secret** (entered ledger by investigation, document, confession, reliable chain) from **rumor** (only `world_info` / unconfirmed events in UI). |

**Attachment to living events** — Prefer `dynamic_events` entries that carry or reference `plot_id`, so intrigue **rises and falls** with the same propagation and diplomacy hooks described in `TECHNICAL_GUIDE.en.md` (`type`, `importance`, `kingdoms_involved`, `spread_speed`, `expiration_campaign_days`, `allows_diplomatic_response`, etc.).

---

## 5. Integration with existing mod artifacts

| Artifact | Role |
|----------|------|
| `world_secrets.json` | Canonical secret definitions; optional new fields for plot linkage / leverage |
| `world_info.json` | Public rumor layer vs `Secrets:` / `General Info:` split in prompts |
| `dynamic_events.json` | **Primary carrier** for “something is happening”; intrigue **creates or extends** these |
| `diplomatic_statements.json`, `diplomatic_events.json`, … | Ruler reactions and actions tied to `event_id` |
| `save_data/.../NPC (id).json` | `KnownSecrets`, `KnownInfo`, `DynamicEvents` — **who knows what** |
| Logs (`dynamicEvents.log`, `diplomacy.txt`) | Full prompts/responses for generation and debugging |

---

## 6. Triggers (inputs)

| Trigger | Typical use |
|---------|----------------|
| Campaign **daily / weekly** tick | Timeouts, coalition building, rumor spread |
| **Enter / leave** settlement | Intel, positioning, meetings, assassination windows |
| **Battle end** | Escalation, capture reveals, cover-up |
| **Relation / influence / gold** shifts | Hook strength, template eligibility signals |
| **Quest / mission** state | Player commitment; vanilla-shaped follow-ups |
| **Conversation open** | Refresh **read-only** context for prompts; optional intent tags from player text (processed on next tick) |

**Ordering** — Run simulation **before** assembling dialogue context for that session. Effects should be **idempotent** where possible (phase flags) to avoid double application on duplicate triggers.

---

## 7. Update pipeline (each processing batch)

1. **Queue** — Triggers append candidate transitions (e.g. “strike eligible”).
2. **Validate** — **Hard** gates: engine/API safety, schema. **Soft** gates: LLM plausibility score + reason (optional).
3. **Advance** — Update `phase` / `status`; branch on success/fail/exposed.
4. **Emit** — Apply Bannerlord effects (relations, war, crime, missions, incidents).
5. **Sync knowledge** — Update NPC `DynamicEvents`, `KnownSecrets` / plot visibility by role.
6. **Dialogue** — Build prompt only from **that NPC’s slice** + pressure.

---

## 8. Gateways (three lanes)

1. **Engine invariants** — Minimal; prevents invalid ids, impossible actions, crashes.
2. **World plausibility (LLM)** — Model sees accurate state; proposes beats and likelihood; not the only line of defense.
3. **Schema / patch application** — LLM outputs **typed JSON** (new event, knowledge delta, diplomatic intent enum); code commits only valid patches.

---

## 9. LLM passes

| Pass | Input | Output | Commit |
|------|--------|--------|--------|
| **A — World beat** | Snapshot + active plots/events + diplomacy context | 0–k structured **event/plot** proposals | Merge into `dynamic_events` / plot ledger after validation |
| **B — Dialogue** | NPC slice + pressure + **player-owned** hooks/secrets that apply to this interlocutor (same facts the **leverage strip** shows) | Natural language only | Conversation history only; **no** silent state change unless a separate **explicit** tool/patch path exists |
| **Optional — Propagation narrative** | Edge (A learned event E) | Short “why they heard” string | Debug / flavor; **not** source of truth for propagation rules |

---

## 10. Player-facing interface — hooks, verified secrets, paranoia

**Goal:** The player **learns the mechanics** by seeing **durable game objects** at the moment of talk, and stays **a little paranoid** about context—without dumping internal plot phase names by default.

### 10.1 Chat UI — leverage strip (current interlocutor)

**Requirement:** Verified secrets and hooks (**strong** / **weak**) **must** appear on the **same chat surface** the player uses for AI dialogue—not only encyclopedia or inventory. Concretely: extend **`GUI/Prefabs/ChatInterface.xml`** (`ChatInterfaceWindow`), in the **left stat banner** (with `@RelationText` / `@TrustLabel` / `@EmotionLabel`) **and/or** the **center header** (below `@NpcName` / title), so leverage is visible **while typing and reading messages**.

When the player talks to hero **H**, show a compact **leverage strip** there (icons + short labels, tooltips for detail):

| Indicator | When shown | What it teaches |
|-----------|------------|-----------------|
| **Verified secret** | `secret_id` ∈ `PlayerKnownSecretIds` and secret **implicates** or **applies to** H (tag, subject, or explicit link) | You hold **truth** usable in negotiation; not the same as tavern gossip. |
| **Hook (strong)** | Player owns a `Hook` with `target_hero_id == H`, `strength == strong` | High-stakes leverage; system will weight coercion / compliance in prompts and outcomes. |
| **Hook (weak)** | Same, `strength == weak` | You can push, but **risk** of denial, counter-reveal, or burned hook—UI tooltip says so. |
| **No hook / no verified secret** | — | Either you have nothing solid on **this** character, or only rumors (see world events / encyclopedia). |

**Copy discipline:** Labels use in-world words where possible (“You have proof of…” / “You could press them on…”); **strong/weak** can appear as **stamina-bar style** or **metal vs rope** metaphor if you want full diegesis, with strength exposed in tooltip.

**Rumor vs secret:** If the player only has a **rumor** (dynamic event or `world_info`, not verified), show **no** verified-secret badge; optional muted “Rumor (unconfirmed)” if you want to teach the distinction without granting mechanical hook power.

### 10.2 Hook list & detail (inventory screen or encyclopedia subpage)

- List all **player-owned hooks**: target name, **basis** one-liner (which secret/event), **strong/weak**, optional expiry.
- Click → short **mechanical reminder**: what strong vs weak means for **burn risk** and **AI behavior** (one paragraph, not a novel).

### 10.3 MCM

- Toggle: show **hook strength** as explicit words vs purely diegetic.
- Toggle: show **verified secret** strip in conversation (on by default for learnability).

### 10.4 Paranoia without obscurity

Ambient “who might hear” cues (from the earlier interface concept) **stack** with the strip: the player sees **both** “I have a **weak** hook” and “**Public** setting”—i.e. using it here may be **risky**. Strong hooks might still be **dangerous** socially even if hard to deny.

---

## 11. Reference scenarios (for testing the design)

Short labels for QA / implementation checks:

- **Blackmail** — You have real leverage on one lord; they push back or fold.
- **Hunt / reprisal** — You win a fight; the other side does not forget.
- **Quiet politics** — No battle; reputation and rumors move anyway.
- **Broken battle + missing friend** — You lose badly; someone you care about is left behind.

**Full walkthroughs** (written for a reader who has **not** read the rest of this doc) are in **§15 Appendix**.

---

## 12. Phased delivery

1. **Schema + persistence** — Plot records and optional `plot_id` / metadata on dynamic events; migration-safe saves.
2. **Hooks + player knowledge** — `PlayerHooks` (with `weak` / `strong`), `PlayerKnownSecretIds`, rules for creating/burning hooks from verified secrets or evidence events.
3. **Tick + validation** — Triggers invoke pipeline; only **enum-safe** effects at first.
4. **Secret–plot links** — Leverage, hook flags, phase unlocks from known secrets.
5. **LLM Pass A** — Structured world-beat generation wired to existing dynamic event creation path.
6. **Pressure + Pass B** — Per-NPC pressure updates; dialogue prompts use slices only; Pass B receives **player hook/secret context** only when UI shows it (same source of truth).
7. **Interface** — **Chat UI** leverage strip in `ChatInterface.xml` (with optional hook inventory page) + MCM toggles.
8. **Polish** — Caps on concurrent plots, MCM intensity, logging and replay checks.

---

## 13. Non-goals and risks

- **Non-goal** — Fully simulated court politics inside the LLM with no save-backed state.
- **Risk** — Unbounded LLM freedom → inconsistent saves; mitigated by **patches only** for durable changes.
- **Risk** — Player never notices off-screen plots; mitigated by **discovery** subphases, missions, encyclopedia/rumor hooks, and diplomatic visibility.

---

## 14. Inspirational references (outside the mod)

- **Crusader Kings III** — Secrets, hooks, schemes as *state*.
- **Dwarf Fortress** — Long-horizon plots and graphs.
- **Disco Elysium** — Asymmetric information and voice under pressure.

---

## 15. Appendix — three walkthroughs (narrative, technical detail inside the story)

Each story below is written as continuous prose. Where the system matters, the text states **what is stored**, **what is shown**, and **what runs on a schedule**, in plain language.

### 15.A — After you win a fight and some of them escape

You fight a lord from another kingdom, you win, and you take him prisoner. Not everyone on his side dies or surrenders; a few riders break away and ride clear. Your kingdom and his were already at odds, so fighting in that region already felt normal.

The game records the war as a high-importance situation: which kingdoms are involved, that you were in the fight, and a number that says how fast word should spread to individual lords, merchants, and village leaders. Those characters each keep a list of situation ids they are allowed to know. The list grows over in-game days according to that spread number. When you talk to someone, the text assembled for that character’s dialogue includes only the situations and secrets that character’s file lists, so two people in the same town can answer differently because their lists differ.

The escaped riders give the design a clear reason for the enemy faction to add true details about you: the direction you left, how many you still had under your banner, where you might sell captives. None of that requires the dialogue system to add facts that are not already backed by a line in the save data; the game can advance a prepared sequence when the campaign day advances or when you enter certain settlements, and then apply normal Bannerlord outcomes—another battle on the road, a messenger demanding gold, a shift in relations—because those are actions the engine already supports.

You read tavern dialogue and the scrolling list of what the world thinks is going on; some lines are false rumors, but many entries are tied to the same stored situation, so talk and the map stay aligned. A ruler can issue a public statement that references the same situation id as the rumor list, which is how a speech and a private chat stay about the same facts.

The conversation screen next to the log still shows that character’s relation to you and how much they trust you. If you have verified proof about *this* character stored in your save, the game shows that in the same place; if you only heard gossip and never confirmed it, that proof line stays empty even if you are angry.

The situation stops when peace returns, you ransom or release the prisoner in a way that clears the flag, or enough campaign days pass that the entry is deleted from the global list and removed from each character’s list. Until then, the save keeps who learned what so nobody answers as if none of it happened.

---

### 15.B — Days without a battle, only trade and town visits

For several days you do not fight. You enter a town twice, sell and buy, and leave. Elsewhere in the same kingdom, people are already talking about who will follow an aging leader, and a fair has temporarily lowered tariffs on certain goods.

The game does not need a battle to create a new situation. On a calendar check it can add a political or social entry with a lower spread number at first, so only a small set of characters receive the id on their personal list. Your name can appear in that entry as the accused party in a lie or half-truth tied to a lord who already dislikes you from an earlier failed quest. Friends turn cold because their files now include that situation id and the instructions for that character’s dialogue treat that entry as something they believe.

That same situation type can still be marked so rulers are allowed to react in public. The stored text of their statement links back to the same id as the entry on the rumor list, so you can see that the public line and the private insults are about one recorded object, not two unrelated stories.

When you open the dialogue chat, the game must draw a hard line in what it displays to you: text that exists only because rumor spread is not shown as verified proof. Verified proof is a separate list in your save that only grows when you complete an investigation step, see a document, or get an admission the game records as binding. That difference controls what you are allowed to threaten with in dialogue without the model guessing.

If you disprove the accusation, pay off the right person, or wait until the situation reaches its stored day limit, the game removes the id from the global record and from each character. After removal, new conversations no longer receive that situation in the character’s context.

---

### 15.C — A large defeat and a companion left in a town the enemy holds

You fight a large battle and lose. You leave the field with a handful of troops. One companion, Ari, does not travel with you; the game sets Ari’s location to a town controlled by the enemy and marks Ari as separated from your party after that battle.

The war entry is already marked as severe. The game can start or continue a sequence keyed to “major defeat” plus “named companion in enemy town.” The sequence has steps that advance on campaign days and on certain player actions, not on whatever wording you type in chat. Each step decides whether enemy characters gain new situation ids on their lists, whether Ari’s character file gains a flag that means “questioned,” and whether any fact about your plans is copied from Ari’s knowledge into an enemy lord’s list. The dialogue model does not get to declare those copies by itself; only a validated change to the save does that.

You walk into a negotiation. The conversation screen shows relation, trust, and emotion the same as always. It also shows, only when your save contains a verified damaging fact tied to this exact lord, that you have that fact. If you are speaking to a jailer or a marshal who has no such entry in your save, the proof section stays blank even though they spent the last days in the same building as Ari. You choose your next sentence without the game telling you whether Ari already answered questions.

If Ari never gives them anything they can verify, their lists never gain your travel plans, and later fights and peace offers stay unchanged by that branch. If a step runs that copies information out of Ari’s file into theirs, the same stored facts can feed the next battle setup or the terms offered when truce is discussed. When you free Ari, trade prisoners, or a set number of days passes with a recorded outcome, the game writes the sequence as finished so that defeat does not start the same sequence over from the beginning.

---

*This document is the single consolidated reference for intrigue direction; implementation tasks should trace back to sections here.*
