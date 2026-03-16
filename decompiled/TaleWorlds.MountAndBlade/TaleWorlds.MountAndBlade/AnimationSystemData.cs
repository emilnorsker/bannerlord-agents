using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

[Serializable]
[EngineStruct("Animation_system_data", false, null)]
public struct AnimationSystemData
{
	public const sbyte InvalidBoneIndex = -1;

	public const sbyte NumBonesForIkMaxCount = 8;

	public const sbyte MaxCountOfRagdollBonesToCheckForCorpses = 11;

	public const sbyte RagdollFallSoundBoneIndexMaxCount = 4;

	public const sbyte RagdollStationaryCheckBoneMaxCount = 8;

	public const sbyte MoveAdderBoneMaxCount = 7;

	public const sbyte SplashDecalBoneMaxCount = 6;

	public const sbyte BloodBurstBoneMaxCount = 8;

	public const sbyte BoneIndicesToModifyOnSlopingGroundMaxCount = 7;

	[CustomEngineStructMemberData("action_set_no")]
	public MBActionSet ActionSet;

	public int NumPaces;

	public int MonsterUsageSetIndex;

	public float WalkingSpeedLimit;

	public float CrouchWalkingSpeedLimit;

	public float StepSize;

	[MarshalAs(UnmanagedType.U1)]
	public bool HasClippingPlane;

	public AnimationSystemBoneData Bones;

	[CustomEngineStructMemberData(true)]
	public AnimationSystemBoneDataBiped Biped;

	[CustomEngineStructMemberData(true)]
	public AnimationSystemDataQuadruped Quadruped;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AnimationSystemData GetHardcodedAnimationSystemDataForHumanSkeleton()
	{
		throw null;
	}
}
