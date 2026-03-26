# Agent Development Guide

## Design and documentation writing

When editing design notes, `TECHNICAL_GUIDE`, or similar:

- **No editorial tone.** Do not write headings or asides that comment on how to think or write (e.g. parenthetical slogans, “precision, not …”, “read this first” as meta-joke, “we avoid …”, first-person editorial). State requirements in **neutral, direct** language.
- **No undefined jargon.** Every specialized term (`completion`, `pipeline`, `snapshot`, `proposal`, `world-shaped`, `interlocutor-shaped`, `ledger`, `shadow state`, `minted`, etc.) must appear in a **Terms** section with one-line definitions, or be defined **inline on first use**. Do not assume readers share prior chat context.
- **Section titles name the subject.** Prefer `Campaign pipeline versus NPC dialogue pipeline` over titles that are commentary on the content.

Violations make documents unusable for a cold reader; treat this as a hard rule for new or revised docs.

---

## LLM tool descriptions (`ToolCatalog` and related prompts)

Strings sent to the model as tool `description` fields (and parallel action text in `AIActionIntegration`) are **API contracts**, not documentation for maintainers.

- **Neutral voice.** Third person or imperative on what the tool *does*. No praise, blame, jokes, or “you should”.
- **No implementation leaks.** Do not name internal mods, DLLs, namespaces, class names, enum type names from dependencies, or engine internals the model cannot observe. Describe **inputs, outputs, and game-visible effects** only.
- **No editorial framing.** Avoid loaded qualifiers (“real”, “proper”) and prescriptive filler (“make sure”, “always remember”). State conditions and parameters as facts.
- **Prefer parameters over prose** for allowed values: use JSON `enum` where the set is fixed; keep the top-level description short and repeat detail in property descriptions if needed.
- **Same vocabulary as the game**: `string_id`, settlement vs village, give/receive, etc., aligned with `actionrules` and prompts.

Edits to `ToolCatalog.GetToolsForApi()` should be reviewed against this list.

---

## Target Game Version

This mod targets **Bannerlord v1.3.x**. Do not reference or worry about v1.0–v1.2.x API differences.

---

## Code Change Discipline

Always consider the consequences of a given code change even if it is just a single line.

**No 1–3 letter abbreviations** for variables, parameters, or any other identifiers. Use full names: `party` not `p`, `settlement` not `s`, `queryNormalized` not `q`, `referencePosition` not `pos`, `candidate` not `x`, `displayText` not `disp`, etc. Removing a comment, reordering a statement, or deleting a field can break non-obvious invariants (e.g. ordering dependencies, cleanup symmetry). Read the surrounding context before touching anything.

Never write `catch { }` or `catch (Exception) { }` — this masks errors and makes debugging impossible. Always surface the error.

### Gauntlet / UI prefab changes

Whenever you **change Gauntlet XML**, brushes, layout constants, or VM bindings for a screen:

1. **Show the user a text tree view** of the affected widget hierarchy **in your reply** (containers, important ids, `DataSource` roots, scroll/clip paths, and what is collapsible vs fixed chrome). **Do not** add or maintain a separate `CHAT_INTERFACE.md` (or similar) doc file in the repo for this—the tree is for the conversation only, not a committed artifact.

---

## TaleWorlds decompiled sources (`random_logs` branch)

Bulk **ILSpy-style decompiled C#** for Bannerlord managed assemblies lives on the **`random_logs`** branch only, under **`decompiled/`** at the repo root (SandBox, StoryMode, TaleWorlds.*, NavalDLC, etc.).

- **Do not** commit or push large decompiled trees to feature branches or `main`. Use `random_logs` for archaeology, binding traces, and comparing widget/VM code to Gauntlet XML.
- **CI / compile** still uses the small DLL set in **`.github/workflows/dlls/`** (referenced by the build). Those are not a full decompile; they exist so agents can verify symbols without checking out `random_logs`.
- **Finding types:** search under `decompiled/` for `HeroViewModel.cs`, `EncyclopediaCharacterTableauWidget.cs`, `CharacterViewModel.cs`, etc. Paths are assembly-rooted (e.g. `decompiled/TaleWorlds.CampaignSystem.ViewModelCollection/.../HeroViewModel.cs`).
- **Regenerating** (optional): install `ilspycmd`, then e.g.  
  `ilspycmd -p --nested-directories -r .github/workflows/dlls -o decompiled/<AssemblyName> .github/workflows/dlls/<AssemblyName>.dll`  
  Prefer doing that on a branch dedicated to reference dumps (e.g. `random_logs`), not on PR branches.

