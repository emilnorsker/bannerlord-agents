using System.Runtime.CompilerServices;
using NavalDLC.Missions.ShipActuators;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

public class ShipOarDeck : ScriptComponentBehavior
{
	public const string OarEntityName = "oar";

	public const string OarRetractedFrameEntityName = "retracted_frame";

	public const string RightOarMachinesHolderName = "right_oar_machines";

	public const string LeftOarMachinesHolderName = "left_oar_machines";

	public const string LeftOarGateTag = "oar_gate_left";

	public const string RightOarGateTag = "oar_gate_right";

	public const string HandTargetEntityName = "hand_position";

	public const string OarEntityTag = "oar_entity";

	public const string RetractedEntityTag = "retracted_entity";

	public const string HandTargetEntityTag = "hand_target_entity";

	public const string SeatLocationEntity = "seat_location_entity";

	public const string ShipBodyPhysicsEntityTag = "body_mesh";

	public const string SeatMeshTag = "seat_mesh_entity";

	[EditableScriptComponentVariable(true, "")]
	private float _verticalBaseAngle;

	[EditableScriptComponentVariable(true, "")]
	private float _lateralBaseAngle;

	[EditableScriptComponentVariable(true, "")]
	private float _verticalRotationAngle;

	[EditableScriptComponentVariable(true, "")]
	private float _lateralRotationAngle;

	private float _oarLength;

	private OarDeckParameters _oarDeckParameters;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OarDeckParameters GetParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateOarLength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WeakGameEntity GetOarEntity(WeakGameEntity oarScriptEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadOarScriptEntity(WeakGameEntity oarScriptEntity, out WeakGameEntity oarEntity, ref MatrixFrame oarExtractedEntitialFrame, ref MatrixFrame oarRetractedEntitialFrame, out WeakGameEntity handTargetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static WeakGameEntity GetRetractedFrameEntity(WeakGameEntity oarMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipOarDeck()
	{
		throw null;
	}
}
