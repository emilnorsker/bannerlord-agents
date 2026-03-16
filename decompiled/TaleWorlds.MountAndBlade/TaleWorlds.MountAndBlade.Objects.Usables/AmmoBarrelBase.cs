using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Objects.Usables;

public abstract class AmmoBarrelBase : UsableMachine
{
	private readonly WeaponClass[] _requiredWeaponClasses;

	private int _pickupSoundFromBarrel;

	private bool _isVisible;

	private bool _needsSingleThreadTickOnce;

	private int PickupSoundFromBarrelCache
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AmmoBarrelBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	protected abstract WeaponClass[] GetRequiredWeaponClasses();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	protected abstract int GetSoundEvent();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	public abstract override TextObject GetDescriptionText(WeakGameEntity gameEntity);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickAux(bool isParallel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override OrderType GetOrder(BattleSideEnum side)
	{
		throw null;
	}
}
