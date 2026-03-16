using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class DefaultFormationArrangementModel : FormationArrangementModel
{
	private struct RelativeFormationPosition
	{
		public readonly bool FromLeftFile;

		public readonly int FileOffset;

		public readonly float FileFractionalOffset;

		public readonly bool FromFrontRank;

		public readonly int RankOffset;

		public readonly float RankFractionalOffset;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RelativeFormationPosition(bool fromLeftFile, int fileOffset, bool fromFrontRank, int rankOffset, float fileFractionalOffset = 0f, float rankFractionalOffset = 0f)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArrangementPosition GetArrangementPosition(int fileCount, int rankCount)
		{
			throw null;
		}
	}

	private static readonly RelativeFormationPosition[] BannerBearerLineFormationPositions;

	private static readonly RelativeFormationPosition[] BannerBearerCircularFormationPositions;

	private static readonly RelativeFormationPosition[] BannerBearerSkeinFormationPositions;

	private static readonly RelativeFormationPosition[] BannerBearerSquareFormationPositions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<ArrangementPosition> GetBannerBearerPositions(Formation formation, int maxCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool SearchOccupiedInLineFormation(LineFormation lineFormation, int fileIndex, int rankIndex, int fileCount, bool searchLeftToRight, out ArrangementPosition foundPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool SearchOccupiedFileRightToLeft(LineFormation lineFormation, int fileIndex, int rankIndex, ref ArrangementPosition foundPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool SearchOccupiedFileLeftToRight(LineFormation lineFormation, int fileIndex, int rankIndex, int fileCount, ref ArrangementPosition foundPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultFormationArrangementModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultFormationArrangementModel()
	{
		throw null;
	}
}
