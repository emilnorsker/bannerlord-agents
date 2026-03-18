# Opposed Skill Check — Critical Review (Decompiled Trace)

Full step-by-step trace using decompiled TaleWorlds API from `random_logs` branch. Method bodies are stubs (`throw null`) but API surface exposes the call hierarchy.

---

## Stack Trace 1: Application Tick → DelayedTaskManager → Death Execution

**When:** Player on campaign map, 5+ seconds after character_death scheduled.

```
[Native C++ engine - game loop]
  └─ IManagedComponent.OnApplicationTick(float dt)
       decompiled/TaleWorlds.MountAndBlade/TaleWorlds.MountAndBlade/CoreManaged.cs:80
       (IManagedComponent interface - engine calls into managed)

  └─ Module.OnApplicationTick(float dt)
       decompiled/TaleWorlds.MountAndBlade/TaleWorlds.MountAndBlade/Module.cs:369
       (Module holds _subModuleBases: Dictionary<SubModuleInfo, MBSubModuleBase>)
       (Iterates submodules, calls OnApplicationTick on each)

  └─ MBSubModuleBase.OnApplicationTick(float dt)
       decompiled/TaleWorlds.MountAndBlade/TaleWorlds.MountAndBlade/MBSubModuleBase.cs:58
       (Virtual - our SubModule overrides)

  └─ SubModule.OnApplicationTick(float dt)
       src/AIInfluence/SubModule.cs:130
       base.OnApplicationTick(dt);
       if (Campaign.Current != null)
         Campaign.Current.GetCampaignBehavior<AIInfluenceBehavior>()?.Tick(dt);

  └─ Campaign.GetCampaignBehavior<T>()
       decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/Campaign.cs:2348
       (Returns AIInfluenceBehavior from _campaignBehaviorManager)

  └─ AIInfluenceBehavior.Tick(float dt)
       src/AIInfluence/AIInfluenceBehavior.cs:467
       _delayedTaskManager.Tick(dt);

  └─ DelayedTaskManager.Tick(float dt)
       src/AIInfluence/DelayedTaskManager.cs:45
       DateTime currentTime = DateTime.Now;
       List<DelayedTask> list = _tasks.Where(t => t.TriggerTime <= currentTime).ToList();
       foreach (DelayedTask item in list)
         item.Action?.Invoke();   // <-- DEATH TASK EXECUTES HERE

  └─ [Closure: delegate from ProcessChatInput line 3358]
       Hero killer = Hero.FindFirst(...);
       KillCharacterHeroPublic(npc, killer, killedInAction: false, context.OpposedAttribute);

  └─ AIInfluenceBehavior.KillCharacterHeroPublic(...)
       src/AIInfluence/AIInfluenceBehavior.cs:8198

  └─ AIInfluenceBehavior.KillCharacterHero(...)
       src/AIInfluence/AIInfluenceBehavior.cs:8203

  └─ OpposedSkillCheck.ParseAttribute(opposedAttribute)
       src/AIInfluence/OpposedSkillCheck.cs:21

  └─ Hero.GetAttributeValue(CharacterAttribute)
       decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/Hero.cs:2026
       (Native: reads hero's attribute from campaign data)

  └─ MBRandom.RandomInt(int minValue, int maxValue)
       decompiled/TaleWorlds.Core/TaleWorlds.Core/MBRandom.cs:86
       (Native: uses MBFastRandom, deterministic for save compatibility)

  └─ OpposedSkillCheck.PlayerWins(...)
       src/AIInfluence/OpposedSkillCheck.cs:76

  └─ KillCharacterAction.ApplyByMurder(Hero victim, Hero killer, bool showNotification)
       decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem.Actions/KillCharacterAction.cs:47
       (Native: ApplyInternal → MakeDead → HeroKilledEvent)
```

**Critical:** If save/load occurs between `AddTask(5.0, ...)` and `item.Action.Invoke()`, the task is in `_tasks` which is not serialized. On load, `DelayedTaskManager` is recreated with empty `_tasks`. Death never runs.

---

## Stack Trace 2: Campaign TickEvent Path (Alternative Tick Source)

**When:** Campaign map tick; AIInfluenceBehavior also subscribes to CampaignEvents.TickEvent.

