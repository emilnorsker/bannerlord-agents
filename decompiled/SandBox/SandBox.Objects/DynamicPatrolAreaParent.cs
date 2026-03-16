using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects;

public class DynamicPatrolAreaParent : MissionObject
{
	public bool DrawPath;

	public int UniqueId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicPatrolAreaParent()
	{
		throw null;
	}
}
