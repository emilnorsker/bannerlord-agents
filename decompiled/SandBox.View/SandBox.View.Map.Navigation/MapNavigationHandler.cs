using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SandBox.View.Map.Navigation;

public class MapNavigationHandler : INavigationHandler
{
	protected readonly Game _game;

	private INavigationElement[] _elements;

	public bool IsNavigationLocked
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsEscapeMenuActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public INavigationElement[] GetElements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapNavigationHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyElementActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual INavigationElement[] OnCreateElements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public INavigationElement GetElement(string id)
	{
		throw null;
	}
}