See also **`decompiled/README.md`** on `random_logs` for the same pointers.

---

## Bannerlord API Verification Protocol

**Every Bannerlord API call in new code MUST be verified against the official v1.3.4 docs before committing.**

URL pattern: `https://apidoc.bannerlord.com/v/1.3.4/class_{namespace_with_underscores}.html`

Namespace separators become `_1_1`. Example:
- `TaleWorlds.CampaignSystem.Party.MobileParty` → `class_tale_worlds_1_1_campaign_system_1_1_party_1_1_mobile_party`
- `TaleWorlds.CampaignSystem.Actions.DestroyPartyAction` → `class_tale_worlds_1_1_campaign_system_1_1_actions_1_1_destroy_party_action`

Check with curl and strip HTML tags:
```bash
curl -s "https://apidoc.bannerlord.com/v/1.3.4/<page>.html" | python3 -c "
import sys, re; html = sys.stdin.read()
print('Page size:', len(html))  # 321 bytes = class not found
matches = re.findall(r'MethodName.{0,400}', html)
for m in matches[:3]:
    print(re.sub(r'\s+', ' ', re.sub(r'<[^>]+>', ' ', m)).strip()[:300])
"
```

A page returning **321 bytes** means the class was not found at that URL — try alternate namespace paths.

### Verified v1.3.4 API Reference

