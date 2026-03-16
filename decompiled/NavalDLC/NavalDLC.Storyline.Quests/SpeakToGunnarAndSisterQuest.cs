using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace NavalDLC.Storyline.Quests;

public class SpeakToGunnarAndSisterQuest : QuestBase
{
	private const string GunnarsLongshipStringId = "northern_medium_ship";

	private const string Tier3NordInfantryStringId = "nord_spear_warrior";

	private const string Tier4NordInfantryStringId = "nord_vargr";

	private const int Tier3NordInfantryCount = 10;

	private const int Tier4NordInfantryCount = 10;

	[SaveableField(1)]
	private Quest5SetPieceBattleMissionController.BossFightOutComeEnum _bossFightOutcome;

	private TextObject _startLog
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

	public override string SpecialQuestType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpeakToGunnarAndSisterQuest(Quest5SetPieceBattleMissionController.BossFightOutComeEnum bossFightOutcome)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStartQuest()
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
	protected override void OnCompleteWithSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeDialogues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecideGunnarDialogue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeGunnarNotable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerWelcomedGunnarsCrew()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SisterFinalConversationConsequence()
	{
		throw null;
	}
}
