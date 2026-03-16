using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace NavalDLC.Storyline.Quests;

public class SailToTheGulfOfCharasQuest : NavalStorylineQuestBase
{
	private const string LaharShipHullId = "ship_liburna_q2_storyline";

	private static readonly Dictionary<string, string> LaharShipUpgradePieces;

	private const string GunnarShipHullId = "northern_medium_ship";

	private static readonly Dictionary<string, string> GunnarShipUpgradePieces;

	[SaveableField(1)]
	private readonly CampaignVec2 _corsairSpawnPosition;

	[SaveableField(2)]
	private readonly MapMarker _corsairHuntingGroundMarker;

	[SaveableField(3)]
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

	private TextObject QuestStartLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject QuestSuccessLogText
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SailToTheGulfOfCharasQuest(string questId, Hero questGiver, CampaignVec2 corsairSpawnPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuestInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void IsNavalQuestPartyInternal(PartyBase party, NavalStorylinePartyData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEventsInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalizeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCanceledInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeQuestParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddShipUpgradePieces(Ship ship, Dictionary<string, string> upgradePieces)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SailToTheGulfOfCharasQuest()
	{
		throw null;
	}
}
