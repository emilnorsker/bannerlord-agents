using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.GauntletUI;

internal class WidgetContainer
{
	internal enum ContainerType
	{
		Update,
		ParallelUpdate,
		LateUpdate,
		VisualDefinition,
		UpdateBrushes
	}

	private HashSet<Widget> _backList;

	private MBList<Widget> _frontList;

	private bool _isFragmented;

	internal int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal WidgetContainer(int initialCapacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Add(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Remove(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<Widget> GetActiveList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Defrag()
	{
		throw null;
	}
}
