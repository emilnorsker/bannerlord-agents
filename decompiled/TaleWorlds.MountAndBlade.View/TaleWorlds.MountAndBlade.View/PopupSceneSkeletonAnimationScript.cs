using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View;

public class PopupSceneSkeletonAnimationScript : ScriptComponentBehavior
{
	public string SkeletonName;

	public int BoneIndex;

	public Vec3 AttachmentOffset;

	public string InitialAnimationClip;

	public string PositiveAnimationClip;

	public string NegativeAnimationClip;

	public string InitialAnimationContinueClip;

	public string PositiveAnimationContinueClip;

	public string NegativeAnimationContinueClip;

	private int _currentState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
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
	public void SetState(int state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PopupSceneSkeletonAnimationScript()
	{
		throw null;
	}
}
