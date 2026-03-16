using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.GamepadNavigation;

public class EmptyGamepadNavigationContext : IGamepadNavigationContext
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddForcedScopeCollection(GamepadNavigationForcedScopeCollection collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNavigationScope(GamepadNavigationScope scope, bool initialize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GainNavigationAfterFrames(int frameCount, Func<bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GainNavigationAfterTime(float seconds, Func<bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsBlockedAtPosition(Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetLastScreenOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasNavigationScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasNavigationScope(Func<GamepadNavigationScope, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAvailableForNavigation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGainNavigation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMovieLoaded(string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMovieReleased(string movieName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWidgetNavigationIndexUpdated(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWidgetNavigationStatusChanged(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWidgetUsedNavigationMovementsUpdated(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveForcedScopeCollection(GamepadNavigationForcedScopeCollection collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveNavigationScope(GamepadNavigationScope scope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EmptyGamepadNavigationContext()
	{
		throw null;
	}
}
