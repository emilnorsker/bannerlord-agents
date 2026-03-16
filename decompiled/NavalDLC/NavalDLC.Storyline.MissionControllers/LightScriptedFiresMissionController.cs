using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline.MissionControllers;

public class LightScriptedFiresMissionController : MissionLogic
{
	private const string FireTagExpression = "light_scripted_fire(_\\d+)*";

	private const float FireTimerAsSeconds = 3f;

	private Queue<GameEntity> _fireEntities;

	private MissionTimer _fireTimer;

	private bool _isFiringTriggered;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerFiring()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PutOutFires()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LightScriptedFiresMissionController()
	{
		throw null;
	}
}
