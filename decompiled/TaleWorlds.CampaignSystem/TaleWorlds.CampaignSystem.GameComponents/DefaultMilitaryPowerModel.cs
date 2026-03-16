using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultMilitaryPowerModel : MilitaryPowerModel
{
	[Flags]
	private enum PowerFlags
	{
		None = 0,
		Attacker = 1,
		Defender = 2,
		Infantry = 4,
		Archer = 8,
		Cavalry = 0x10,
		HorseArcher = 0x20,
		Siege = 0x40,
		Village = 0x80,
		RiverCrossing = 0x100,
		Forest = 0x200,
		Flat = 0x400
	}

	private const float LowTierCaptainPerkPowerBoost = 0.01f;

	private const float MidTierCaptainPerkPowerBoost = 0.02f;

	private const float HighTierCaptainPerkPowerBoost = 0.03f;

	private const float UltraTierCaptainPerkPowerBoost = 0.06f;

	private static readonly Dictionary<uint, float> _battleModifiers;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTroopPower(CharacterObject troop, BattleSideEnum side, MapEvent.PowerCalculationContext context, float leaderModifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPowerOfParty(PartyBase party, BattleSideEnum side, MapEvent.PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPowerModifierOfHero(Hero leaderHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetContextModifier(CharacterObject troop, BattleSideEnum battleSide, MapEvent.PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MapEvent.PowerCalculationContext GetContextForPosition(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDefaultTroopPower(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetContextModifier(Ship ship, BattleSideEnum battleSideEnum, MapEvent.PowerCalculationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PowerFlags GetTroopPowerContext(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PowerFlags GetBattleSideContext(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMilitaryPowerModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultMilitaryPowerModel()
	{
		throw null;
	}
}
