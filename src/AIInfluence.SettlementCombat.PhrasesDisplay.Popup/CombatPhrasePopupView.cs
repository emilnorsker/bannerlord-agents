using System.Collections.Generic;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;

namespace AIInfluence.SettlementCombat.PhrasesDisplay.Popup;

public class CombatPhrasePopupView : MissionView
{
	private class PhraseEntry
	{
		public Agent Agent { get; }

		public float RemainingTime { get; set; }

		public CombatPhrasePopupItemVM Item { get; }

		public bool IsValid => Agent != null && Agent.IsActive() && Agent.Health > 0f;

		public PhraseEntry(Agent agent, float lifetime, CombatPhrasePopupItemVM item)
		{
			Agent = agent;
			RemainingTime = lifetime;
			Item = item;
		}
	}

	private const float DefaultLifetime = 5f;

	private GauntletLayer _layer;

	private CombatPhrasePopupVM _viewModel;

	private readonly List<PhraseEntry> _entries = new List<PhraseEntry>();

	public static CombatPhrasePopupView Instance { get; private set; }

	public override void OnMissionScreenInitialize()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((MissionView)this).OnMissionScreenInitialize();
		Instance = this;
		_viewModel = new CombatPhrasePopupVM();
		_layer = new GauntletLayer("GauntletLayer", 1, false);
		_layer.LoadMovie("PopUpDialogue", (ViewModel)(object)_viewModel);
		((ScreenLayer)_layer).IsFocusLayer = false;
		((ScreenLayer)_layer).InputRestrictions.SetInputRestrictions(false, (InputUsageMask)0);
		((ScreenBase)((MissionView)this).MissionScreen).AddLayer((ScreenLayer)(object)_layer);
	}

	public override void OnMissionScreenFinalize()
	{
		((MissionView)this).OnMissionScreenFinalize();
		if (_layer != null)
		{
			((ScreenBase)((MissionView)this).MissionScreen).RemoveLayer((ScreenLayer)(object)_layer);
			_layer = null;
		}
		_viewModel?.Dispose();
		_viewModel = null;
		_entries.Clear();
		Instance = null;
	}

	public override void OnMissionScreenTick(float dt)
	{
		((MissionView)this).OnMissionScreenTick(dt);
		if (_viewModel != null && ((MissionBehavior)this).Mission != null)
		{
			MissionScreen missionScreen = ((MissionView)this).MissionScreen;
			if (!((NativeObject)(object)((missionScreen != null) ? missionScreen.CombatCamera : null) == (NativeObject)null))
			{
				UpdateEntries(dt, ((MissionView)this).MissionScreen.CombatCamera);
			}
		}
	}

	public void ShowPhrase(Agent agent, string text, float lifetime = 5f)
	{
		if (_viewModel != null && agent != null && !string.IsNullOrWhiteSpace(text))
		{
			bool isEnemy = ((MissionBehavior)this).Mission.PlayerTeam != null && (agent.Team == null || agent.Team.IsEnemyOf(((MissionBehavior)this).Mission.PlayerTeam));
			CombatPhrasePopupItemVM item = new CombatPhrasePopupItemVM(agent, text, isEnemy);
			_viewModel.AddItem(item);
			_entries.Add(new PhraseEntry(agent, lifetime, item));
		}
	}

	private void UpdateEntries(float dt, Camera camera)
	{
		for (int num = _entries.Count - 1; num >= 0; num--)
		{
			PhraseEntry phraseEntry = _entries[num];
			phraseEntry.RemainingTime -= dt;
			if (!phraseEntry.IsValid)
			{
				RemoveEntryAt(num);
			}
			else
			{
				phraseEntry.Item.Update(camera);
				if (phraseEntry.RemainingTime <= 0f)
				{
					RemoveEntryAt(num);
				}
			}
		}
	}

	private void RemoveEntryAt(int index)
	{
		PhraseEntry phraseEntry = _entries[index];
		_entries.RemoveAt(index);
		_viewModel.RemoveItem(phraseEntry.Item);
	}

	public static void EnsureCreated()
	{
		if (Instance == null)
		{
			ScreenBase topScreen = ScreenManager.TopScreen;
			MissionScreen val = (MissionScreen)(object)((topScreen is MissionScreen) ? topScreen : null);
			if (val != null)
			{
				val.AddMissionView((MissionView)(object)new CombatPhrasePopupView());
			}
		}
	}
}