```
[Campaign tick - from MapState or CampaignPeriodicEventManager]
  └─ MapState.OnTick(float dt)
       decompiled/TaleWorlds.CampaignSystem/.../MapState.cs:168
       (Calls handler.Tick, OnMapModeTick, OnMenuModeTick)

  └─ Campaign.RealTick(float realDt)
       decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/Campaign.cs:2276
       (Advances campaign time, ticks periodic events)

  └─ CampaignPeriodicEventManager.OnTick(float dt)
       decompiled/.../CampaignPeriodicEventManager.cs:244
       (TickPeriodicEvents, SignalPeriodicEvents - daily/hourly)

  └─ [Somewhere in Campaign tick flow]
       CampaignEvents._tickEvent.Invoke(dt)
       decompiled/.../CampaignEvents.cs:288  (_tickEvent: MbEvent<float>)
       decompiled/.../MbEvent.cs:143  (Invoke(T t) → InvokeList)

  └─ MbEvent.InvokeList(EventHandlerRec<float> list, float t)
       (Iterates listeners added via AddNonSerializedListener)

  └─ AIInfluenceBehavior delegate: (float dt) => OnTick(dt)
       src/AIInfluence/AIInfluenceBehavior.cs:354
       CampaignEvents.TickEvent.AddNonSerializedListener(this, (Action<float>)(dt => OnTick(dt)));

  └─ AIInfluenceBehavior.OnTick(float dt)
       src/AIInfluence/AIInfluenceBehavior.cs:498
       _delayedTaskManager.Tick(dt);
       [same as Stack Trace 1 from here]
```

**Note:** Both `SubModule.OnApplicationTick` and `CampaignEvents.TickEvent` call `_delayedTaskManager.Tick(dt)`. So `DelayedTaskManager.Tick` runs **twice per frame** when on campaign map. First call executes and removes tasks; second call sees empty list. No double-execution.

---

## Stack Trace 3: Opposed Check — ProcessMoneyTransfer (Chat UI)

**When:** Player extorts NPC in chat, AI returns money_transfer + opposed_attribute.

```
[User sends message in NpcChatWindow]
  └─ NpcChatWindowVM sends to ProcessChatInput
  └─ AIInfluenceBehavior.ProcessChatInput(...)
       src/AIInfluence/AIInfluenceBehavior.cs:3221
       aiResult = JsonConvert.DeserializeObject<AIResponse>(cleaned);

  └─ [Line 3460] ProcessMoneyTransfer(npc, context, aiResult.MoneyTransfer)

  └─ AIInfluenceBehavior.ProcessMoneyTransfer(...)
       src/AIInfluence/AIInfluenceBehavior.cs:2269
       if (!string.IsNullOrWhiteSpace(moneyTransfer.OpposedAttribute))

  └─ OpposedSkillCheck.ParseAttribute("social")
       src/AIInfluence/OpposedSkillCheck.cs:21
       key = "social" → AttributeMap exact match → DefaultCharacterAttributes.Social

  └─ OpposedSkillCheck.PlayerWins(Hero.MainHero, npc, attr, out roll, out dc, out total)
       src/AIInfluence/OpposedSkillCheck.cs:76
       playerAbility = GetAbility(player, attr)
       npcAbility = GetAbility(npc, attr)

  └─ OpposedSkillCheck.GetAbility(Hero hero, CharacterAttribute attr)
       src/AIInfluence/OpposedSkillCheck.cs:65
       return hero.GetAttributeValue(attr) * 20;

  └─ Hero.GetAttributeValue(CharacterAttribute charAttribute)
       decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/Hero.cs:2026

  └─ MBRandom.RandomInt(1, 20)
       decompiled/TaleWorlds.Core/TaleWorlds.Core/MBRandom.cs:86

  └─ [If won] npc.ChangeHeroGold(-amount); Hero.MainHero.ChangeHeroGold(amount);
       (TaleWorlds.CampaignSystem - gold transfer)
```

---

## Stack Trace 4: Settlement Combat — Roleplay Death Kill

**When:** Player kills NPC in settlement, SettlementCombatManager runs before battle mode.

