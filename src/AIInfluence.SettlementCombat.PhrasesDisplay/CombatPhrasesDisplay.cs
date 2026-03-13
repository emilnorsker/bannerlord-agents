using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.SettlementCombat.PhrasesDisplay.Popup;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.SettlementCombat.PhrasesDisplay;

public class CombatPhrasesDisplay : MissionLogic
{
	private readonly CombatSituationAnalysis _analysis;

	private List<string> _malePanicPhrases;

	private List<string> _maleFightPhrases;

	private List<string> _femalePhrases;

	private List<string> _childPhrases;

	private readonly SettlementCombatLogger _logger;

	private HashSet<Agent> _agentsWhoSpoke = new HashSet<Agent>();

	private HashSet<string> _usedPhrases = new HashSet<string>();

	private const float ACTIVATION_DISTANCE = 15f;

	private const float PHRASE_COOLDOWN = 5f;

	private MissionTime _nextPhraseAllowedTime = MissionTime.Zero;

	private bool _initialized = false;

	private float _tickTimer = 0f;

	public CombatPhrasesDisplay(CombatSituationAnalysis analysis)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		_analysis = analysis;
		_logger = SettlementCombatLogger.Instance;
		_initialized = true;
		_malePanicPhrases = ((_analysis?.CivilianPhrasesMalePanic != null) ? new List<string>(_analysis.CivilianPhrasesMalePanic) : new List<string>());
		_maleFightPhrases = ((_analysis?.CivilianPhrasesMaleFight != null) ? new List<string>(_analysis.CivilianPhrasesMaleFight) : new List<string>());
		_femalePhrases = ((_analysis?.CivilianPhrasesFemale != null) ? new List<string>(_analysis.CivilianPhrasesFemale) : new List<string>());
		_childPhrases = ((_analysis?.CivilianPhrasesChild != null) ? new List<string>(_analysis.CivilianPhrasesChild) : new List<string>());
		_logger.Log($"CombatPhrasesDisplay: Initialized (phrases: {_malePanicPhrases.Count} male panic, {_maleFightPhrases.Count} male fight, {_femalePhrases.Count} female, {_childPhrases.Count} child)");
	}

	public override void AfterStart()
	{
		((MissionBehavior)this).AfterStart();
		CombatPhrasePopupView.EnsureCreated();
	}

	public override void OnMissionTick(float dt)
	{
		((MissionBehavior)this).OnMissionTick(dt);
		if (!_initialized || _analysis == null || Agent.Main == null)
		{
			return;
		}
		try
		{
			_tickTimer += dt;
			if (!(_tickTimer < 0.5f))
			{
				_tickTimer = 0f;
				CheckAgentsForPhraseActivation();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CombatPhrasesDisplay.OnMissionTick", ex.Message, ex);
		}
	}

	private void CheckAgentsForPhraseActivation()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		if (Mission.Current == null || MissionTime.Now < _nextPhraseAllowedTime)
		{
			return;
		}
		PlayerReinforcementMissionLogic missionBehavior = Mission.Current.GetMissionBehavior<PlayerReinforcementMissionLogic>();
		Vec3 position = Agent.Main.Position;
		foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
		{
			if (item == null || !item.IsActive() || !item.IsHuman || item == Agent.Main || _agentsWhoSpoke.Contains(item) || (missionBehavior != null && missionBehavior.IsSummonedTroop(item)) || item.Team == Mission.Current.PlayerTeam)
			{
				continue;
			}
			Vec3 position2 = item.Position;
			float num = ((Vec3)(ref position2)).Distance(position);
			if (num <= 15f)
			{
				string phraseForAgent = GetPhraseForAgent(item);
				if (!string.IsNullOrEmpty(phraseForAgent))
				{
					InformationManager.DisplayMessage(new InformationMessage(item.Name + ": \"" + phraseForAgent + "\"", Colors.Gray));
					CombatPhrasePopupView.Instance?.ShowPhrase(item, phraseForAgent);
					_agentsWhoSpoke.Add(item);
					_nextPhraseAllowedTime = MissionTime.SecondsFromNow(5f);
					_logger.Log($"Phrase: {item.Name} ({num:F1}m) - \"{phraseForAgent}\" (global cooldown reset to {5f}s)");
					break;
				}
			}
		}
	}

	private string GetPhraseForAgent(Agent agent)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		BasicCharacterObject character = agent.Character;
		CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
		if (val == null)
		{
			return null;
		}
		List<string> list = null;
		list = ((((BasicCharacterObject)val).Age < 18f) ? _childPhrases : ((!((BasicCharacterObject)val).IsFemale) ? (((int)val.Occupation == 7 || (int)val.Occupation == 2 || (int)val.Occupation == 15) ? _maleFightPhrases : _malePanicPhrases) : _femalePhrases));
		if (list == null || !list.Any())
		{
			return null;
		}
		List<string> list2 = list.Where((string p) => !_usedPhrases.Contains(p)).ToList();
		if (!list2.Any())
		{
			return null;
		}
		Random random = new Random(agent.Index + _usedPhrases.Count);
		int index = random.Next(list2.Count);
		string text = list2[index];
		_usedPhrases.Add(text);
		return text;
	}

	public override void OnRemoveBehavior()
	{
		((MissionBehavior)this).OnRemoveBehavior();
		try
		{
			_agentsWhoSpoke.Clear();
			_usedPhrases.Clear();
			_logger.Log("CombatPhrasesDisplay: Cleanup completed");
		}
		catch (Exception ex)
		{
			_logger.LogError("CombatPhrasesDisplay.OnRemoveBehavior", ex.Message, ex);
		}
	}
}
