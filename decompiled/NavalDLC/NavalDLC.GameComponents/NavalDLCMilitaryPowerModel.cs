using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace NavalDLC.GameComponents;

public class NavalDLCMilitaryPowerModel : MilitaryPowerModel
{
	private static readonly Dictionary<PowerCalculationContext, float> _lightShipAttackerModifiers;

	private static readonly Dictionary<PowerCalculationContext, float> _lightShipDefenderModifiers;

	private static readonly Dictionary<PowerCalculationContext, float> _mediumShipAttackerModifiers;

	private static readonly Dictionary<PowerCalculationContext, float> _mediumShipDefenderModifiers;

	private static readonly Dictionary<PowerCalculationContext, float> _heavyShipAttackerModifiers;

	private static readonly Dictionary<PowerCalculationContext, float> _heavyShipDefenderModifiers;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPowerOfParty(PartyBase party, BattleSideEnum side, PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetContextModifier(CharacterObject troop, BattleSideEnum battleSideEnum, PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetContextModifier(Ship ship, BattleSideEnum battleSide, PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PowerCalculationContext GetContextForPosition(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDefaultTroopPower(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPowerModifierOfHero(Hero leaderHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTroopPower(CharacterObject troop, BattleSideEnum side, PowerCalculationContext context, float leaderModifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetLightShipContextModifier(Ship ship, BattleSideEnum battleSide, PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMediumShipContextModifier(Ship ship, BattleSideEnum battleSide, PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetHeavyShipContextModifier(Ship ship, BattleSideEnum battleSide, PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCMilitaryPowerModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NavalDLCMilitaryPowerModel()
	{
		throw null;
	}
}