| Call | Correct Signature | Notes |
|------|-------------------|-------|
| `BanditPartyComponent.CreateBanditParty` | `(string stringId, Clan clan, Hideout hideout, bool isBossParty, PartyTemplateObject pt, CampaignVec2 initialPosition)` | 6 args. Pass `null` for `pt` to fill roster manually. Party is placed at `initialPosition` — no need to call `InitializeMobilePartyAroundPosition` separately. |
| `MobileParty.InitializeMobilePartyAroundPosition` | `(TroopRoster memberRoster, TroopRoster prisonerRoster, CampaignVec2 position, float spawnRadius, float minSpawnRadius=0, bool isNaval=false)` | Position is `CampaignVec2`, not `Vec2`. |
| `MobileParty.SetMovePatrolAroundPoint` | `(CampaignVec2 point, NavigationType navigationType)` | Direct on `MobileParty`. Not on `party.Ai`. |
| `MobileParty.MemberRoster` | `TroopRoster [get]` | Use `party.MemberRoster.AddToCounts(...)` to fill troops after `CreateBanditParty`. |
| `MobileParty.Party` | `PartyBase [get]` | Use `party.Party.SetCustomName(...)` — `SetCustomName` is on `PartyBase` in v1.3.4, not directly on `MobileParty`. |
| `MobileParty.SetCustomName` | ❌ Does NOT exist in v1.3.4 | Use `party.Party.SetCustomName(TextObject)` via `PartyBase`. |
| `MobileParty.SetPartyUsedByQuest` | `(bool isActivelyUsed)` | Marks the party as used by a quest. |
| `MobileParty : ITrackableCampaignObject` | ✅ confirmed | `QuestBase.AddTrackedObject((ITrackableCampaignObject)(object)party)` works. |
| `MobileParty.GetPosition2D` | `Vec2 [get]` | Returns `Vec2`. |
| `PartyBase.SetCustomName` | `(TextObject name)` | On `PartyBase` (access via `mobileParty.Party`). |
| `QuestBase.AddTrackedObject` | `(ITrackableCampaignObject trackedObject)` | Adds the yellow `!` map marker. |
| `QuestBase.RemoveTrackedObject` | `(ITrackableCampaignObject trackedObject)` | |
| `TroopRoster` constructor | `(PartyBase partyBase)` | `new TroopRoster(party.Party)` is valid. |
| `TroopRoster.AddToCounts` | `(CharacterObject character, int count, bool insertAtFront=false, int woundedCount=0, int xpChange=0, bool removeDepleted=true, int index=-1)` | |
| `ItemRoster.Add` | `(ItemRosterElement itemRosterElement)` | Exists in docs but `ItemRosterElement` struct constructor is unverified. **Prefer `ItemRoster.AddToCounts(ItemObject, int)` — confirmed in docs and used throughout codebase.** |
| `ItemRoster.AddToCounts` | `(ItemObject item, int number)` | Preferred way to add items. |
| `DestroyPartyAction.Apply` | `(PartyBase destroyerParty, MobileParty destroyedParty)` | Pass `(PartyBase)null` for destroyerParty when no attacker. |
| `ChangeCrimeRatingAction.Apply` | `(IFaction faction, float deltaCrimeRating, bool showNotification=true)` | |
| `ChangeClanInfluenceAction.Apply` | `(Clan clan, float amount)` | |
| `Hero.AddSkillXp` | `(SkillObject skill, float xpAmount)` | Call directly on `Hero`, not via `HeroDeveloper`. |
| `Hero.FindAll` | `(Func<Hero, bool> predicate)` → `IEnumerable<Hero>` | |
| `Hero.IsWanderer` | `bool [get]` | |
| `Skills.All` | `static MBReadOnlyList<SkillObject> [get]` | In `TaleWorlds.CampaignSystem.Extensions`. **`DefaultSkills.GetAllSkills()` does NOT exist.** Use `Skills.All.FirstOrDefault(s => s.StringId == id)`. |
| `DefaultSkills.Medicine` etc. | `static SkillObject` | Individual skill properties exist on `DefaultSkills`. `GetAllSkills()` does not. |
| `CharacterObject.All` | `static MBReadOnlyList<CharacterObject> [get]` | |
| `Settlement.All` | `static MBReadOnlyList<Settlement> [get]` | |
| `Settlement.IsHideout` | `bool [get]` | |
| `Settlement.Hideout` | `Hideout [get]` | |
| `Settlement.GatePosition` | `CampaignVec2 [get]` | Returns `CampaignVec2`, not `Vec2`. Use `.ToVec2()` to convert: `CampaignVec2 g = s.GatePosition; Vec2 v = ((CampaignVec2)(ref g)).ToVec2();` |
| `Clan.BanditFactions` | `static IEnumerable<Clan> [get]` | |
| `Clan.PlayerClan` | `static Clan [get]` | |
| `Clan.BasicTroop` | `CharacterObject [get, set]` | |
| `MobileParty.All` | `static MBReadOnlyList<MobileParty> [get]` | |

### Position Types — Critical

`Vec2` and `CampaignVec2` are different types. **Never mix them without explicit conversion.**

- `Settlement.GatePosition` → `CampaignVec2`
- `MobileParty.Position` → `CampaignVec2`
- `MobileParty.GetPosition2D` → `Vec2`
- `MobileParty.Position2D` → `Vec2`
- `Hero.GetPosition2D` → `Vec2` (extension method in `GameVersionCompatibility.cs`)

Convert `CampaignVec2` → `Vec2`:
```csharp
CampaignVec2 gate = settlement.GatePosition;
Vec2 vec = ((CampaignVec2)(ref gate)).ToVec2();
```

Convert `Vec2` → `CampaignVec2` (ILSpy-compatible struct init):
```csharp
CampaignVec2 campaignPos = default(CampaignVec2);
((CampaignVec2)(ref campaignPos))._002Ector(vec2, true);
```

### Double-Checked Locking Pattern — Required for Static Caches

When using double-checked locking for a static cache, the field MUST be `volatile` AND the list must be populated into a local variable before being assigned to the field:

```csharp
// CORRECT
private static volatile List<...> _cache;

private static void EnsureCache()
{
    if (_cache != null) return;
    lock (CacheLock)
    {
        if (_cache != null) return;
        var temp = new List<...>();
        // ... populate temp ...
        _cache = temp;  // single atomic assignment as final step
    }
}
```

Both `volatile` and the local-variable assignment are required. Without `volatile`, the JIT/CPU can reorder the outer `if` check. Without the local variable, an exception during population leaves the field non-null but empty — permanently poisoning the cache for the session.

### Dictionary Iteration Safety

