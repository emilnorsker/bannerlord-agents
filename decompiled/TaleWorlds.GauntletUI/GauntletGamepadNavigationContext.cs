using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.GamepadNavigation;

public class GauntletGamepadNavigationContext : IGamepadNavigationContext
{
	public readonly Func<Vector2, bool> OnGetIsBlockedAtPosition;

	public readonly Func<int> OnGetLastScreenOrder;

	public readonly Func<bool> OnGetIsAvailableForGamepadNavigation;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GauntletGamepadNavigationContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GauntletGamepadNavigationContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletGamepadNavigationContext(Func<Vector2, bool> onGetIsBlockedAtPosition, Func<int> onGetLastScreenOrder, Func<bool> onGetIsAvailableForGamepadNavigation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IGamepadNavigationContext.GetIsBlockedAtPosition(Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	int IGamepadNavigationContext.GetLastScreenOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IGamepadNavigationContext.IsAvailableForNavigation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnWidgetUsedNavigationMovementsUpdated(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnGainNavigation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.GainNavigationAfterFrames(int frameCount, Func<bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.GainNavigationAfterTime(float seconds, Func<bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnWidgetNavigationStatusChanged(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnWidgetNavigationIndexUpdated(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.AddNavigationScope(GamepadNavigationScope scope, bool initialize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.RemoveNavigationScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.AddForcedScopeCollection(GamepadNavigationForcedScopeCollection collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.RemoveForcedScopeCollection(GamepadNavigationForcedScopeCollection collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IGamepadNavigationContext.HasNavigationScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IGamepadNavigationContext.HasNavigationScope(Func<GamepadNavigationScope, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnMovieLoaded(string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGamepadNavigationContext.OnMovieReleased(string movieName)
	{
		throw null;
	}
}
