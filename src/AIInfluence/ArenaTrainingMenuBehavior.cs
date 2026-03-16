using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using OnConditionDelegate = TaleWorlds.CampaignSystem.GameMenus.OnConditionDelegate;
using OnConsequenceDelegate = TaleWorlds.CampaignSystem.GameMenus.OnConsequenceDelegate;

namespace AIInfluence;

public class ArenaTrainingMenuBehavior : CampaignBehaviorBase
{
	private enum TrainingTarget
	{
		PlayerOnly,
		CompanionOnly,
		Both
	}

	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static OnConditionDelegate _003C0_003E__TrainTroopsCondition;

		public static OnConsequenceDelegate _003C1_003E__TrainTroopsConsequence;

		public static OnConditionDelegate _003C2_003E__TrainPlayerCondition;

		public static OnConsequenceDelegate _003C3_003E__TrainPlayerConsequence;

		public static OnConditionDelegate _003C4_003E__TrainCompanionCondition;

		public static OnConsequenceDelegate _003C5_003E__TrainCompanionSelectConsequence;

		public static OnConditionDelegate _003C6_003E__TrainAllCondition;

		public static OnConsequenceDelegate _003C7_003E__TrainAllConsequence;

		public static OnInitDelegate _003C8_003E__OnTrainingWaitInit;

		public static OnConditionDelegate _003C9_003E__OnTrainingWaitCondition;

		public static OnTickDelegate _003C10_003E__OnTrainingWaitTick;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static OnConditionDelegate _003C_003E9__39_0;

		public static OnConsequenceDelegate _003C_003E9__39_1;

		public static OnConditionDelegate _003C_003E9__39_2;

		public static OnConsequenceDelegate _003C_003E9__39_3;

		internal TroopRoster _003CGetTrainingRosters_003Eb__35_0(MobileParty p)
		{
			return p.MemberRoster;
		}

		internal bool _003CGetTrainingParties_003Eb__36_0(MobileParty x)
		{
			return ((MBObjectBase)x).StringId == _selectedCompanionPartyId;
		}

		internal bool _003CAddMenus_003Eb__39_0(MenuCallbackArgs args)
		{
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			args.optionLeaveType = (LeaveType)16;
			return true;
		}

		internal void _003CAddMenus_003Eb__39_1(MenuCallbackArgs args)
		{
			GameMenu.SwitchToMenu("town_arena");
		}

		internal bool _003CAddMenus_003Eb__39_2(MenuCallbackArgs args)
		{
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			args.optionLeaveType = (LeaveType)16;
			return true;
		}

		internal void _003CAddMenus_003Eb__39_3(MenuCallbackArgs args)
		{
			CancelTraining();
		}

		internal InquiryElement _003CTrainCompanionSelectConsequence_003Eb__46_0(MobileParty p)
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			int num = CountTrainableTroops(p.MemberRoster);
			Hero leaderHero = p.LeaderHero;
			string text = (((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "???") + " ? " + num;
			return new InquiryElement((object)((MBObjectBase)p).StringId, text, (ImageIdentifier)null);
		}

		internal bool _003CTrainAllConsequence_003Eb__48_0(TroopRoster r)
		{
			return CountTrainableTroops(r) <= 0;
		}

		internal bool _003CShowTrainingStartedNotification_003Eb__51_0(MobileParty x)
		{
			return ((MBObjectBase)x).StringId == _selectedCompanionPartyId;
		}

		internal int _003COnTrainingMenuInit_003Eb__52_0(MobileParty cp)
		{
			return CountTrainableTroops(cp.MemberRoster);
		}

		internal bool _003COnTrainingWaitInit_003Eb__53_0(MobileParty x)
		{
			return ((MBObjectBase)x).StringId == _selectedCompanionPartyId;
		}
	}

	private const int TrainingDurationHours = 8;

	private const float BaseXpPerTroopPerHour = 20f;

	private const float BaseCostPerTroop = 12f;

	private const float CostTierMultiplier = 0.65f;

	private const float BaseCostPerTroopOwnKingdom = 10f;

	private const float CostTierMultiplierOwnKingdom = 0.35f;

	private const float WoundChancePerHour = 0.07f;

	private const int CooldownHours = 72;

	private const int MinTrainingCost = 50;

	private static int _trainingHoursRemaining;

	private static TrainingTarget _currentTarget;

	private static string _selectedCompanionPartyId;

	private static bool _includePlayerInTraining;

	private static readonly HashSet<string> _trainingPartyIds = new HashSet<string>();

	private static Settlement _trainingSettlement;

	private static int _totalTrained;

	private static int _totalXpGiven;

	private static int _totalWounded;

	private static float _trainingElapsedHours;

	private static int _hoursDistributed;

	private static Dictionary<string, double> _partyCooldownEndHours = new Dictionary<string, double>();

