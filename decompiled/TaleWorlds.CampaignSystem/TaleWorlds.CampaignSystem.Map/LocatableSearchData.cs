using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.Map;

public struct LocatableSearchData<T>
{
	public readonly Vec2 Position;

	public readonly float RadiusSquared;

	public readonly int MinY;

	public readonly int MaxXInclusive;

	public readonly int MaxYInclusive;

	public int CurrentX;

	public int CurrentY;

	internal ILocatable<T> CurrentLocatable;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LocatableSearchData(Vec2 position, float radius, int minX, int minY, int maxX, int maxY)
	{
		throw null;
	}
}
