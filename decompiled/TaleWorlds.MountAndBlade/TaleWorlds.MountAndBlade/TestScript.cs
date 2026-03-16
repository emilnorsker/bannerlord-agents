using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class TestScript : ScriptComponentBehavior
{
	public string testString;

	public float rotationSpeed;

	public float waterSplashPhaseOffset;

	public float waterSplashIntervalMultiplier;

	public bool isWaterMill;

	private float currentRotation;

	public float MoveAxisX;

	public float MoveAxisY;

	public float MoveAxisZ;

	public float MoveSpeed;

	public float MoveDistance;

	protected float MoveDirection;

	protected float CurrentDistance;

	public GameEntity sideRotatingEntity;

	public GameEntity forwardRotatingEntity;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Move(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rotate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool isRotationPhaseInsidePhaseBoundries(float currentPhase, float startPhase, float endPhase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetIntegerFromStringEnd(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoWaterMillCalculation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TestScript()
	{
		throw null;
	}
}
