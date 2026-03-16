using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class StandingPointWithWeaponRequirement : StandingPoint
{
	private ItemObject _requiredWeapon;

	private ItemObject _givenWeapon;

	private WeaponClass[] _requiredWeaponClasses;

	private bool _hasAlternative;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandingPointWithWeaponRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitRequiredWeaponClasses(WeaponClass[] requiredWeaponClasses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitRequiredWeapon(ItemObject weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitGivenWeapon(ItemObject weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHasAlternative(bool hasAlternative)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool HasAlternative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsingBattleSide(BattleSideEnum side)
	{
		throw null;
	}
}
