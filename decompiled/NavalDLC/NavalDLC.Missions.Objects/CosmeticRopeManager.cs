using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace NavalDLC.Missions.Objects;

[ScriptComponentParams("ship_visual_only", "")]
public class CosmeticRopeManager : ScriptComponentBehavior
{
	private const string RopeScriptEntityTag = "simple_rope_start";

	private const float InvisibleDistanceSquared = 10000f;

	private const float LinearDistanceSquared = 2025f;

	private List<RopeSegment> _cosmeticsRopeSegments;

	private bool _ropesWereInvisibleLastFrame;

	private bool _ropesWereLinearLastFrame;

	private bool _lodCheckFirstFrame;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleLOD()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CosmeticRopeManager()
	{
		throw null;
	}
}
