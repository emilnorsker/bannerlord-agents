using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class WindMill : ScriptComponentBehavior
{
	public float rotationSpeed;

	public float waterSplashPhaseOffset;

	public float waterSplashIntervalMultiplier;

	public MetaMesh testMesh;

	public Texture testTexture;

	public GameEntity testEntity;

	public bool isWaterMill;

	private float currentRotation;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rotate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsRotationPhaseInsidePhaseBoundaries(float currentPhase, float startPhase, float endPhase)
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
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WindMill()
	{
		throw null;
	}
}
