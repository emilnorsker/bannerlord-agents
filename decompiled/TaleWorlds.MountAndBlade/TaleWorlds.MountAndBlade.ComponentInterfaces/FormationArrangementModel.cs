using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ComponentInterfaces;

public abstract class FormationArrangementModel : MBGameModel<FormationArrangementModel>
{
	public struct ArrangementPosition
	{
		public readonly int FileIndex;

		public readonly int RankIndex;

		public bool IsValid
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public static ArrangementPosition Invalid
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ArrangementPosition(int fileIndex = -1, int rankIndex = -1)
		{
			throw null;
		}
	}

	public abstract List<ArrangementPosition> GetBannerBearerPositions(Formation formation, int maxCount);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected FormationArrangementModel()
	{
		throw null;
	}
}
