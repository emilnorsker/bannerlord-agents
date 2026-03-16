using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.Objects.Cinematics;

public class SkeletonAnimatedCamera : ScriptComponentBehavior
{
	public string SkeletonName;

	public int BoneIndex;

	public Vec3 AttachmentOffset;

	public string AnimationName;

	public SimpleButton Restart;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateVisualizer()
	{
		throw null;
	}

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
	public SkeletonAnimatedCamera()
	{
		throw null;
	}
}
