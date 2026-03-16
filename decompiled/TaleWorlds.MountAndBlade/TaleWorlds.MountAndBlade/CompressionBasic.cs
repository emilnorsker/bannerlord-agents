using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public static class CompressionBasic
{
	public const float MaxPossibleAbsValueForSecondMaxQuaternionComponent = 0.7071068f;

	public const float MaxPositionZForCompression = 2521f;

	public const float MaxPositionForCompression = 10385f;

	public const float MinPositionForCompression = -100f;

	public const int MaxPeerCount = 511;

	public static CompressionInfo.Integer PingValueCompressionInfo;

	public static CompressionInfo.Integer LossValueCompressionInfo;

	public static CompressionInfo.Integer ServerPerformanceStateCompressionInfo;

	public static CompressionInfo.UnsignedInteger ColorCompressionInfo;

	public static CompressionInfo.Integer ItemDataValueCompressionInfo;

	public static CompressionInfo.Integer RandomSeedCompressionInfo;

	public static CompressionInfo.Float PositionCompressionInfo;

	public static CompressionInfo.Float LocalPositionCompressionInfo;

	public static CompressionInfo.Float LowResLocalPositionCompressionInfo;

	public static CompressionInfo.Float BigRangeLowResLocalPositionCompressionInfo;

	public static CompressionInfo.Integer PlayerCompressionInfo;

	public static CompressionInfo.UnsignedInteger PeerComponentCompressionInfo;

	public static CompressionInfo.UnsignedInteger GUIDCompressionInfo;

	public static CompressionInfo.Integer FlagsCompressionInfo;

	public static CompressionInfo.Integer GUIDIntCompressionInfo;

	public static CompressionInfo.Integer MissionObjectIDCompressionInfo;

	public static CompressionInfo.Float UnitVectorCompressionInfo;

	public static CompressionInfo.Float LowResRadianCompressionInfo;

	public static CompressionInfo.Float RadianCompressionInfo;

	public static CompressionInfo.Float HighResRadianCompressionInfo;

	public static CompressionInfo.Float UltResRadianCompressionInfo;

	public static CompressionInfo.Float ScaleCompressionInfo;

	public static CompressionInfo.Float LowResQuaternionCompressionInfo;

	public static CompressionInfo.Integer OmittedQuaternionComponentIndexCompressionInfo;

	public static CompressionInfo.Float ImpulseCompressionInfo;

	public static CompressionInfo.Integer AnimationKeyCompressionInfo;

	public static CompressionInfo.Float AnimationSpeedCompressionInfo;

	public static CompressionInfo.Float AnimationProgressCompressionInfo;

	public static CompressionInfo.Float VertexAnimationSpeedCompressionInfo;

	public static CompressionInfo.Integer PercentageCompressionInfo;

	public static CompressionInfo.Integer EntityChildCountCompressionInfo;

	public static CompressionInfo.Integer AgentHitDamageCompressionInfo;

	public static CompressionInfo.Integer AgentHitModifiedDamageCompressionInfo;

	public static CompressionInfo.Float AgentHitRelativeSpeedCompressionInfo;

	public static CompressionInfo.Integer AgentHitArmorCompressionInfo;

	public static CompressionInfo.Integer AgentHitBoneIndexCompressionInfo;

	public static CompressionInfo.Integer AgentHitBodyPartCompressionInfo;

	public static CompressionInfo.Integer AgentHitDamageTypeCompressionInfo;

	public static CompressionInfo.Integer RoundGoldAmountCompressionInfo;

	public static CompressionInfo.Integer DebugIntNonCompressionInfo;

	public static CompressionInfo.UnsignedLongInteger DebugULongNonCompressionInfo;

	public static CompressionInfo.Float AgentAgeCompressionInfo;

	public static CompressionInfo.Float FaceKeyDataCompressionInfo;

	public static CompressionInfo.Integer PlayerChosenBadgeCompressionInfo;

	public static CompressionInfo.Integer MaxNumberOfPlayersCompressionInfo;

	public static CompressionInfo.Integer MinNumberOfPlayersForMatchStartCompressionInfo;

	public static CompressionInfo.Integer MapTimeLimitCompressionInfo;

	public static CompressionInfo.Integer RoundTotalCompressionInfo;

	public static CompressionInfo.Integer RoundTimeLimitCompressionInfo;

	public static CompressionInfo.Integer WarmupTimeLimitCompressionInfo;

	public static CompressionInfo.Integer RoundPreparationTimeLimitCompressionInfo;

	public static CompressionInfo.Integer RespawnPeriodCompressionInfo;

	public static CompressionInfo.Integer GoldGainChangePercentageCompressionInfo;

	public static CompressionInfo.Integer SpectatorCameraTypeCompressionInfo;

	public static CompressionInfo.Integer PollAcceptThresholdCompressionInfo;

	public static CompressionInfo.Integer NumberOfBotsTeamCompressionInfo;

	public static CompressionInfo.Integer NumberOfBotsPerFormationCompressionInfo;

	public static CompressionInfo.Integer AutoTeamBalanceLimitCompressionInfo;

	public static CompressionInfo.Integer FriendlyFireDamageCompressionInfo;

	public static CompressionInfo.Integer ForcedAvatarIndexCompressionInfo;

	public static CompressionInfo.Integer IntermissionStateCompressionInfo;

	public static CompressionInfo.Float IntermissionTimerCompressionInfo;

	public static CompressionInfo.Integer IntermissionMapVoteItemCountCompressionInfo;

	public static CompressionInfo.Integer IntermissionVoterCountCompressionInfo;

	public static CompressionInfo.Integer ActionCodeCompressionInfo;

	public static CompressionInfo.Integer AnimationIndexCompressionInfo;

	public static CompressionInfo.Integer CultureIndexCompressionInfo;

	public static CompressionInfo.Integer SoundEventsCompressionInfo;

	public static CompressionInfo.Integer NetworkComponentEventTypeFromServerCompressionInfo;

	public static CompressionInfo.Integer NetworkComponentEventTypeFromClientCompressionInfo;

	public static CompressionInfo.Integer TroopTypeCompressionInfo;

	public static CompressionInfo.Integer BannerDataCountCompressionInfo;

	public static CompressionInfo.Integer BannerDataMeshIdCompressionInfo;

	public static CompressionInfo.Integer BannerDataColorIndexCompressionInfo;

	public static CompressionInfo.Integer BannerDataSizeCompressionInfo;

	public static CompressionInfo.Integer BannerDataRotationCompressionInfo;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CompressionBasic()
	{
		throw null;
	}
}
