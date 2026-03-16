using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;

namespace SandBox.CampaignBehaviors;

public class RecruitmentAgentSpawnBehavior : CampaignBehaviorBase
{
	private RecruitmentCampaignBehavior RecruitmentBehavior
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
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfMercenaryCharacterNeedsToRefresh(Settlement settlement, CharacterObject oldTroopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMercenaryNumberChanged(Town town, int oldNumber, int newNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMercenaryTroopChanged(Town town, CharacterObject oldTroopType, CharacterObject newTroopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMercenaryCharacterToTavern(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateMercenary(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RecruitmentAgentSpawnBehavior()
	{
		throw null;
	}
}
