using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.GauntletUI;

internal class EmptyWidget : Widget
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public EmptyWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdateBrushes(float dt)
	{
		throw null;
	}
}
