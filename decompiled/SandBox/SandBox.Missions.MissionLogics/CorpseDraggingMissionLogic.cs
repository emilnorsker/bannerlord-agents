using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class CorpseDraggingMissionLogic : MissionLogic, IPlayerInputEffector, IMissionBehavior
{
	private enum CrouchStandEvent
	{
		None,
		Crouch,
		Stand
	}

	private enum GroundMaterialCorpseDrag
	{
		Default,
		Fabric,
		Grass,
		Mud,
		Sand,
		Snow,
		Stone,
		Water,
		Wood
	}

	private static readonly Dictionary<string, GroundMaterialCorpseDrag> _corpseDragMateriels;

	private static int _bodyDragSoundEventId;

	private Agent _draggedCorpse;

	private bool _startedPickingUpDraggedCorpse;

	private bool _triggerBodyGrabSound;

	private Vec3 _draggedCorpseAverageVelocity;

	private Vec3 _draggedCorpseBoneLastGlobalPosition;

	private sbyte _draggedCorpseBoneIndex;

	private float _draggedCorpseUnbindDistanceSquared;

	private EquipmentIndex _draggedCorpseCarrierLastWieldedPrimaryWeaponIndex;

	private bool _draggedCorpseCarrierLastCrouchState;

	private bool _previousActionKeyPressed;

	private CrouchStandEvent _crouchStandEvent;

	private SoundEvent _bodyDragSoundEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetFocusableObjectInteractionInfoTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDraggedCorpse(Agent draggedCorpse, sbyte draggedCorpseBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFixedMissionTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsThereAgentAction(Agent userAgent, Agent otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentInteraction(Agent userAgent, Agent agent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EventControlFlag OnCollectPlayerEventControlFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CorpseDraggingMissionLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CorpseDraggingMissionLogic()
	{
		throw null;
	}
}
