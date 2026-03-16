using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.Objects.Cinematics;

public class CinematicBurningArrow : ScriptComponentBehavior
{
	private enum BurningArrowState
	{
		None,
		StartMovement,
		MovementInProgress,
		EndMovement
	}

	private const float Gravity = 9.8f;

	private BurningArrowState _state;

	private float _speedCache;

	[EditableScriptComponentVariable(true, "")]
	private float _speed;

	private Vec3 _speedVector;

	private float _arrowMovementTimer;

	private SoundEvent _arrowSound;

	private MatrixFrame _initialFrameCacheForShootArrowButton;

	private MatrixFrame _initialGlobalFrameCacheForShootArrowButton;

	public SimpleButton ShootArrow;

	public SimpleButton StopMovement;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
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
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetPositionAtTime(in Vec3 startPosition, in Vec3 speedVector, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Move(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LookAtWithZAsForward(ref MatrixFrame frame, Vec3 direction, Vec3 upVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CinematicBurningArrow()
	{
		throw null;
	}
}
