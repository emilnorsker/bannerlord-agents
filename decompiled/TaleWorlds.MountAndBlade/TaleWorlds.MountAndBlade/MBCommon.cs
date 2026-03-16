using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

public class MBCommon
{
	public enum GameType
	{
		Single,
		MultiClient,
		MultiServer,
		MultiClientServer,
		SingleReplay,
		SingleRecord
	}

	[EngineStruct("rglTimer_type", false, null)]
	public enum TimeType
	{
		[CustomEngineStructMemberData("Real_timer")]
		Application,
		[CustomEngineStructMemberData("Tactical_timer")]
		Mission
	}

	private static GameType _currentGameType;

	public static GameType CurrentGameType
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

	public static bool IsDebugMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsPaused
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PauseGameEngine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UnPauseGameEngine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetApplicationTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetTotalMissionTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FixSkeletons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckResourceModifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int Hash(int i, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBCommon()
	{
		throw null;
	}
}
