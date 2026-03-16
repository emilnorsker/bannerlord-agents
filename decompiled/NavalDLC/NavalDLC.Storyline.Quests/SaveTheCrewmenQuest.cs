using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace NavalDLC.Storyline.Quests;

public class SaveTheCrewmenQuest : QuestBase
{
	private const string QuestFinishMenuId = "save_the_crewmen_placeholder_menu";

	public override string SpecialQuestType
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

	public override bool IsRemainingTimeHidden
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TextObject DescriptionLogText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveTheCrewmenQuest(string questId, Hero questGiver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetDialogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeQuestOnGameLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPlayerSavedCrewDialog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCrewSaved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CompleteQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naval_storyline_act_3_quest_1_setpiece_menu_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGangradir(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMainAgent(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsSavedCrew(IAgent agent)
	{
		throw null;
	}
}
