using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class WaveFloater : ScriptComponentBehavior
{
	public SimpleButton largeObject;

	public SimpleButton smallObject;

	public bool oscillateAtX;

	public bool oscillateAtY;

	public bool oscillateAtZ;

	public float oscillationFrequency;

	public float maxOscillationAngle;

	public bool bounceX;

	public float bounceXFrequency;

	public float maxBounceXDistance;

	public bool bounceY;

	public float bounceYFrequency;

	public float maxBounceYDistance;

	public bool bounceZ;

	public float bounceZFrequency;

	public float maxBounceZDistance;

	private Vec3 axis;

	private float oscillationSpeed;

	private float oscillationPercentage;

	private MatrixFrame resetMF;

	private MatrixFrame oscillationStart;

	private MatrixFrame oscillationEnd;

	private bool oscillate;

	private float bounceXSpeed;

	private float bounceXPercentage;

	private MatrixFrame bounceXStart;

	private MatrixFrame bounceXEnd;

	private float bounceYSpeed;

	private float bounceYPercentage;

	private MatrixFrame bounceYStart;

	private MatrixFrame bounceYEnd;

	private float bounceZSpeed;

	private float bounceZPercentage;

	private MatrixFrame bounceZStart;

	private MatrixFrame bounceZEnd;

	private bool bounce;

	private float et;

	private const float SPEED_MODIFIER = 1f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float ConvertToRadians(float angle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMatrix()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetMatrix()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateAxis()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateSpeed(float fq, float maxVal, bool angular)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateOscilations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Oscillate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateBounces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Bounce()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnSceneSave(string saveFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
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
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WaveFloater()
	{
		throw null;
	}
}