```
[SettlementCombatManager - after combat analysis]
  └─ SettlementCombatManager [some method that checks TriggerType]
       src/AIInfluence.SettlementCombat/SettlementCombatManager.cs:843
       if (_activeCombat.TriggerType == CombatTriggerType.RoleplayDeath)

  └─ _behavior.KillCharacterHeroPublic(triggerNPC, val2, killedInAction: false, context?.OpposedAttribute)
       src/AIInfluence.SettlementCombat/SettlementCombatManager.cs:869

  └─ AIInfluenceBehavior.KillCharacterHero(...)
       src/AIInfluence/AIInfluenceBehavior.cs:8203
       attr = OpposedSkillCheck.ParseAttribute(opposedAttribute)  // context?.OpposedAttribute
       if (killer == Hero.MainHero)
         OpposedSkillCheck.PlayerWins(...)

  └─ [If Mission.Current != null] Agent.Die(Blow, KillInfo)
       (TaleWorlds.MountAndBlade - mission agent death)
  └─ KillCharacterAction.ApplyByMurder(hero, killer, true)
       decompiled/.../KillCharacterAction.cs:47
       (Campaign-level hero death, HeroKilledEvent)
```

**Context source:** `context` = `_activeCombat.TriggerContext` from `InitiateCombat(npc, context, ...)`. If `InitiateCombat` was called with null context, `context?.OpposedAttribute` → null → ParseAttribute(null) → Vigor.

---

## Stack Trace 5: Vanilla Dialogue — Pending Death via DialogManager

**When:** Player clicks "..." after NPC says they die; aiinfluence_apply_changes consequence runs.

```
[Player clicks "..." in vanilla dialogue]
  └─ DialogManager aiinfluence_apply_changes OnConsequence
       src/AIInfluence/DialogManager.cs:600 (consequence delegate)

  └─ [Line 1357] if (context.PendingDeath == "pending")

  └─ GetDelayedTaskManager().AddTask(5.0, delegate { ... })
       src/AIInfluence/DialogManager.cs:1360

  └─ DelayedTaskManager.AddTask(double delaySeconds, Action action)
       src/AIInfluence/DelayedTaskManager.cs:25
       TriggerTime = DateTime.Now.AddSeconds(5)
       _tasks.Add(item)

  └─ [5 seconds later - see Stack Trace 1]
       DelayedTaskManager.Tick → item.Action.Invoke()
       Closure: Hero val19 = Hero.FindFirst(...)
                _behavior.KillCharacterHeroPublic(npc, val19, ..., context.OpposedAttribute)
```

**Closure capture:** `npc`, `context` captured by closure. If game saves and loads during 5s, closure is lost (task list cleared). `context.OpposedAttribute` was set when PendingDeath was set; after load, no task runs, OpposedAttribute sits stale in saved context.

---

## Summary: What Can Break

| # | Failure | Cause |
|---|---------|-------|
| 1 | Death never executes | Save/load during 5s delay; DelayedTaskManager not serialized |
| 2 | Pending actions discarded | Player clicks "Return" before "..." ; exit clears PendingDeath/Money/Items |
| 3 | Double tick | DelayedTaskManager.Tick called from both SubModule and CampaignEvents; harmless (tasks removed after first run) |
| 4 | Stale OpposedAttribute | Never cleared when PendingDeath/KillerStringId cleared |
| 5 | Real time vs game time | DateTime.Now used; pauses/speed don't affect delay |

---

## Decompiled Files Referenced

- `decompiled/TaleWorlds.MountAndBlade/TaleWorlds.MountAndBlade/MBSubModuleBase.cs`
- `decompiled/TaleWorlds.MountAndBlade/TaleWorlds.MountAndBlade/Module.cs`
- `decompiled/TaleWorlds.MountAndBlade/TaleWorlds.MountAndBlade/CoreManaged.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/Campaign.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/CampaignEvents.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/CampaignPeriodicEventManager.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/MbEvent.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem/Hero.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem.Actions/KillCharacterAction.cs`
- `decompiled/TaleWorlds.Core/TaleWorlds.Core/MBRandom.cs`
- `decompiled/TaleWorlds.CampaignSystem/TaleWorlds.CampaignSystem.GameState/MapState.cs`
