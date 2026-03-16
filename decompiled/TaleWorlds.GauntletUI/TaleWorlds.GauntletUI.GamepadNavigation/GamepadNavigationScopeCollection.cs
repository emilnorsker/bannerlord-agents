using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.GauntletUI.GamepadNavigation;

internal class GamepadNavigationScopeCollection
{
	private Action<GamepadNavigationScope> _onScopeNavigatableWidgetsChanged;

	private Action<GamepadNavigationScope, bool> _onScopeVisibilityChanged;

	private List<GamepadNavigationScope> _allScopes;

	private List<GamepadNavigationScope> _uninitializedScopes;

	private List<GamepadNavigationScope> _visibleScopes;

	private List<GamepadNavigationScope> _invisibleScopes;

	private List<GamepadNavigationScope> _dirtyScopes;

	public IGamepadNavigationContext Source
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public ReadOnlyCollection<GamepadNavigationScope> AllScopes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public ReadOnlyCollection<GamepadNavigationScope> UninitializedScopes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public ReadOnlyCollection<GamepadNavigationScope> VisibleScopes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public ReadOnlyCollection<GamepadNavigationScope> InvisibleScopes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GamepadNavigationScopeCollection(IGamepadNavigationContext source, Action<GamepadNavigationScope> onScopeNavigatableWidgetsChanged, Action<GamepadNavigationScope, bool> onScopeVisibilityChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void HandleScopeVisibilities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScopeVisibilityChanged(GamepadNavigationScope scope, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScopeNavigatableWidgetsChanged(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetTotalNumberOfScopes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool HasScopeInAnyList(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnNavigationScopeInitialized(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetDisconnectedFromRoot(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearAllScopes()
	{
		throw null;
	}
}
