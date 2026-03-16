using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class PopupSceneCameraPath : ScriptComponentBehavior
{
	public enum InterpolationType
	{
		Linear,
		EaseIn,
		EaseOut,
		EaseInOut
	}

	public struct PathAnimationState
	{
		public Path path;

		public string animationName;

		public float totalDistance;

		public float startTime;

		public float duration;

		public float alpha;

		public float easedAlpha;

		public bool fadeCamera;

		public InterpolationType interpolation;

		public string soundEvent;
	}

	public string LookAtEntity;

	public string SkeletonName;

	public int BoneIndex;

	public Vec3 AttachmentOffset;

	public string InitialPath;

	public string InitialAnimationClip;

	public string InitialSound;

	public float InitialPathStartTime;

	public float InitialPathDuration;

	public InterpolationType InitialInterpolation;

	public bool InitialFadeOut;

	public string PositivePath;

	public string PositiveAnimationClip;

	public string PositiveSound;

	public float PositivePathStartTime;

	public float PositivePathDuration;

	public InterpolationType PositiveInterpolation;

	public bool PositiveFadeOut;

	public string NegativePath;

	public string NegativeAnimationClip;

	public string NegativeSound;

	public float NegativePathStartTime;

	public float NegativePathDuration;

	public InterpolationType NegativeInterpolation;

	public bool NegativeFadeOut;

	private bool _isReady;

	public SimpleButton TestInitial;

	public SimpleButton TestPositive;

	public SimpleButton TestNegative;

	private MatrixFrame _localFrameIdentity;

	private GameEntity _lookAtEntity;

	private int _currentState;

	private float _cameraFadeValue;

	private List<PopupSceneSkeletonAnimationScript> _skeletonAnims;

	private SoundEvent _activeSoundEvent;

	private readonly PathAnimationState[] _transitionState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetState(int state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositiveState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNegativeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsReady(bool isReady)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCameraFade()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float InQuadBlend(float t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float OutQuadBlend(float t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float InOutQuadBlend(float t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame CreateLookAt(Vec3 position, Vec3 target, Vec3 upVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float Clamp(float x, float a, float b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float SmoothStep(float edge0, float edge1, float x)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera(float dt, ref PathAnimationState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
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
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PopupSceneCameraPath()
	{
		throw null;
	}
}
