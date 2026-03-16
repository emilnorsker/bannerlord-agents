using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.CampaignBehaviors;

public class ShipNameCampaignBehavior : CampaignBehaviorBase
{
	[Flags]
	private enum NameTrait
	{
		None = 0,
		Aserai = 2,
		Battania = 4,
		Empire = 8,
		Khuzait = 0x10,
		Nord = 0x20,
		Sturgia = 0x40,
		Vlandia = 0x80,
		Light = 0x100,
		Medium = 0x200,
		Heavy = 0x400,
		Trade = 0x800,
		LightAndMedium = 0x300
	}

	private MBReadOnlyList<(TextObject, NameTrait, float)> _fullNames;

	private MBReadOnlyList<(TextObject, NameTrait)> _firstNames;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipOwnerChanged(Ship ship, PartyBase owner, ShipOwnerChangeDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetRandomFullName(List<int> availableWeights, float totalWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignNameToShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static NameTrait GetNameFlags(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipNameCampaignBehavior()
	{
		throw null;
	}
}