Never iterate a `Dictionary<K,V>` with `foreach` if any code path inside the loop writes to the same dictionary (even assigning existing keys). Always snapshot first: `foreach (var kv in dict.ToList())`.

### Skill StringId Casing

Bannerlord skill `StringId` values are **lowercase** (e.g., `"charm"`, `"leadership"`, `"medicine"`). AI output naturally uses title case. Always use `StringComparison.OrdinalIgnoreCase` when matching skills by StringId.

### Common Hallucination Patterns to Avoid

- `DefaultSkills.GetAllSkills()` — **does not exist**. Use `Skills.All`.
- `party.Ai.SetMovePatrolAroundPoint(...)` — wrong. `SetMovePatrolAroundPoint` is directly on `MobileParty`.
- `party.SetCustomName(...)` in v1.3.4 — wrong. Use `party.Party.SetCustomName(...)`.
- `BanditPartyComponent.CreateBanditParty(stringId, clan, hideout, isBossParty)` — wrong in v1.3.4, needs 6 args including `PartyTemplateObject` and `CampaignVec2`.
- `HeroDeveloper.AddSkillXp(skill, xp, bool, bool)` — wrong call path. Use `hero.AddSkillXp(skill, xp)` directly.
- `Hero.IsMainHero` — does NOT exist in v1.3.4. Use `h == Hero.MainHero` (reference comparison) or `h.IsHumanPlayerCharacter`.
- `Hero.GetPosition2D` — does NOT exist (no property, no extension method). To get a Hero's map position, follow the NPCInitiativeSystem.cs pattern: `hero.PartyBelongedTo.GetPosition2D()` if in a party, else `hero.CurrentSettlement.GetPosition2D` or `hero.HomeSettlement.GetPosition2D`.
- `new ItemRosterElement(item, count, null)` — constructor unverified. Use `ItemRoster.AddToCounts(ItemObject, int)` instead.
- `ItemObject.Name` / `BasicCharacterObject.Name` — these ARE valid `.Name` properties returning `TextObject`. `GetName()` is a separate override method, not the same thing.
- `InitializeMobilePartyAroundPosition(..., Vec2, ...)` — wrong in v1.3.4. Position arg is `CampaignVec2`.

---

## Quest Generation System

The quest system uses `AIGeneratedQuest` (extends `QuestBase`) and `AIQuestInfo` (JSON-serialized state).

### Rewards on Completion

All reward fields are optional. Set them in `ProcessCreateQuest` with clamping:

| Field | Type | Clamp | Effect |
|-------|------|-------|--------|
| `reward_gold` | `int` | — | Gold via `GiveGoldAction` |
| `reward_items` | `List<QuestItemReward>` | count 1–100 | Items via fuzzy `ItemMentionParser.FindBestItemMatch` |
| `reward_skill` + `reward_skill_xp` | `string` + `int` | XP 0–10000 | Skill XP via `hero.AddSkillXp(Skills.All...)` |
| `crime_rating_change` | `int?` | ±100 | `ChangeCrimeRatingAction.Apply` (requires kingdom) |
| `influence_change` | `int?` | ±200 | `ChangeClanInfluenceAction.Apply` (requires clan) |

### Hostile Party Spawn

`spawn_hostile_party: true` triggers `SpawnQuestHostileParty`:
1. Build `CampaignVec2` from spawn position
2. `BanditPartyComponent.CreateBanditParty(id, clan, hideout, false, null, campaignPos)` — 6 args
3. `party.MemberRoster.AddToCounts(troop, count, ...)` — fill troops directly
4. `party.Party.SetCustomName(TextObject)` — name via `PartyBase`
5. `party.SetMovePatrolAroundPoint(campaignPos, (NavigationType)3)` — patrol
6. `questBase.AddTrackedObject((ITrackableCampaignObject)(object)party)` — adds `!` map marker

Hostile parties are destroyed in `CleanupSpawnedQuestParty` via `DestroyPartyAction.Apply(null, party)`.

### Troop/Item Fuzzy Matching

`ItemMentionParser.FindBestTroopMatch(name)` and `FindBestItemMatch(name)` score candidates:
- Exact normalized match = 100
- Prefix match = 80
- Approximate token match = 50
