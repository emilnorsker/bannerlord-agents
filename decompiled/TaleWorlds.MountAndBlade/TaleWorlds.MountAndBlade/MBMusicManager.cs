using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class MBMusicManager
{
	private class CampaignMusicMode
	{
		private const float DefaultSelectionFactorForFactionSpecificCampaignTheme = 0.35f;

		private const float SelectionFactorDecayAmountForFactionSpecificCampaignTheme = 0.1f;

		private const float SelectionFactorGrowthAmountForFactionSpecificCampaignTheme = 0.1f;

		private float _factionSpecificCampaignThemeSelectionFactor;

		private float _factionSpecificCampaignDramaticThemeSelectionFactor;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CampaignMusicMode()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MusicTheme GetCampaignTheme(BasicCultureObject culture, bool isDark)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MusicTheme GetCampaignThemeWithCulture(BasicCultureObject culture)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MusicTheme GetCampaignDramaticThemeWithCulture(BasicCultureObject culture)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MusicTheme GetSeaCampignMusic(BasicCultureObject culture)
		{
			throw null;
		}
	}

	private class BattleMusicMode
	{
		private const float DefaultSelectionFactorForFactionSpecificBattleTheme = 0.35f;

		private const float SelectionFactorDecayAmountForFactionSpecificBattleTheme = 0.1f;

		private const float SelectionFactorGrowthAmountForFactionSpecificBattleTheme = 0.1f;

		private const float DefaultSelectionFactorForFactionSpecificVictoryTheme = 0.65f;

		private float _factionSpecificBattleThemeSelectionFactor;

		private float _factionSpecificSiegeThemeSelectionFactor;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BattleMusicMode()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MusicTheme GetBattleThemeWithCulture(BasicCultureObject culture, out bool isPaganBattle)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MusicTheme GetSiegeThemeWithCulture(BasicCultureObject culture)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MusicTheme GetVictoryThemeForCulture(BasicCultureObject culture)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MusicTheme GetBattleTheme(BasicCultureObject culture, int battleSize, out bool isPaganBattle)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MusicTheme GetSiegeTheme(BasicCultureObject culture)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MusicTheme GetBattleEndTheme(BasicCultureObject culture, bool isVictorious)
		{
			throw null;
		}
	}

	private const string CultureEmpire = "empire";

	private const string CultureSturgia = "sturgia";

	private const string CultureAserai = "aserai";

	private const string CultureVlandia = "vlandia";

	private const string CultureBattania = "battania";

	private const string CultureKhuzait = "khuzait";

	private const string CultureNord = "nord";

	private const float DefaultFadeOutDurationInSeconds = 3f;

	private const float MenuModeActivationTimerInSeconds = 0.5f;

	private BattleMusicMode _battleMode;

	private CampaignMusicMode _campaignMode;

	private IMusicHandler _campaignMusicHandler;

	private IMusicHandler _battleMusicHandler;

	private IMusicHandler _silencedMusicHandler;

	private IMusicHandler _activeMusicHandler;

	private static bool _initialized;

	private static bool _creationCompleted;

	private float _menuModeActivationTimer;

	private bool _systemPaused;

	private int _latestFrameUpdatedNo;

	public static MBMusicManager Current
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

	public MusicMode CurrentMode
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
	private MBMusicManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsCreationCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ProcessCreation(object callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCampaignMusicHandlerInit(IMusicHandler campaignMusicHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCampaignMusicHandlerFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBattleMusicHandlerInit(IMusicHandler battleMusicHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBattleMusicHandlerFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSilencedMusicHandlerInit(IMusicHandler silencedMusicHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSilencedMusicHandlerFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckActiveHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateMenuMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateMenuMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateBattleMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateBattleMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateCampaignMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateCampaignMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateCurrentMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckMenuModeActivationTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnpauseMusicManagerSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseMusicManagerSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartTheme(MusicTheme theme, float startIntensity, bool queueEndSegment = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartThemeWithConstantIntensity(MusicTheme theme, bool queueEndSegment = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceStopThemeWithFadeOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeCurrentThemeIntensity(float deltaIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicTheme GetSiegeTheme(BasicCultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicTheme GetBattleTheme(BasicCultureObject culture, int battleSize, out bool isPaganBattle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicTheme GetBattleEndTheme(BasicCultureObject culture, bool isVictory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicTheme GetBattleTurnsOneSideTheme(BasicCultureObject culture, bool isPositive, bool isPaganBattle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicTheme GetCampaignMusicTheme(BasicCultureObject culture, bool isDark, bool isWarMode, bool isAtSea)
	{
		throw null;
	}
}
