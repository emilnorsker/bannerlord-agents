using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using SandBox.Objects.AnimationPoints;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline.Objects;

public class BurnShipObject : UsableMachine
{
	public float UseTime;

	private DynamicObjectAnimationPoint _machineUsePoint;

	private BlockedEstuaryMissionController _controller;

	private bool _hasUserCached;

	private bool _stateSet;

	private bool _used;

	private float _timer;

	public bool HasUser
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsDeactivated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BurnShipObject()
	{
		throw null;
	}
}
