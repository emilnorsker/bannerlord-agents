using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MissionReinforcementsHelper
{
	public enum ReinforcementFormationPriority
	{
		Dominant = 6,
		Common = 5,
		EmptyRepresentativeMatch = 4,
		EmptyNoMatch = 3,
		AlternativeDominant = 2,
		AlternativeCommon = 1,
		Default = 0
	}

	public class ReinforcementFormationPreferenceComparer : IComparer<ReinforcementFormationPriority>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(ReinforcementFormationPriority left, ReinforcementFormationPriority right)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ReinforcementFormationPreferenceComparer()
		{
			throw null;
		}
	}

	public class ReinforcementFormationData
	{
		private uint _initTime;

		private bool _isClassified;

		private int[] _expectedTroopCountPerClass;

		private int _expectedTotalTroopCount;

		private bool[] _troopClasses;

		private FormationClass _representativeClass;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ReinforcementFormationData()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize(Formation formation, uint initTime)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddProspectiveTroop(FormationClass troopClass)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsInitialized(uint initTime)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ReinforcementFormationPriority GetPriority(FormationClass troopClass)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Classify()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool HasTroopClass(FormationClass troopClass, out bool isDominant)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ResetClassAssignments()
		{
			throw null;
		}
	}

	private const float DominantClassThreshold = 0.5f;

	private const float CommonClassThreshold = 0.25f;

	private static uint _localInitTime;

	private static ReinforcementFormationData[,] _reinforcementFormationsData;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<(IAgentOriginBase origin, int formationIndex)> GetReinforcementAssignments(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnMissionEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Formation FindBestFormationAmong(TaleWorlds.Library.PriorityQueue<ReinforcementFormationPriority, Formation> matchingFormations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetFormationReinforcementScore(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionReinforcementsHelper()
	{
		throw null;
	}
}
