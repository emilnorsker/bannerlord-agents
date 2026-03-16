using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map;

public class BlockadePositionScript : ScriptComponentBehavior
{
	public int MaximumNumberOfShips;

	public int NumberOfArcs;

	public float DistanceBetweenShips;

	public float DistanceRandomizationOnArcs;

	public float DistanceRandomizationBetweenArcs;

	public float Angle;

	public string MissionShipId;

	public float ShipScaleFactor;

	public bool IsVisualizationEnabled;

	public bool IsRandomizationEnabled;

	public bool IsShipVisualizationEnabled;

	public SimpleButton RefreshVisualization;

	private List<List<Vec3>> _pointsOfArcs;

	private Vec3 _center;

	private List<GameEntity> _shipEntities;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VisualizeArcs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<List<Vec3>> GetBlockadeArc(int totalNumberOfShips, out Vec3 center)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 FindCenterOfCircle(Vec3 arcPointStart, Vec3 arcPointEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockadePositionScript()
	{
		throw null;
	}
}
