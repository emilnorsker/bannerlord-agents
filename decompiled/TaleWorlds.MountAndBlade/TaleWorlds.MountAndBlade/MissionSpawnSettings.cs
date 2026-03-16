using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public struct MissionSpawnSettings
{
	public enum ReinforcementSpawnMethod
	{
		Balanced,
		Wave,
		Fixed
	}

	public enum ReinforcementTimingMethod
	{
		GlobalTimer,
		CustomTimer
	}

	public enum InitialSpawnMethod
	{
		BattleSizeAllocating,
		FreeAllocation
	}

	public const float MinimumReinforcementInterval = 1f;

	public const float MinimumDefenderAdvantageFactor = 0.1f;

	public const float MaximumDefenderAdvantageFactor = 10f;

	public const float MinimumBattleSizeRatioLimit = 0.5f;

	public const float MaximumBattleSizeRatioLimit = 0.99f;

	public const float DefaultMaximumBattleSizeRatio = 0.75f;

	public const float DefaultDefenderAdvantageFactor = 1f;

	private float _globalReinforcementInterval;

	private float _defenderAdvantageFactor;

	private float _maximumBattleSizeRatio;

	private float _reinforcementBatchPercentage;

	private float _desiredReinforcementPercentage;

	private float _reinforcementWavePercentage;

	private int _maximumReinforcementWaveCount;

	private float _defenderReinforcementBatchPercentage;

	private float _attackerReinforcementBatchPercentage;

	public float GlobalReinforcementInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float DefenderAdvantageFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float MaximumBattleSideRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public InitialSpawnMethod InitialTroopsSpawnMethod
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public ReinforcementTimingMethod ReinforcementTroopsTimingMethod
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public ReinforcementSpawnMethod ReinforcementTroopsSpawnMethod
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public float ReinforcementBatchPercentage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float DesiredReinforcementPercentage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float ReinforcementWavePercentage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public int MaximumReinforcementWaveCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float DefenderReinforcementBatchPercentage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float AttackerReinforcementBatchPercentage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionSpawnSettings(InitialSpawnMethod initialTroopsSpawnMethod, ReinforcementTimingMethod reinforcementTimingMethod, ReinforcementSpawnMethod reinforcementTroopsSpawnMethod, float globalReinforcementInterval = 0f, float reinforcementBatchPercentage = 0f, float desiredReinforcementPercentage = 0f, float reinforcementWavePercentage = 0f, int maximumReinforcementWaveCount = 0, float defenderReinforcementBatchPercentage = 0f, float attackerReinforcementBatchPercentage = 0f, float defenderAdvantageFactor = 1f, float maximumBattleSizeRatio = 0.75f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionSpawnSettings CreateDefaultSpawnSettings()
	{
		throw null;
	}
}
