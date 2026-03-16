using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks;
using TaleWorlds.AchievementSystem;

namespace TaleWorlds.PlatformService.Steam;

public class SteamAchievementService : IAchievementService
{
	private SteamPlatformServices _platform;

	private float _statsInvalidatedElapsed;

	private float _statsStoredElapsed;

	private Callback<UserStatsReceived_t> _userStatsReceivedT;

	private Callback<UserStatsStored_t> _userStatsStoredT;

	private bool _statsInitialized;

	private const int StatInvalidationInterval = 5;

	private const int StoreStatsInterval = 60;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SteamAchievementService(SteamPlatformServices steamPlatformServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAchievementService.SetStat(string name, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<int> IAchievementService.GetStat(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<int[]> IAchievementService.GetStats(string[] names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAchievementService.IsInitializationCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAchievementUnlocked(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearAchievement(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UserStatsReceived(UserStatsReceived_t userStatsReceivedT)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UserStatsStored(UserStatsStored_t userStatsStoredT)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool SetStat(string name, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Task<int> GetStat(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Task<int[]> GetStats(string[] names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvalidateStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StoreStats()
	{
		throw null;
	}
}
