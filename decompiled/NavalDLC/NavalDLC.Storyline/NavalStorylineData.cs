using System.Runtime.CompilerServices;
using NavalDLC.Storyline.Quests;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace NavalDLC.Storyline;

public class NavalStorylineData
{
	public enum NavalStorylineStage
	{
		None = -1,
		Act1,
		Act2,
		Act3Quest1,
		Act3Quest2,
		Act3SpeakToSailors,
		Act3Quest4,
		Act3Quest5,
		Act3SpeakToGunnarAndSister
	}

	public enum NavalStorylineCheckpoint
	{
		None,
		Act1PortMenu,
		Act1PortFightSucceeded,
		Act1CaptivitySucceeded,
		Act2EncounterMenu,
		Act2Finalized,
		Act3Quest1SetPieceEncounterMenu,
		Act3Quest1SetPieceSucceeded,
		Act3Quest2EncounterMenu,
		Act3Quest2Succeeded,
		Act3Quest3EncounterMenu,
		Act3Quest3Succeeded,
		Act3Quest3InterceptedMenu,
		Act3Quest4EncounterMenu,
		Act3Quest4Succeeded,
		Act3Quest5EncounterMenu,
		Act3Quest5MissionMenu,
		Act3Quest5Succeeded
	}

	public enum NavalStorylineSetPieceBattleMissionTypes
	{
		None = -1,
		Act1,
		Act2,
		Act3Quest1,
		Act3Quest2,
		Act3Quest3,
		Act3Quest4,
		Act3Quest5
	}

	public enum StorylineCancelDetail
	{
		ByDialogue,
		ByRansom
	}

	public const string NavalStorylineSpecialQuestType = "NavalStoryline";

	private const string NaukosStringId = "naval_storyline_naukos";

	private const string GangradirStringId = "naval_storyline_gangradir";

	private const string ValmissaStringId = "naval_storyline_valmissa";

	private const string BjolgurStringId = "naval_storyline_bjolgur";

	private const string PurigStringId = "naval_storyline_northerner";

	private const string EmiraAlFahdaStringId = "naval_storyline_emira_al_fahda";

	private const string LaharStringId = "naval_storyline_lahar";

	private const string PrusasStringId = "naval_storyline_crusas";

	public const string NavalStoryLineOutOfTownMenuId = "naval_storyline_outside_town";

	public const string NavalStoryLineEncounterBlockingMenuId = "naval_storyline_encounter_blocking";

	public const string NavalStoryLineVirtualPortMenuId = "naval_storyline_virtualport";

	public const string NavalStoryLineEncounterMeetingMenuId = "naval_storyline_encounter_meeting";

	public const string NavalStoryLineEncounterMenuId = "naval_storyline_encounter";

	public const string NavalStoryLineJoinEncounterMenuId = "naval_storyline_join_encounter";

	private const string HomeSettlementStringId = "town_V8";

	private const string Act3Quest1TargetSettlementStringId = "town_N1";

	private const string Act3Quest2TargetSettlementStringId = "town_A1";

	private const string Act3Quest3TargetSettlementStringId = "town_S3";

	private const string Act3Quest4TargetSettlementStringId = "town_V7";

	public const string GunnarsVillageStringId = "castle_village_N7_2";

	public const string InquireAtOsticanCharacterSpawnPointTag = "sp_storyline_npc";

	private Hero _naukos;

	private Hero _gangradir;

	private Hero _valmissa;

	private Hero _bjolgur;

	private Hero _purig;

	private Hero _lahar;

	private Hero _emiraAlFahda;

	private Hero _prusas;

	private Banner _corsairBanner;

	private Settlement _homeSettlement;

	private Settlement _act3Quest1TargetSettlement;

	private Settlement _act3Quest2TargetSettlement;

	private Settlement _act3Quest3TargetSettlement;

	private Settlement _act3Quest4TargetSettlement;

	public static Hero Naukos
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero Gangradir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero Valmissa
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero Bjolgur
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero Purig
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero Lahar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero EmiraAlFahda
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Hero Prusas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Settlement HomeSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Settlement Act3Quest1TargetSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Settlement Act3Quest2TargetSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Settlement Act3Quest3TargetSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Settlement Act3Quest4TargetSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Banner CorsairBanner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnCheckpointReached(NavalStorylineCheckpoint checkpoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheNavalStorylineSettlements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateStorylineHero(string stringId, out Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNavalStorylineHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartNavalStoryline()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsStorylineActivationPossible()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ActivateNavalStoryline()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeactivateNavalStoryline()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMainPartyAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsTutorialSkipped()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNavalStoryLineActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalStorylineSetPieceBattleMissionTypes GetNavalStorylineSetPieceBattleMissionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetNavalStorylineSetPieceBattleMissionType(NavalStorylineSetPieceBattleMissionTypes missionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsWaitingForSistersReturn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasCompletedLast(NavalStorylineStage stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalStorylineStage GetStorylineStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNavalStorylineCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnStorylineProgress(NavalStorylineQuestBase navalQuest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GiveProvisionsToPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddGangradirToMainParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TeleportMainHeroAndGangradirBackToBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FadeToBlack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionInitializerRecord GetNavalMissionInitializerTemplate(string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineData()
	{
		throw null;
	}
}
