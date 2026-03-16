using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements.Locations;

namespace NavalDLC.CampaignBehaviors;

public class PortCharactersCampaignBehavior : CampaignBehaviorBase
{
	public const float PortTownsmanCarryingStuffSpawnPercentage = 0.6f;

	public const float PortTownsmanSpawnPercentageMale = 0.2f;

	public const float PortTownsmanSpawnPercentageFemale = 0.1f;

	public const float ShipyardWorkerSpawnPercentage = 1f;

	public const float MarketWorkerSpawnPercentage = 0.75f;

	public const float CarpenterSpawnPercentage = 0.35f;

	private static List<(string, bool)> _itemToCarryAndIsMainHandData;

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
	private void OnAfterSessionLaunched(CampaignGameStarter campaignGameSystemStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsManCarryingStuff(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsPeopleMale(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateStaticTownsPeopleMale(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsPeopleFemale(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateShipyardWorker(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreatePortMarketWorker(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateCarpenter(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateMusician(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateShipWright(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogs(CampaignGameStarter campaignGameSystemStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool shipwright_default_dialog_start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (string, string, bool) GetRandomActionSetSuffixAndItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortCharactersCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PortCharactersCampaignBehavior()
	{
		throw null;
	}
}
