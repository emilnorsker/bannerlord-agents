using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public class MissionFaceCacheView : MissionView
{
	private struct CacheRecord
	{
		public BodyProperties BodyProperties;

		public int CacheID;

		public FaceGenerationParams FaceParamsForSimilarity;

		public HairCoverTypes HairCover;

		public BeardCoverTypes BeardCover;
	}

	private int _totalFaceBudget;

	private int _uniqueCacheIndex;

	private float _currentSimilarityThreshold;

	private float _currentRandomSwitchChance;

	private KeyValuePair<float, float>[] _comprasionThresholdsWrtEmptyBudget;

	private List<CacheRecord> _alreadyAssignedFaces;

	private MBFastRandom _randomGenerator;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionFaceCacheView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float ComputeSimilarityOfFace(FaceGenerationParams f0, FaceGenerationParams f1, HairCoverTypes hairCover1, HairCoverTypes hairCover2, BeardCoverTypes beardCover1, BeardCoverTypes beardCover2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CheckForSimilarFacesFromCache(FaceGenerationParams newFaceGen, HairCoverTypes hairCoverType, BeardCoverTypes beardCoverType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateFaceSimilarityThreshold()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BodyProperties GetRandomBodyPropertyForTroop(AgentBuildData agentBuildData, BasicCharacterObject characterObject, Equipment equipment, int seed)
	{
		throw null;
	}
}
