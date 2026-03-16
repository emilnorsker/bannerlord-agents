using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace StoryMode.GameComponents.CampaignBehaviors;

public class StoryModeTutorialBoxCampaignBehavior : CampaignBehaviorBase
{
	private List<string> _shownTutorials;

	private readonly MBList<CampaignTutorial> _availableTutorials;

	private Dictionary<string, int> _tutorialBackup;

	public MBReadOnlyList<CampaignTutorial> AvailableTutorials
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeTutorialBoxCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTravelToVillageTutorialQuestStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestStarted(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTutorialCompleted(string completedTutorialType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTutorialListRequested(List<CampaignTutorial> campaignTutorials)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BackupTutorial(string tutorialTypeId, int priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTutorial(string tutorialTypeId, int priority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnResetAllTutorials(ResetAllTutorialsEvent obj)
	{
		throw null;
	}
}
