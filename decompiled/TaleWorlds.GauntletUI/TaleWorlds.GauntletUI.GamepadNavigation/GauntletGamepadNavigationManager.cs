using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.InputSystem;

namespace TaleWorlds.GauntletUI.GamepadNavigation;

public class GauntletGamepadNavigationManager
{
	private class GamepadNavigationContextComparer : IComparer<IGamepadNavigationContext>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(IGamepadNavigationContext x, IGamepadNavigationContext y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GamepadNavigationContextComparer()
		{
			throw null;
		}
	}

	private class ForcedScopeComparer : IComparer<GamepadNavigationForcedScopeCollection>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(GamepadNavigationForcedScopeCollection x, GamepadNavigationForcedScopeCollection y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ForcedScopeComparer()
		{
			throw null;
		}
	}

	private class ContextGamepadNavigationGainHandler
	{
		private readonly IGamepadNavigationContext _context;

		private float _gainAfterTime;

		private float _gainTimer;

		private int _gainAfterFrames;

		private int _frameTicker;

		private Func<bool> _gainPredicate;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ContextGamepadNavigationGainHandler(IGamepadNavigationContext eventManager)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GainNavigationAfterFrames(int frameCount, Func<bool> predicate = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GainNavigationAfterTime(float seconds, Func<bool> predicate = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Clear()
		{
			throw null;
		}
	}

	private IGamepadNavigationContext _latestCachedContext;

	private float _time;

	private bool _stopCursorNextFrame;

	private bool _isForcedCollectionsDirty;

	private GamepadNavigationContextComparer _cachedNavigationContextComparer;

	private ForcedScopeComparer _cachedForcedScopeComparer;

	private List<IGamepadNavigationContext> _sortedNavigationContexts;

	private Dictionary<IGamepadNavigationContext, GamepadNavigationScopeCollection> _navigationScopes;

	private List<GamepadNavigationScope> _availableScopesThisFrame;

	private List<GamepadNavigationScope> _unsortedScopes;

	private List<GamepadNavigationForcedScopeCollection> _forcedScopeCollections;

	private GamepadNavigationForcedScopeCollection _activeForcedScopeCollection;

	private GamepadNavigationScope _nextScopeToGainNavigation;

	private GamepadNavigationScope _activeNavigationScope;

	private Dictionary<Widget, List<GamepadNavigationScope>> _navigationScopeParents;

	private Dictionary<Widget, List<GamepadNavigationForcedScopeCollection>> _forcedNavigationScopeCollectionParents;

	private Dictionary<string, List<GamepadNavigationScope>> _layerNavigationScopes;

	private Dictionary<string, List<GamepadNavigationScope>> _navigationScopesById;

	private Dictionary<IGamepadNavigationContext, ContextGamepadNavigationGainHandler> _navigationGainControllers;

	private float _navigationHoldTimer;

	private Vector2 _lastNavigatedWidgetPosition;

	private readonly float _mouseCursorMoveTime;

	private Vector2 _cursorMoveStartPosition;

	private float _cursorMoveStartTime;

	private Widget _latestGamepadNavigationWidget;

	private List<Widget> _navigationBlockingWidgets;

	private bool _isAvailableScopesDirty;

	private bool _shouldUpdateAvailableScopes;

	private float _autoRefreshTimer;

	private bool _wasCursorInsideActiveScopeLastFrame;

	public static GauntletGamepadNavigationManager Instance
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

	private IGamepadNavigationContext LatestContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsTouchpadMouseEnabled
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

	public bool IsFollowingMobileTarget
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

	public bool IsHoldingDpadKeysForNavigation
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

	public bool IsCursorMovingForNavigation
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

	public bool IsInWrapMovement
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

	private Vector2 MousePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	private bool IsControllerActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal ReadOnlyDictionary<IGamepadNavigationContext, GamepadNavigationScopeCollection> NavigationScopes
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

	internal ReadOnlyDictionary<Widget, List<GamepadNavigationScope>> NavigationScopeParents
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

	internal ReadOnlyDictionary<Widget, List<GamepadNavigationForcedScopeCollection>> ForcedNavigationScopeParents
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

	public Widget LastTargetedWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool TargetedWidgetHasAction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AnyWidgetUsingNavigation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GauntletGamepadNavigationManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGamepadActiveStateChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryNavigateTo(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryNavigateTo(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnMovieLoaded(IGamepadNavigationContext context, string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnMovieReleased(IGamepadNavigationContext context, string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnContextAdded(IGamepadNavigationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnContextRemoved(IGamepadNavigationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnContextFinalized(IGamepadNavigationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vector2 GetTargetCursorPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshAvailableScopes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetUsedNavigationMovementsUpdated(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddForcedScopeCollection(GamepadNavigationForcedScopeCollection forcedCollection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveForcedScopeCollection(GamepadNavigationForcedScopeCollection collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddNavigationScope(IGamepadNavigationContext context, GamepadNavigationScope scope, bool initializeScope = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveNavigationScope(IGamepadNavigationContext context, GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetNavigationStatusChanged(IGamepadNavigationContext context, Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetNavigationIndexUpdated(IGamepadNavigationContext context, Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool HasNavigationScope(IGamepadNavigationContext context, GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool HasNavigationScope(IGamepadNavigationContext context, Func<GamepadNavigationScope, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnActiveScopeParentChanged(GamepadNavigationScope oldParent, GamepadNavigationScope newParent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScopeVisibilityChanged(GamepadNavigationScope scope, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnForcedScopeCollectionAvailabilityStateChanged(GamepadNavigationForcedScopeCollection scopeCollection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScopeNavigatableWidgetsChanged(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAllDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectScopesForForcedCollection(GamepadNavigationForcedScopeCollection collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeScope(IGamepadNavigationContext context, GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddItemToDictionaryList<TKey, TValue>(Dictionary<TKey, List<TValue>> sourceDict, TKey key, TValue item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveItemFromDictionaryList<TKey, TValue>(Dictionary<TKey, List<TValue>> sourceDict, TKey key, TValue item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetHoverBegin(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetHoverEnd(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnWidgetDisconnectedFromRoot(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetContextNavigationGainAfterTime(IGamepadNavigationContext context, float seconds, Func<bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetContextNavigationGainAfterFrames(IGamepadNavigationContext context, int frames, Func<bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnContextGainedNavigation(IGamepadNavigationContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetActiveNavigationScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGamepadNavigation(GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleGamepadNavigation(GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NavigateBetweenScopes(GamepadNavigationTypes movement, GamepadNavigationScope currentScope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NavigateWithinScope(GamepadNavigationScope scope, GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool SetCurrentNavigatedWidget(GamepadNavigationScope scope, Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MoveCursorToBestAvailableScope(bool isFromInput, GamepadNavigationTypes preferredMovement = GamepadNavigationTypes.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveCursorToFirstAvailableWidgetInScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveCursorToClosestAvailableWidgetInScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryMoveCursorToPreviousScope(GamepadNavigationForcedScopeCollection fromCollection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GamepadNavigationScope GetBestScopeAtDirectionFrom(GamepadNavigationScope fromScope, GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshExitMovementForScope(GamepadNavigationScope scope, GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GamepadNavigationTypes GetMovementForInput(InputKey input)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GamepadNavigationScope GetManualScopeAtDirection(GamepadNavigationTypes movement, GamepadNavigationScope fromScope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Widget GetBestWidgetToScope(GamepadNavigationScope fromScope, GamepadNavigationScope toScope, GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GamepadNavigationScope FindClosestParentScopeOfWidget(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GamepadNavigationForcedScopeCollection FindAvailableForcedScope()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCursorMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDpadNavigationStopped()
	{
		throw null;
	}
}
