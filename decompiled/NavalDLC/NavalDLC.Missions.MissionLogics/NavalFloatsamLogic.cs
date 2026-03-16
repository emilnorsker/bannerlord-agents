using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class NavalFloatsamLogic : MissionLogic
{
	private struct FloatSamRecord
	{
		internal GameEntity FloatsamEntity;

		internal Timer DeSpawnTimer;
	}

	private struct FadingOutRecord
	{
		internal GameEntity FloatsamEntity;

		internal Timer FadeOutTimer;
	}

	private const int MaxNumberOfFloatsam = 40;

	private const float FloatsamAliveDuration = 15f;

	private const float FadeOutDuration = 1.5f;

	private Queue<FloatSamRecord> _orderedEntities;

	private Queue<FadingOutRecord> _fadingOutEntities;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalFloatsamLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

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
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterFloatsamInstance(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckFloatsamTimers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFadingOutEntities()
	{
		throw null;
	}
}
