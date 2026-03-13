using System;
using System.Collections.Generic;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.Behaviors.AIActions;

public abstract class AIActionBase
{
	public abstract string ActionName { get; }

	public abstract string Description { get; }

	protected Hero TargetHero { get; private set; }

	protected Agent TargetAgent { get; set; }

	public bool IsActive { get; protected set; }

	protected DateTime StartTime { get; private set; }

	public virtual void Initialize(Hero hero)
	{
		TargetHero = hero;
		StartTime = DateTime.Now;
		if (Mission.Current != null)
		{
			TargetAgent = FindAgentForHero(hero);
		}
		IsActive = false;
	}

	public virtual void Start()
	{
		if (!IsActive)
		{
			if (TargetHero == null)
			{
				LogError("Cannot start action: hero not set");
				return;
			}
			IsActive = true;
			StartTime = DateTime.Now;
			OnStart();
		}
	}

	public virtual void Stop()
	{
		if (IsActive)
		{
			IsActive = false;
			OnStop();
		}
	}

	public virtual void Update(float deltaTime)
	{
		if (IsActive)
		{
			if (Mission.Current != null && TargetAgent == null)
			{
				Hero targetHero = TargetHero;
				LogAction($"Update: Found mission, trying to find agent for {((targetHero != null) ? targetHero.Name : null)}");
				TargetAgent = FindAgentForHero(TargetHero);
				LogAction($"Update: Agent found: {TargetAgent != null}");
			}
			OnUpdate(deltaTime);
		}
	}

	public abstract bool CanExecute();

	protected abstract void OnStart();

	protected abstract void OnStop();

	protected abstract void OnUpdate(float deltaTime);

	protected Agent FindAgentForHero(Hero hero)
	{
		if (Mission.Current == null || hero == null)
		{
			LogAction("FindAgentForHero: Mission.Current is null or hero is null");
			return null;
		}
		LogAction($"FindAgentForHero: Searching for agent of {hero.Name} among {((List<Agent>)(object)Mission.Current.Agents).Count} agents");
		foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
		{
			if (item != null && item.IsHuman && !item.IsPlayerControlled)
			{
				LogAction($"FindAgentForHero: Checking agent {item.Name} (IsHuman: {item.IsHuman}, IsPlayerControlled: {item.IsPlayerControlled})");
				if (item.Character != null)
				{
					BasicCharacterObject character = item.Character;
					CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
					if (val != null)
					{
						TextObject name = ((BasicCharacterObject)val).Name;
						Hero heroObject = val.HeroObject;
						LogAction($"FindAgentForHero: Agent character is {name}, HeroObject: {((heroObject != null) ? heroObject.Name : null)}");
						if (val.HeroObject == hero)
						{
							LogAction($"FindAgentForHero: Found matching agent for {hero.Name}!");
							return item;
						}
						continue;
					}
				}
				LogAction("FindAgentForHero: Agent character is null or not CharacterObject");
			}
			else
			{
				LogAction($"FindAgentForHero: Skipping agent (null: {item == null}, IsHuman: {((item != null) ? new bool?(item.IsHuman) : ((bool?)null))}, IsPlayerControlled: {((item != null) ? new bool?(item.IsPlayerControlled) : ((bool?)null))})");
			}
		}
		LogAction($"FindAgentForHero: No agent found for {hero.Name}");
		return null;
	}

	protected Agent GetPlayerAgent()
	{
		Mission current = Mission.Current;
		return (current != null) ? current.MainAgent : null;
	}

	protected void LogAction(string message)
	{
		AIActionsLogger.Instance.Log("[" + ActionName + "] " + message);
	}

	protected void LogError(string message)
	{
		AIActionsLogger.Instance.Log("[" + ActionName + "] ERROR: " + message);
	}

	protected void ShowErrorMessage(TextObject message)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDebugLogging)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)message).ToString(), ExtraColors.RedAIInfluence));
		}
	}

	protected bool IsInMission()
	{
		return Mission.Current != null && TargetAgent != null;
	}

	protected bool IsInPlayerParty()
	{
		if (TargetHero == null || MobileParty.MainParty == null)
		{
			return false;
		}
		return TargetHero.PartyBelongedTo == MobileParty.MainParty;
	}

	public virtual Dictionary<string, string> GetStateDataForSave()
	{
		return null;
	}
}
