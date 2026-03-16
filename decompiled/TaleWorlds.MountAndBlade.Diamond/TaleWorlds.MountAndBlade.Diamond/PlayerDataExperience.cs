using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

public struct PlayerDataExperience
{
	private static int[] _levelToXP;

	private static readonly int _maxLevelForXPRequirementCalculation;

	public int Experience
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

	public int Level
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int ExperienceToNextLevel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int ExperienceInCurrentLevel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PlayerDataExperience()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerDataExperience(int experience)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CalculateLevelFromExperience(int experience)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CalculateExperienceFromLevel(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ExperienceRequiredForLevel(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeXPRequirements()
	{
		throw null;
	}
}
