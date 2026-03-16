using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class CompanionsCampaignBehavior : CampaignBehaviorBase
{
	private enum CompanionTemplateType
	{
		Engineering,
		Tactics,
		Leadership,
		Steward,
		Trade,
		Roguery,
		Medicine,
		Smithing,
		Scouting,
		Combat
	}

	private const int CompanionMoveRandomIndex = 2;

	private const float DesiredCompanionPerTown = 0.6f;

	private const float KillChance = 0.1f;

	private const int SkillThresholdValue = 20;

	private const int RemoveWandererAfterDays = 40;

	private IReadOnlyDictionary<CompanionTemplateType, List<CharacterObject>> _companionsOfTemplates;

	private HashSet<CharacterObject> _aliveCompanionTemplates;

	private const float EngineerScore = 2f;

	private const float TacticsScore = 4f;

	private const float LeadershipScore = 3f;

	private const float StewardScore = 3f;

	private const float TradeScore = 3f;

	private const float RogueryScore = 4f;

	private const float MedicineScore = 3f;

	private const float SmithingScore = 2f;

	private const float ScoutingScore = 5f;

	private const float CombatScore = 5f;

	private const float AllScore = 34f;

	private float _desiredTotalCompanionCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WeeklyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveFromAliveCompanions(Hero companion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddToAliveCompanions(Hero companion, bool isTemplateControlled = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroOccupationChanged(Hero hero, Occupation oldOccupation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroCreated(Hero hero, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryKillCompanion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrySpawnNewCompanion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SwapCompanions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustEquipment(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustEquipmentImp(Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCompanionTemplateList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CompanionTemplateType GetTemplateTypeOfCompanion(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateCompanionAndAddToSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CompanionTemplateType GetCompanionTemplateTypeToSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsTemplateKnown(CharacterObject companionTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterObject GetCompanionTemplateToSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetTemplateTypeScore(CompanionTemplateType templateType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CompanionTemplateType GetTemplateTypeForSkill(SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompanionsCampaignBehavior()
	{
		throw null;
	}
}
