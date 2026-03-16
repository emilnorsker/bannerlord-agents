using System.Runtime.CompilerServices;
using NavalDLC.Storyline.Quests;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace NavalDLC.Storyline.CampaignBehaviors;

public class NavalStorylineTravelCommentaryCampaignBehavior : CampaignBehaviorBase
{
	private CampaignVec2 RansLaundryLocation;

	private CampaignVec2 FinisterreLocation;

	private CampaignVec2 RookBirdLocation;

	private CampaignVec2 TrandEstuaryLocation;

	private CampaignVec2 GulfOfCharasLocation;

	private CampaignVec2 GarantorCastleLocation;

	private CampaignVec2 MarzoporLocation;

	private CampaignVec2 GalendLocation;

	private CampaignVec2 AngrafjordLocation;

	private CampaignVec2 ByalicLocation;

	private NavalStorylineCampaignBehavior _storylineBehavior;

	private NavalStorylineQuestBase _activeQuest;

	private CampaignTime _finisterCooldown;

	private CampaignTime _byalicCooldown;

	private CampaignTime _rookCooldown;

	private CampaignTime _ransLaundryCooldown;

	private CampaignTime _trandEstuaryCooldown;

	private CampaignTime _charasCooldown;

	private CampaignTime _garantorCastleCooldown;

	private CampaignTime _mazoporCooldown;

	private CampaignTime _galendCooldown;

	private bool DidShowAct2Commentary;

	private bool DidShowAct3Q1Commentary1;

	private bool DidShowAct3Q1Commentary2;

	private bool DidShowAct3Q2Commentary;

	private bool DidShowAct3Q3Commentary;

	private bool DidShowAct3Q4Commentary;

	private bool DidShowAct3Q5Commentary;

	private CampaignTime _nextGoToPortEventTime;

	private bool CanShowLowFoodCommentary;

	private bool CanShowLowShipHpCommentary;

	private bool CanShowLowTroopsAndShipsCommentary;

	private bool CanShowStormCommentary;

	private bool CanShowNearOsticanCommentary;

	private bool CanShowReturnToOsticanInAct1;

	private float ImportantLocationLargeRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float CommentarySettlementArrivalRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float SkatriaRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float ByalicRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float GarantorRadius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private NavalStorylineCampaignBehavior StorylineBehavior
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsStorylineActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private NavalStorylineData.NavalStorylineStage CurrentStage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionEndedEvent(IMission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestStarted(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QuarterlyHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsLowOnTroopsOrShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanComment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddNotification(TextObject text, NotificationPriority priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsNearLocation(CampaignVec2 location, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsNearSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMainPartyInStorm()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineTravelCommentaryCampaignBehavior()
	{
		throw null;
	}
}
