using System.Runtime.CompilerServices;
using NavalDLC.Missions.ShipActuators;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects.UsableMachines;

public class ShipUnmannedOar : ScriptComponentBehavior, IShipOarScriptComponent
{
	private GameEntity _oarEntity;

	private MatrixFrame _oarExtractedEntitialFrame;

	private MatrixFrame _oarRetractedEntitialFrame;

	private MissionOar _oar;

	private float _lastIdleTime;

	private DestructableComponent _destructableComponent;

	private BoundingBox _unmannedOarBaseBoundingBox;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeOar(MissionOar oar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ArrangeOarBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBoundingBoxValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckOarMachineFlags(bool editMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSlowDownPhaseForDuration(float slowDownMultiplier, float slowDownDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipUnmannedOar()
	{
		throw null;
	}
}
