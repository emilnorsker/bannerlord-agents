using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.Map;

internal class LocatorGrid<T> where T : ILocatable<T>
{
	private const float DefaultGridNodeSize = 5f;

	private const int DefaultGridWidth = 32;

	private const int DefaultGridHeight = 32;

	private readonly T[] _nodes;

	private readonly float _gridNodeSize;

	private readonly int _width;

	private readonly int _height;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal LocatorGrid(float gridNodeSize = 5f, int gridWidth = 32, int gridHeight = 32)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int MapCoordinates(int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool CheckWhetherPositionsAreInSameNode(Vec2 pos1, ILocatable<T> locatable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool UpdateLocator(T locatable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveFromList(ILocatable<T> locatable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddToList(int nodeIndex, T locator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T FindLocatableOnNextNode(ref LocatableSearchData<T> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal T FindNextLocatable(ref LocatableSearchData<T> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal LocatableSearchData<T> StartFindingLocatablesAroundPosition(Vec2 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveLocatable(T locatable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetBoundaries(Vec2 position, float radius, out int minX, out int minY, out int maxX, out int maxY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetGridIndices(Vec2 position, out int x, out int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int Pos2NodeIndex(Vec2 position)
	{
		throw null;
	}
}