	public float TrainingProgress => 1f - (float)_trainingHoursRemaining / 8f;

	private static bool IsPartyOnCooldown(string partyId)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (partyId == null || !_partyCooldownEndHours.TryGetValue(partyId, out var value))
		{
			return false;
		}
		CampaignTime now = CampaignTime.Now;
		if ((now).ToHours >= value)
		{
			_partyCooldownEndHours.Remove(partyId);
			return false;
		}
		return true;
	}

	private static int GetPartyCooldownHours(string partyId)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (partyId == null || !_partyCooldownEndHours.TryGetValue(partyId, out var value))
		{
			return 0;
		}
		double num = value;
		CampaignTime now = CampaignTime.Now;
		double num2 = num - (now).ToHours;
		if (num2 <= 0.0)
		{
			_partyCooldownEndHours.Remove(partyId);
			return 0;
		}
		return (int)Math.Ceiling(num2);
	}

	private static void SetPartyCooldown(string partyId)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (partyId != null)
		{
			Dictionary<string, double> partyCooldownEndHours = _partyCooldownEndHours;
			CampaignTime now = CampaignTime.Now;
			partyCooldownEndHours[partyId] = (now).ToHours + 72.0;
		}
	}

	public static bool IsPartyInTraining(MobileParty party)
	{
		return party != null && _trainingPartyIds.Contains(((MBObjectBase)party).StringId);
	}

	public override void RegisterEvents()
	{
		CampaignEvents.AiHourlyTickEvent.AddNonSerializedListener((object)this, (Action<MobileParty, PartyThinkParams>)OnAiHourlyTick);
	}

	public override void SyncData(IDataStore dataStore)
	{
		bool binarySyncCompatibilityMode = false;
		if (binarySyncCompatibilityMode)
		{
			_partyCooldownEndHours ??= new Dictionary<string, double>();
			return;
		}
		string syncStage = "sync-start";
		try
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[SYNC-TRACE] ArenaTrainingMenuBehavior.SyncData enter. isSaving={dataStore.IsSaving}, isLoading={dataStore.IsLoading}");
			syncStage = "sync-arenaPartyCooldownEndHours";
			dataStore.SyncData<Dictionary<string, double>>("AIInfluence_arenaPartyCooldownEndHours", ref _partyCooldownEndHours);
			if (_partyCooldownEndHours == null)
			{
				_partyCooldownEndHours = new Dictionary<string, double>();
			}
			AIInfluenceBehavior.Instance?.LogMessage("[SYNC-TRACE] ArenaTrainingMenuBehavior.SyncData exit success. cooldownCount=" + _partyCooldownEndHours.Count);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] ArenaTrainingMenuBehavior.SyncData failed at stage=" + syncStage + ". cooldownCount=" + (_partyCooldownEndHours?.Count ?? 0) + ". " + ex);
			if (dataStore.IsLoading)
			{
				_partyCooldownEndHours = new Dictionary<string, double>();
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Recovering ArenaTrainingMenuBehavior load failure with empty cooldown state.");
				return;
			}
			throw;
		}
	}

	private void OnAiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		if (GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.EnableArenaTraining || mobileParty == null || p == null || _trainingPartyIds.Count == 0 || !_trainingPartyIds.Contains(((MBObjectBase)mobileParty).StringId) || mobileParty.CurrentSettlement == null)
		{
			return;
		}
		Settlement currentSettlement = mobileParty.CurrentSettlement;
		List<(AIBehaviorData, float)> list = ((IEnumerable<(AIBehaviorData, float)>)p.AIBehaviorScores).Where(((AIBehaviorData, float) s) => (int)s.Item1.AiBehavior != 2 || true).ToList();
		foreach (var item in list)
		{
			((List<(AIBehaviorData, float)>)(object)p.AIBehaviorScores).Remove(item);
		}
	}

	private static void DistributeHourlyTrainingXp()
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		List<TroopRoster> trainingRosters = GetTrainingRosters();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (TroopRoster item in trainingRosters)
		{
			foreach (FlattenedTroopRosterElement item2 in item.ToFlattenedRoster())
			{
				FlattenedTroopRosterElement current2 = item2;
				if (!((BasicCharacterObject)(current2).Troop).IsHero && !(current2).IsWounded && !(current2).IsKilled && CanTroopBeTrained((current2).Troop))
				{
					num3++;
					float num4 = 1f + (float)(current2).Troop.Tier * 0.35f;
					int num5 = (int)(20f * num4);
					item.AddXpToTroop((current2).Troop, num5);
					num2 += num5;
					float val = 0.07f - (float)(current2).Troop.Tier * 0.002f;
					if (MBRandom.RandomFloat <= Math.Max(val, 0.005f))
					{
						item.WoundTroop((current2).Troop, 1, default(UniqueTroopDescriptor));
						num++;
					}
				}
			}
		}
		_totalTrained = num3;
		_totalXpGiven += num2;
		_totalWounded += num;
		if (num > 0)
		{
			TextObject val2 = new TextObject("{=AIInfluence_ArenaHourlyWound}{WOUNDED} soldiers were wounded during sparring this hour.", (Dictionary<string, object>)null);
			val2.SetTextVariable("WOUNDED", num);
			InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), Colors.Gray));
		}
		if (num2 > 0)
		{
			TextObject val3 = new TextObject("{=AIInfluence_ArenaHourlyXp}{TRAINED} troops gained {XP} experience this hour.", (Dictionary<string, object>)null);
			val3.SetTextVariable("TRAINED", num3);
			val3.SetTextVariable("XP", num2);
			InformationManager.DisplayMessage(new InformationMessage(((object)val3).ToString(), Colors.Gray));
		}
	}

	private static void OnTrainingFinished()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		List<MobileParty> trainingParties = GetTrainingParties();
		UnlockAllTrainingParties();
		foreach (MobileParty item in trainingParties)
		{
			SetPartyCooldown(((MBObjectBase)item).StringId);
		}
		TextObject val = new TextObject("{=AIInfluence_ArenaTrainResult}Arena training complete! Troops trained: {TRAINED}, total XP: {XP}. Wounded in sparring: {WOUNDED}.", (Dictionary<string, object>)null);
		val.SetTextVariable("TRAINED", _totalTrained);
		val.SetTextVariable("XP", _totalXpGiven);
		val.SetTextVariable("WOUNDED", _totalWounded);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
		GameMenu.SwitchToMenu("town_arena");
	}

	private static void CancelTraining()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		UnlockAllTrainingParties();
		TextObject val = new TextObject("{=AIInfluence_ArenaTrainCancelled}Training cancelled. Troops return without additional experience.", (Dictionary<string, object>)null);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
		GameMenu.SwitchToMenu("town_arena");
	}

	private static List<TroopRoster> GetTrainingRosters()
	{
		return (from p in GetTrainingParties()
			select p.MemberRoster).ToList();
	}

	private static List<MobileParty> GetTrainingParties()
	{
		List<MobileParty> list = new List<MobileParty>();
		switch (_currentTarget)
		{
		case TrainingTarget.PlayerOnly:
			list.Add(MobileParty.MainParty);
			break;
		case TrainingTarget.CompanionOnly:
		{
			MobileParty val2 = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty x) => ((MBObjectBase)x).StringId == _selectedCompanionPartyId));
			if (val2 != null)
			{
				list.Add(val2);
			}
			break;
		}
		case TrainingTarget.Both:
			if (_includePlayerInTraining)
			{
				list.Add(MobileParty.MainParty);
			}
			foreach (string partyId in _trainingPartyIds.ToList())
			{
				MobileParty val = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty x) => ((MBObjectBase)x).StringId == partyId));
				if (val != null)
				{
					list.Add(val);
				}
			}
			break;
		}
		return list;
	}

	private static void LockPartyForTraining(MobileParty party)
	{
		if (party != null && party != MobileParty.MainParty)
		{
			_trainingPartyIds.Add(((MBObjectBase)party).StringId);
		}
	}

	private static void UnlockAllTrainingParties()
	{
		_trainingPartyIds.Clear();
		_trainingSettlement = null;
	}

	public static void AddMenus(CampaignGameStarter starter)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		object obj = _003C_003EO._003C0_003E__TrainTroopsCondition;
		if (obj == null)
		{
			OnConditionDelegate val = TrainTroopsCondition;
			_003C_003EO._003C0_003E__TrainTroopsCondition = val;
			obj = (object)val;
		}
		object obj2 = _003C_003EO._003C1_003E__TrainTroopsConsequence;
		if (obj2 == null)
		{
			OnConsequenceDelegate val2 = TrainTroopsConsequence;
			_003C_003EO._003C1_003E__TrainTroopsConsequence = val2;
			obj2 = (object)val2;
		}
		starter.AddGameMenuOption("town_arena", "arena_train_troops", "{=AIInfluence_ArenaTrainTroops}Train troops in the arena", (GameMenuOption.OnConditionDelegate)obj, (GameMenuOption.OnConsequenceDelegate)obj2, false, 2, false, (object)null);
		starter.AddGameMenu("arena_training_menu", "{ARENA_TRAINING_MENU_TEXT}", new OnInitDelegate(OnTrainingMenuInit), (MenuOverlayType)3, (MenuFlags)0, (object)null);
		object obj3 = _003C_003EO._003C2_003E__TrainPlayerCondition;
		if (obj3 == null)
		{
			OnConditionDelegate val3 = TrainPlayerCondition;
			_003C_003EO._003C2_003E__TrainPlayerCondition = val3;
			obj3 = (object)val3;
		}
		object obj4 = _003C_003EO._003C3_003E__TrainPlayerConsequence;
		if (obj4 == null)
		{
			OnConsequenceDelegate val4 = TrainPlayerConsequence;
			_003C_003EO._003C3_003E__TrainPlayerConsequence = val4;
			obj4 = (object)val4;
		}
		starter.AddGameMenuOption("arena_training_menu", "arena_train_player", "{=AIInfluence_ArenaTrainMyTroops}Train my troops", (GameMenuOption.OnConditionDelegate)obj3, (GameMenuOption.OnConsequenceDelegate)obj4, false, -1, false, (object)null);
		object obj5 = _003C_003EO._003C4_003E__TrainCompanionCondition;
		if (obj5 == null)
		{
			OnConditionDelegate val5 = TrainCompanionCondition;
			_003C_003EO._003C4_003E__TrainCompanionCondition = val5;
			obj5 = (object)val5;
		}
		object obj6 = _003C_003EO._003C5_003E__TrainCompanionSelectConsequence;
		if (obj6 == null)
		{
			OnConsequenceDelegate val6 = TrainCompanionSelectConsequence;
			_003C_003EO._003C5_003E__TrainCompanionSelectConsequence = val6;
			obj6 = (object)val6;
		}
		starter.AddGameMenuOption("arena_training_menu", "arena_train_companion", "{=AIInfluence_ArenaTrainCompanion}Train companion's troops", (GameMenuOption.OnConditionDelegate)obj5, (GameMenuOption.OnConsequenceDelegate)obj6, false, -1, false, (object)null);
		object obj7 = _003C_003EO._003C6_003E__TrainAllCondition;
		if (obj7 == null)
		{
			OnConditionDelegate val7 = TrainAllCondition;
			_003C_003EO._003C6_003E__TrainAllCondition = val7;
			obj7 = (object)val7;
		}
		object obj8 = _003C_003EO._003C7_003E__TrainAllConsequence;
		if (obj8 == null)
		{
			OnConsequenceDelegate val8 = TrainAllConsequence;
			_003C_003EO._003C7_003E__TrainAllConsequence = val8;
			obj8 = (object)val8;
		}
		starter.AddGameMenuOption("arena_training_menu", "arena_train_all", "{=AIInfluence_ArenaTrainAll}Train all troops together", (GameMenuOption.OnConditionDelegate)obj7, (GameMenuOption.OnConsequenceDelegate)obj8, false, -1, false, (object)null);
		object obj9 = _003C_003Ec._003C_003E9__39_0;
		if (obj9 == null)
		{
			OnConditionDelegate val9 = delegate(MenuCallbackArgs args)
			{
				//IL_0004: Unknown result type (might be due to invalid IL or missing references)
				args.optionLeaveType = (LeaveType)16;
				return true;
			};
			_003C_003Ec._003C_003E9__39_0 = val9;
			obj9 = (object)val9;
		}
		object obj10 = _003C_003Ec._003C_003E9__39_1;
		if (obj10 == null)
		{
			OnConsequenceDelegate val10 = delegate
			{
				GameMenu.SwitchToMenu("town_arena");
			};
			_003C_003Ec._003C_003E9__39_1 = val10;
			obj10 = (object)val10;
		}
		starter.AddGameMenuOption("arena_training_menu", "arena_training_back", "{=AIInfluence_ArenaTrainBack}Back to arena", (GameMenuOption.OnConditionDelegate)obj9, (GameMenuOption.OnConsequenceDelegate)obj10, true, -1, false, (object)null);
		object obj11 = _003C_003EO._003C8_003E__OnTrainingWaitInit;
		if (obj11 == null)
		{
			OnInitDelegate val11 = OnTrainingWaitInit;
			_003C_003EO._003C8_003E__OnTrainingWaitInit = val11;
			obj11 = (object)val11;
		}
		object obj12 = _003C_003EO._003C9_003E__OnTrainingWaitCondition;
		if (obj12 == null)
		{
			OnConditionDelegate val12 = OnTrainingWaitCondition;
			_003C_003EO._003C9_003E__OnTrainingWaitCondition = val12;
			obj12 = (object)val12;
		}
		object obj13 = _003C_003EO._003C10_003E__OnTrainingWaitTick;
		if (obj13 == null)
		{
			OnTickDelegate val13 = OnTrainingWaitTick;
			_003C_003EO._003C10_003E__OnTrainingWaitTick = val13;
			obj13 = (object)val13;
		}
		starter.AddWaitGameMenu("arena_training_wait", "{ARENA_TRAINING_WAIT_TEXT}", (OnInitDelegate)obj11, (OnConditionDelegate)obj12, (OnConsequenceDelegate)null, (OnTickDelegate)obj13, (MenuAndOptionType)2, (MenuOverlayType)3, 8f, (MenuFlags)0, (object)null);
		object obj14 = _003C_003Ec._003C_003E9__39_2;
		if (obj14 == null)
		{
			OnConditionDelegate val14 = delegate(MenuCallbackArgs args)
			{
				//IL_0004: Unknown result type (might be due to invalid IL or missing references)
				args.optionLeaveType = (LeaveType)16;
				return true;
			};
			_003C_003Ec._003C_003E9__39_2 = val14;
			obj14 = (object)val14;
		}
		object obj15 = _003C_003Ec._003C_003E9__39_3;
		if (obj15 == null)
		{
			OnConsequenceDelegate val15 = delegate
			{
				CancelTraining();
			};
			_003C_003Ec._003C_003E9__39_3 = val15;
			obj15 = (object)val15;
		}
		starter.AddGameMenuOption("arena_training_wait", "arena_training_leave", "{=AIInfluence_ArenaTrainLeave}Stop training and leave", (GameMenuOption.OnConditionDelegate)obj14, (GameMenuOption.OnConsequenceDelegate)obj15, false, -1, false, (object)null);
	}

	private static bool TrainTroopsCondition(MenuCallbackArgs args)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		if (GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.EnableArenaTraining)
		{
			return false;
		}
		args.optionLeaveType = (LeaveType)2;
		if (Settlement.CurrentSettlement == null || !Settlement.CurrentSettlement.IsTown)
		{
			return false;
		}
		if (MobileParty.MainParty == null)
		{
			return false;
		}
		Town town = Settlement.CurrentSettlement.Town;
		if (town != null && town.HasTournament)
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaTournamentBlockTip}During the tournament the arena is busy ? training is unavailable. Wait for the tournament to end.", (Dictionary<string, object>)null);
			args.IsEnabled = false;
			return true;
		}
		return true;
	}

	private static bool TrainPlayerCondition(MenuCallbackArgs args)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		if (GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.EnableArenaTraining)
		{
			return false;
		}
		args.optionLeaveType = (LeaveType)17;
		Settlement currentSettlement = Settlement.CurrentSettlement;
		bool? obj;
		if (currentSettlement == null)
		{
			obj = null;
		}
		else
		{
			Town town = currentSettlement.Town;
			obj = ((town != null) ? new bool?(town.HasTournament) : ((bool?)null));
		}
		bool? flag = obj;
		if (flag == true)
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaTournamentBlockTip}During the tournament the arena is busy ? training is unavailable. Wait for the tournament to end.", (Dictionary<string, object>)null);
			args.IsEnabled = false;
			return true;
		}
		if (IsPartyOnCooldown(((MBObjectBase)MobileParty.MainParty).StringId))
		{
			TextObject val = new TextObject("{=AIInfluence_ArenaCooldownTip}Your troops need time to recover after the last training. {HOURS} hours remaining.", (Dictionary<string, object>)null);
			val.SetTextVariable("HOURS", GetPartyCooldownHours(((MBObjectBase)MobileParty.MainParty).StringId));
			args.Tooltip = val;
			args.IsEnabled = false;
			return true;
		}
		if (CountTrainableTroops(MobileParty.MainParty.MemberRoster) == 0)
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaNoTroops}You have no troops to train (max tier troops don't need training).", (Dictionary<string, object>)null);
			args.IsEnabled = false;
		}
		return true;
	}

	private static bool TrainCompanionCondition(MenuCallbackArgs args)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		if (GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.EnableArenaTraining)
		{
			return false;
		}
		args.optionLeaveType = (LeaveType)17;
		Settlement currentSettlement = Settlement.CurrentSettlement;
		bool? obj;
		if (currentSettlement == null)
		{
			obj = null;
		}
		else
		{
			Town town = currentSettlement.Town;
			obj = ((town != null) ? new bool?(town.HasTournament) : ((bool?)null));
		}
		bool? flag = obj;
		if (flag == true)
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaTournamentBlockTip}During the tournament the arena is busy ? training is unavailable. Wait for the tournament to end.", (Dictionary<string, object>)null);
			args.IsEnabled = false;
			return true;
		}
		List<MobileParty> eligibleCompanionParties = GetEligibleCompanionParties();
		if (!eligibleCompanionParties.Any())
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaNoCompanionAvailable}No companion troops available for training at the moment.", (Dictionary<string, object>)null);
			args.IsEnabled = false;
		}
		return true;
	}

	private static bool TrainAllCondition(MenuCallbackArgs args)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		if (GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.EnableArenaTraining)
		{
			return false;
		}
		args.optionLeaveType = (LeaveType)17;
		Settlement currentSettlement = Settlement.CurrentSettlement;
		bool? obj;
		if (currentSettlement == null)
		{
			obj = null;
		}
		else
		{
			Town town = currentSettlement.Town;
			obj = ((town != null) ? new bool?(town.HasTournament) : ((bool?)null));
		}
		bool? flag = obj;
		if (flag == true)
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaTournamentBlockTip}During the tournament the arena is busy ? training is unavailable. Wait for the tournament to end.", (Dictionary<string, object>)null);
			args.IsEnabled = false;
			return true;
		}
		bool flag2 = !IsPartyOnCooldown(((MBObjectBase)MobileParty.MainParty).StringId) && CountTrainableTroops(MobileParty.MainParty.MemberRoster) > 0;
		bool flag3 = GetEligibleCompanionParties().Any();
		if (!flag2 && !flag3)
		{
			args.Tooltip = new TextObject("{=AIInfluence_ArenaNoTroopsAll}No troops available for training.", (Dictionary<string, object>)null);
			args.IsEnabled = false;
		}
		return true;
	}

	private static void TrainTroopsConsequence(MenuCallbackArgs args)
	{
		GameMenu.SwitchToMenu("arena_training_menu");
	}

	private static void TrainPlayerConsequence(MenuCallbackArgs args)
	{
		int num = CountTrainableTroops(MobileParty.MainParty.MemberRoster);
		if (num > 0)
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			int cost = CalculateTrainingCost((IEnumerable<TroopRoster>)(object)new TroopRoster[1] { MobileParty.MainParty.MemberRoster }, currentSettlement);
			if (TryPayTrainingCost(cost, currentSettlement))
			{
				_currentTarget = TrainingTarget.PlayerOnly;
				_selectedCompanionPartyId = null;
				_includePlayerInTraining = true;
				ShowTrainingStartedNotification();
				BeginTraining();
			}
		}
	}

	private static void TrainCompanionSelectConsequence(MenuCallbackArgs args)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		List<MobileParty> companions = GetEligibleCompanionParties();
		if (!companions.Any())
		{
			return;
		}
		if (companions.Count == 1)
		{
			DoStartCompanionTraining(companions[0]);
			return;
		}
		List<InquiryElement> list = ((IEnumerable<MobileParty>)companions).Select((Func<MobileParty, InquiryElement>)delegate(MobileParty p)
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			int num = CountTrainableTroops(p.MemberRoster);
			Hero leaderHero = p.LeaderHero;
			string text = (((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "???") + " ? " + num;
			return new InquiryElement((object)((MBObjectBase)p).StringId, text, (ImageIdentifier)null);
		}).ToList();
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_ArenaSelectCompanion}Select companion party", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_ArenaSelectCompanionDesc}Choose whose troops to send for training:", (Dictionary<string, object>)null)).ToString(), list, true, 1, 1, ((object)new TextObject("{=AIInfluence_ArenaConfirm}Confirm", (Dictionary<string, object>)null)).ToString(), (string)null, (Action<List<InquiryElement>>)delegate(List<InquiryElement> selectedItems)
		{
			InquiryElement val = selectedItems?.FirstOrDefault();
			if (val != null)
			{
				InformationManager.HideInquiry();
				string partyId = val.Identifier as string;
				MobileParty val2 = ((IEnumerable<MobileParty>)companions).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == partyId));
				if (val2 != null)
				{
					DoStartCompanionTraining(val2);
				}
			}
		}, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void DoStartCompanionTraining(MobileParty party)
	{
		int num = CountTrainableTroops(party.MemberRoster);
		if (num > 0)
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			int cost = CalculateTrainingCost((IEnumerable<TroopRoster>)(object)new TroopRoster[1] { party.MemberRoster }, currentSettlement);
			if (TryPayTrainingCost(cost, currentSettlement))
			{
				_currentTarget = TrainingTarget.CompanionOnly;
				_selectedCompanionPartyId = ((MBObjectBase)party).StringId;
				_includePlayerInTraining = false;
				LockPartyForTraining(party);
				ShowTrainingStartedNotification();
				BeginTraining();
			}
		}
	}

	private static void TrainAllConsequence(MenuCallbackArgs args)
	{
		List<TroopRoster> list = new List<TroopRoster>();
		List<MobileParty> eligibleCompanionParties = GetEligibleCompanionParties();
		bool flag = !IsPartyOnCooldown(((MBObjectBase)MobileParty.MainParty).StringId);
		if (flag)
		{
			list.Add(MobileParty.MainParty.MemberRoster);
		}
		foreach (MobileParty item in eligibleCompanionParties)
		{
			list.Add(item.MemberRoster);
		}
		if (list.All((TroopRoster r) => CountTrainableTroops(r) <= 0))
		{
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		int cost = CalculateTrainingCost(list, currentSettlement);
		if (!TryPayTrainingCost(cost, currentSettlement))
		{
			return;
		}
		_currentTarget = TrainingTarget.Both;
		_selectedCompanionPartyId = null;
		_includePlayerInTraining = flag;
		foreach (MobileParty item2 in eligibleCompanionParties)
		{
			LockPartyForTraining(item2);
		}
		ShowTrainingStartedNotification();
		BeginTraining();
	}

	private static bool TryPayTrainingCost(int cost, Settlement settlement)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		if (Hero.MainHero.Gold < cost)
		{
			TextObject val = new TextObject("{=AIInfluence_ArenaNotEnoughGold}You don't have enough gold for training.", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Red));
			return false;
		}
		if (settlement != null)
		{
			GiveGoldAction.ApplyForCharacterToSettlement(Hero.MainHero, settlement, cost, false);
		}
		else
		{
			Hero.MainHero.ChangeHeroGold(-cost);
		}
		return true;
	}

	private static void BeginTraining()
	{
		_trainingHoursRemaining = 8;
		_totalTrained = 0;
		_totalXpGiven = 0;
		_totalWounded = 0;
		_trainingElapsedHours = 0f;
		_hoursDistributed = 0;
		_trainingSettlement = Settlement.CurrentSettlement;
		GameMenu.ActivateGameMenu("arena_training_wait");
		GameMenu.SwitchToMenu("arena_training_wait");
	}

	private static void ShowTrainingStartedNotification()
	{
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		switch (_currentTarget)
		{
		case TrainingTarget.PlayerOnly:
			ArenaTrainingNotification.Notify(currentSettlement, Hero.MainHero);
			break;
		case TrainingTarget.CompanionOnly:
		{
			MobileParty val = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty x) => ((MBObjectBase)x).StringId == _selectedCompanionPartyId));
			ArenaTrainingNotification.Notify(currentSettlement, ((val != null) ? val.LeaderHero : null) ?? Hero.MainHero);
			break;
		}
		case TrainingTarget.Both:
			ArenaTrainingNotification.Notify(currentSettlement, Hero.MainHero);
			{
				foreach (MobileParty eligibleCompanionParty in GetEligibleCompanionParties())
				{
					if (eligibleCompanionParty.LeaderHero != null)
					{
						ArenaTrainingNotification.Notify(currentSettlement, eligibleCompanionParty.LeaderHero);
					}
				}
				break;
			}
		}
	}

	private static void OnTrainingMenuInit(MenuCallbackArgs args)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		int num = CountTrainableTroops(MobileParty.MainParty.MemberRoster);
		List<MobileParty> eligibleCompanionParties = GetEligibleCompanionParties();
		int num2 = eligibleCompanionParties.Sum((MobileParty cp) => CountTrainableTroops(cp.MemberRoster));
		int num3 = CalculateTrainingCost((IEnumerable<TroopRoster>)(object)new TroopRoster[1] { MobileParty.MainParty.MemberRoster }, currentSettlement);
		int num4 = (int)(IsPlayerSettlement(currentSettlement) ? 10f : 12f);
		TextObject val = new TextObject("{=AIInfluence_ArenaMenuText}The arena offers training grounds for your troops. Experienced arena masters will put them through intense sparring sessions.\n\nYour trainable troops: {PLAYER_TROOPS} (cost: {PLAYER_COST}).{COMPANION_INFO}\n\nCost: per troop by tier (base {BASE} denars, higher tier = more), min {MIN}. Duration: {DURATION} hours.\nSome troops may get wounded.", (Dictionary<string, object>)null);
		val.SetTextVariable("PLAYER_TROOPS", num);
		val.SetTextVariable("PLAYER_COST", num3);
		val.SetTextVariable("BASE", num4);
		val.SetTextVariable("MIN", 50);
		val.SetTextVariable("DURATION", 8);
		if (eligibleCompanionParties.Any())
		{
			TextObject val2 = new TextObject("{=AIInfluence_ArenaCompanionInfo}\nCompanion parties in town: {COMP_COUNT} (trainable troops: {COMP_TROOPS})", (Dictionary<string, object>)null);
			val2.SetTextVariable("COMP_COUNT", eligibleCompanionParties.Count);
			val2.SetTextVariable("COMP_TROOPS", num2);
			val.SetTextVariable("COMPANION_INFO", val2);
		}
		else
		{
			val.SetTextVariable("COMPANION_INFO", "");
		}
		string text = ((object)val).ToString().Replace("\\n", "\n");
		MBTextManager.SetTextVariable("ARENA_TRAINING_MENU_TEXT", text, false);
	}

	private static void OnTrainingWaitInit(MenuCallbackArgs args)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		TextObject val;
		switch (_currentTarget)
		{
		case TrainingTarget.PlayerOnly:
			val = new TextObject("{=AIInfluence_ArenaTrainTargetPlayer}Your troops", (Dictionary<string, object>)null);
			break;
		case TrainingTarget.CompanionOnly:
		{
			MobileParty val2 = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty x) => ((MBObjectBase)x).StringId == _selectedCompanionPartyId));
			if (((val2 != null) ? val2.LeaderHero : null) != null)
			{
				val = new TextObject("{=AIInfluence_ArenaTrainTargetCompanion}Troops of {LEADER}", (Dictionary<string, object>)null);
				val.SetTextVariable("LEADER", val2.LeaderHero.Name);
			}
			else
			{
				val = new TextObject("{=AIInfluence_ArenaTrainTargetPlayer}Your troops", (Dictionary<string, object>)null);
			}
			break;
		}
		default:
			val = new TextObject("{=AIInfluence_ArenaTrainTargetAll}All troops", (Dictionary<string, object>)null);
			break;
		}
		TextObject val3 = new TextObject("{=AIInfluence_ArenaWaitText}{TARGET} are training in the arena. The clashing of weapons and shouts of arena masters echo through the grounds.", (Dictionary<string, object>)null);
		val3.SetTextVariable("TARGET", val);
		MBTextManager.SetTextVariable("ARENA_TRAINING_WAIT_TEXT", ((object)val3).ToString(), false);
		args.MenuContext.GameMenu.SetTargetedWaitingTimeAndInitialProgress(8f, 0f);
		args.MenuContext.GameMenu.StartWait();
	}

	private static bool OnTrainingWaitCondition(MenuCallbackArgs args)
	{
		return true;
	}

	private static void OnTrainingWaitTick(MenuCallbackArgs args, CampaignTime dt)
	{
		_trainingElapsedHours += (float)(dt).ToHours;
		while (_hoursDistributed < (int)_trainingElapsedHours)
		{
			DistributeHourlyTrainingXp();
			_hoursDistributed++;
		}
		float progressOfWaitingInMenu = Math.Min(_trainingElapsedHours / 8f, 1f);
		args.MenuContext.GameMenu.SetProgressOfWaitingInMenu(progressOfWaitingInMenu);
		if (_trainingElapsedHours >= 8f)
		{
			OnTrainingFinished();
		}
	}

	private static int CountTrainableTroops(TroopRoster roster)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (roster == null)
		{
			return 0;
		}
		int num = 0;
		foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)roster.GetTroopRoster())
		{
			TroopRosterElement current = item;
			if (!((BasicCharacterObject)current.Character).IsHero && (current).Number > 0 && CanTroopBeTrained(current.Character))
			{
				int num2 = (current).Number - (current).WoundedNumber;
				if (num2 > 0)
				{
					num += num2;
				}
			}
		}
		return num;
	}

	private static bool CanTroopBeTrained(CharacterObject character)
	{
		return character != null && !((BasicCharacterObject)character).IsHero && character.UpgradeTargets != null && character.UpgradeTargets.Length != 0;
	}

	private static List<MobileParty> GetEligibleCompanionParties()
	{
		List<MobileParty> list = new List<MobileParty>();
		if (Settlement.CurrentSettlement != null)
		{
			Hero mainHero = Hero.MainHero;
			if (((mainHero != null) ? mainHero.Clan : null) != null)
			{
				Settlement currentSettlement = Settlement.CurrentSettlement;
				foreach (MobileParty item in (List<MobileParty>)(object)MobileParty.All)
				{
					if (item != MobileParty.MainParty && item.LeaderHero != null && item.LeaderHero.Clan == Hero.MainHero.Clan && item.CurrentSettlement == currentSettlement && !IsPartyOnCooldown(((MBObjectBase)item).StringId) && CountTrainableTroops(item.MemberRoster) > 0)
					{
						list.Add(item);
					}
				}
				return list;
			}
		}
		return list;
	}

	private static int CalculateTrainingCost(IEnumerable<TroopRoster> rosters, Settlement settlement)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (rosters == null)
		{
			return 50;
		}
		bool flag = IsPlayerSettlement(settlement);
		float num = (flag ? 10f : 12f);
		float num2 = (flag ? 0.35f : 0.65f);
		int num3 = 0;
		foreach (TroopRoster roster in rosters)
		{
			if (roster == null)
			{
				continue;
			}
			foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)roster.GetTroopRoster())
			{
				TroopRosterElement current2 = item;
				if (!((BasicCharacterObject)current2.Character).IsHero && (current2).Number > 0 && CanTroopBeTrained(current2.Character))
				{
					int num4 = (current2).Number - (current2).WoundedNumber;
					if (num4 > 0)
					{
						float num5 = 1f + (float)current2.Character.Tier * num2;
						num3 += (int)(num * num5) * num4;
					}
				}
			}
		}
		return Math.Max(num3, 50);
	}

	private static bool IsPlayerSettlement(Settlement settlement)
	{
		if (settlement != null)
		{
			Hero mainHero = Hero.MainHero;
			if (((mainHero != null) ? mainHero.Clan : null) != null)
			{
				if (settlement.MapFaction != Hero.MainHero.MapFaction)
				{
					return false;
				}
				return true;
			}
		}
		return false;
	}
}
