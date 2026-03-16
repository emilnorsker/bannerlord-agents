using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

internal class ShipClothFixer : ScriptComponentBehavior
{
	private struct ClothData
	{
		internal ClothSimulatorComponent ClothComponent;

		internal MatrixFrame ShipLocalFrame;
	}

	private List<ClothData> _shipCloths;

	private MatrixFrame _prevPrevShipFrame;

	private MatrixFrame _prevShipFrame;

	private float _fixedDt;

	private int _frameCounter;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ShipClothFixer()
	{
		throw null;
	}

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
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchClothComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPrevFrameToCloth(ClothData clothData)
	{
		throw null;
	}
}
