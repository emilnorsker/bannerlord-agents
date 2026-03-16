using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace NavalDLC.Storyline.Quests;

public class SetSailAndMeetTheFortuneSeekersInTargetSettlementQuest : NavalStorylineQuestBase
{
	public const float DistanceToSettlementToSpawnMerchantParty = 10f;

	private static readonly Dictionary<string, string> PlayerShipUpgradePieces;

	public const string PlayerPartySailPatternId = "generated_square__h4_09";

	[SaveableField(1)]
	private Settlement _targetSettlement;

	[SaveableField(2)]
	private bool _willProgressStoryline;

	public override bool WillProgressStoryline
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Title
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override NavalStorylineData.NavalStorylineStage Stage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override string MainPartyTemplateStringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject _descriptionLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SetSailAndMeetTheFortuneSeekersInTargetSettlementQuest(string questId, Hero questGiver, Settlement targetSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuestInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeQuestOnGameLoadInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEventsInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SetSailAndMeetTheFortuneSeekersInTargetSettlementQuest()
	{
		throw null;
	}
}
