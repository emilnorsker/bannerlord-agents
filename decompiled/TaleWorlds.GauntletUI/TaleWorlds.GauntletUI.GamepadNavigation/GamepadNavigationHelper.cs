using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.GamepadNavigation;

internal static class GamepadNavigationHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GetRelatedLineOfScope(GamepadNavigationScope scope, Vector2 fromPosition, GamepadNavigationTypes movement, out Vector2 lineBegin, out Vector2 lineEnd, out bool isFromWidget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GetRelatedLineOfWidget(Widget widget, GamepadNavigationTypes movement, out Vector2 lineBegin, out Vector2 lineEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float GetDistanceToClosestWidgetEdge(Widget widget, Vector2 point, GamepadNavigationTypes movement, out Vector2 closestPointOnEdge)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float GetDistanceToClosestWidgetEdge(Widget widget, Vector2 point, GamepadNavigationTypes movement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Vector2 GetClosestPointOnLineSegment(Vector2 lineBegin, Vector2 lineEnd, Vector2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static GamepadNavigationTypes GetMovementsToReachRectangle(Vector2 fromPosition, SimpleRectangle rect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Vector2 GetMovementVectorForNavigation(GamepadNavigationTypes navigationMovement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static GamepadNavigationScope GetClosestChildScopeAtDirection(GamepadNavigationScope parentScope, Vector2 fromPosition, GamepadNavigationTypes movement, bool checkForAutoGain, out float distanceToScope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static GamepadNavigationScope GetClosestScopeAtDirectionFromList(List<GamepadNavigationScope> scopesList, GamepadNavigationScope fromScope, Vector2 fromPosition, GamepadNavigationTypes movement, bool checkForAutoGain, out float distanceToScope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static GamepadNavigationScope GetClosestScopeFromList(List<GamepadNavigationScope> scopeList, Vector2 fromPosition, bool checkForAutoGain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static GamepadNavigationScope GetClosestScopeAtDirectionFromList(List<GamepadNavigationScope> scopesList, Vector2 fromPosition, GamepadNavigationTypes movement, bool checkForAutoGain, bool checkOnlyOneDirection, out float distanceToScope, params GamepadNavigationScope[] scopesToIgnore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float GetDirectionalDistanceBetweenTwoPoints(GamepadNavigationTypes movement, Vector2 p1, Vector2 p2)
	{
		throw null;
	}
}
