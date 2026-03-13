using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class DiseaseCombatModifierPatch
{
	public class DiseaseAgentComponent : AgentComponent
	{
		public MobileParty Party { get; set; }

		public bool IsHeroAgent { get; set; }

		public DiseaseAgentComponent(Agent agent)
			: base(agent)
		{
		}

		public override void OnAgentRemoved()
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Invalid comparison between Unknown and I4
			try
			{
				if ((int)base.Agent.State != 4 || IsHeroAgent || Party == null || DiseaseManager.Instance == null)
				{
					return;
				}
				List<DiseaseInstance> partyDiseases = DiseaseManager.Instance.GetPartyDiseases(Party);
				if (partyDiseases == null || partyDiseases.Count == 0)
				{
					return;
				}
				BasicCharacterObject character = base.Agent.Character;
				BasicCharacterObject obj = ((character is CharacterObject) ? character : null);
				int tier = ((obj == null) ? 1 : ((CharacterObject)obj).Tier);
				foreach (DiseaseInstance item in partyDiseases)
				{
					if (item.GetTroopCountInTier(tier) > 0)
					{
						item.RemoveTroopsFromTier(tier, 1);
						return;
					}
				}
				DiseaseInstance diseaseInstance = partyDiseases.OrderByDescending((DiseaseInstance d) => d.InfectedTroopCount).FirstOrDefault();
				if (diseaseInstance != null && diseaseInstance.InfectedTroopCount > 0)
				{
					diseaseInstance.InfectedTroopCount = Math.Max(0, diseaseInstance.InfectedTroopCount - 1);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[HarmonyPatch]
	public static class InitAgentStatsPatch
	{
		[HarmonyPrepare]
		private static bool Prepare()
		{
			return TargetMethod() != null;
		}

		[HarmonyTargetMethod]
		private static MethodBase TargetMethod()
		{
			Type type = AccessTools.TypeByName("SandBox.GameComponents.SandboxAgentStatCalculateModel");
			if (type == null)
			{
				return null;
			}
			return AccessTools.Method(type, "InitializeAgentStats", (Type[])null, (Type[])null);
		}

		[HarmonyPostfix]
		public static void Postfix(Agent agent, AgentDrivenProperties agentDrivenProperties)
		{
			try
			{
				if (agent == null || !agent.IsHuman)
				{
					return;
				}
				ModSettings instance = GlobalSettings<ModSettings>.Instance;
				if (instance == null || !instance.EnableDiseaseSystem || DiseaseManager.Instance == null)
				{
					return;
				}
				if (Mission.Current != _lastMission)
				{
					ClearAll();
					_lastMission = Mission.Current;
				}
				bool flag = false;
				CombatModifiers combatModifiers = null;
				MobileParty val = null;
				bool isHeroAgent = false;
				Hero heroFromAgent = GetHeroFromAgent(agent);
				if (heroFromAgent != null)
				{
					isHeroAgent = true;
					if (DiseaseManager.Instance.IsHeroInfected(heroFromAgent))
					{
						flag = true;
						combatModifiers = DiseaseEffectSystem.GetHeroDiseaseEffects(heroFromAgent)?.CombatModifiers;
					}
				}
				else
				{
					val = GetPartyFromAgent(agent);
					if (val != null && ShouldTroopBeInfected(val))
					{
						flag = true;
						combatModifiers = DiseaseEffectSystem.GetPartyTroopDiseaseEffects(val)?.CombatModifiers;
					}
				}
				if (flag && combatModifiers != null)
				{
					_infectedAgents.Add(agent);
					_agentEffects[agent] = combatModifiers;
					DiseaseAgentComponent diseaseAgentComponent = new DiseaseAgentComponent(agent)
					{
						Party = val,
						IsHeroAgent = isHeroAgent
					};
					agent.AddComponent((AgentComponent)(object)diseaseAgentComponent);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[HarmonyPatch]
	public static class UpdateAgentStatsPatch
	{
		[HarmonyPrepare]
		private static bool Prepare()
		{
			return TargetMethod() != null;
		}

		[HarmonyTargetMethod]
		private static MethodBase TargetMethod()
		{
			Type type = AccessTools.TypeByName("SandBox.GameComponents.SandboxAgentStatCalculateModel");
			if (type == null)
			{
				return null;
			}
			return AccessTools.Method(type, "UpdateAgentStats", (Type[])null, (Type[])null);
		}

		[HarmonyPostfix]
		public static void Postfix(Agent agent, AgentDrivenProperties agentDrivenProperties)
		{
			try
			{
				if (agent == null || !agent.IsHuman || !_infectedAgents.Contains(agent))
				{
					return;
				}
				CombatModifiers agentEffects = GetAgentEffects(agent);
				if (agentEffects == null)
				{
					return;
				}
				if (!_oneTimeModsApplied.Contains(agent))
				{
					if (agentEffects.DamageMultiplier < 1f)
					{
						float num = agentEffects.DamageMultiplier - 1f;
						agentDrivenProperties.MeleeWeaponDamageMultiplierBonus += num;
						agentDrivenProperties.ThrowingWeaponDamageMultiplierBonus += num;
					}
					if (agentEffects.DefenseMultiplier < 1f)
					{
						agentDrivenProperties.ArmorHead *= agentEffects.DefenseMultiplier;
						agentDrivenProperties.ArmorTorso *= agentEffects.DefenseMultiplier;
						agentDrivenProperties.ArmorArms *= agentEffects.DefenseMultiplier;
						agentDrivenProperties.ArmorLegs *= agentEffects.DefenseMultiplier;
					}
					_oneTimeModsApplied.Add(agent);
				}
				if (agentEffects.SpeedMultiplier < 1f)
				{
					agentDrivenProperties.MaxSpeedMultiplier *= agentEffects.SpeedMultiplier;
					agentDrivenProperties.CombatMaxSpeedMultiplier *= agentEffects.SpeedMultiplier;
					agentDrivenProperties.SwingSpeedMultiplier *= agentEffects.SpeedMultiplier;
					agentDrivenProperties.ThrustOrRangedReadySpeedMultiplier *= agentEffects.SpeedMultiplier;
				}
				if (agentEffects.AccuracyMultiplier < 1f)
				{
					float num2 = 1f / Math.Max(0.5f, agentEffects.AccuracyMultiplier);
					agentDrivenProperties.WeaponInaccuracy *= num2;
					agentDrivenProperties.AiShooterError *= num2;
				}
				if (!agent.IsPlayerControlled)
				{
					float num3 = Math.Max(0.5f, (agentEffects.SpeedMultiplier + agentEffects.DamageMultiplier) / 2f);
					agentDrivenProperties.AIBlockOnDecideAbility *= num3;
					agentDrivenProperties.AIParryOnDecideAbility *= num3;
					agentDrivenProperties.AIDecideOnAttackChance *= num3;
				}
				if (_contourApplied.Contains(agent))
				{
					return;
				}
				try
				{
					if ((NativeObject)(object)agent.AgentVisuals != (NativeObject)null)
					{
						agent.AgentVisuals.SetContourColor((uint?)DISEASE_CONTOUR_COLOR, true);
						_contourApplied.Add(agent);
					}
				}
				catch
				{
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[HarmonyPatch(typeof(DefaultCombatSimulationModel), "SimulateHit", new Type[]
	{
		typeof(CharacterObject),
		typeof(CharacterObject),
		typeof(PartyBase),
		typeof(PartyBase),
		typeof(float),
		typeof(MapEvent),
		typeof(float),
		typeof(float)
	})]
	public static class SimulateHitPatch
	{
		[HarmonyPostfix]
		public static void Postfix(ref ExplainedNumber __result, CharacterObject strikerTroop, CharacterObject struckTroop, PartyBase strikerParty, PartyBase struckParty)
		{
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Expected O, but got Unknown
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Expected O, but got Unknown
			try
			{
				ModSettings instance = GlobalSettings<ModSettings>.Instance;
				if (instance == null || !instance.EnableDiseaseSystem || DiseaseManager.Instance == null)
				{
					return;
				}
				float num = 0f;
				float num2 = 0f;
				bool flag = ((strikerTroop != null) ? strikerTroop.HeroObject : null) != null;
				if (flag && DiseaseManager.Instance.IsHeroInfected(strikerTroop.HeroObject))
				{
					DiseaseEffects heroDiseaseEffects = DiseaseEffectSystem.GetHeroDiseaseEffects(strikerTroop.HeroObject);
					if (heroDiseaseEffects?.CombatModifiers != null)
					{
						num += heroDiseaseEffects.CombatModifiers.DamageMultiplier - 1f;
					}
				}
				else if (!flag && ((strikerParty != null) ? strikerParty.MobileParty : null) != null && DiseaseManager.Instance.PartyHasInfectedTroops(strikerParty.MobileParty))
				{
					float num3 = DiseaseManager.Instance.GetPartyInfectionRate(strikerParty.MobileParty) / 100f;
					DiseaseEffects partyTroopDiseaseEffects = DiseaseEffectSystem.GetPartyTroopDiseaseEffects(strikerParty.MobileParty);
					if (partyTroopDiseaseEffects?.CombatModifiers != null)
					{
						num += (partyTroopDiseaseEffects.CombatModifiers.DamageMultiplier - 1f) * num3;
					}
				}
				bool flag2 = ((struckTroop != null) ? struckTroop.HeroObject : null) != null;
				if (flag2 && DiseaseManager.Instance.IsHeroInfected(struckTroop.HeroObject))
				{
					DiseaseEffects heroDiseaseEffects2 = DiseaseEffectSystem.GetHeroDiseaseEffects(struckTroop.HeroObject);
					if (heroDiseaseEffects2?.CombatModifiers != null && heroDiseaseEffects2.CombatModifiers.DefenseMultiplier < 1f)
					{
						num2 += 1f - heroDiseaseEffects2.CombatModifiers.DefenseMultiplier;
					}
				}
				else if (!flag2 && ((struckParty != null) ? struckParty.MobileParty : null) != null && DiseaseManager.Instance.PartyHasInfectedTroops(struckParty.MobileParty))
				{
					float num4 = DiseaseManager.Instance.GetPartyInfectionRate(struckParty.MobileParty) / 100f;
					DiseaseEffects partyTroopDiseaseEffects2 = DiseaseEffectSystem.GetPartyTroopDiseaseEffects(struckParty.MobileParty);
					if (partyTroopDiseaseEffects2?.CombatModifiers != null && partyTroopDiseaseEffects2.CombatModifiers.DefenseMultiplier < 1f)
					{
						num2 += (1f - partyTroopDiseaseEffects2.CombatModifiers.DefenseMultiplier) * num4;
					}
				}
				if (num < -0.001f)
				{
					((ExplainedNumber)(ref __result)).AddFactor(num, new TextObject("{=AIInfluence_DiseaseCombatAtk}Disease (attacker)", (Dictionary<string, object>)null));
				}
				if (num2 > 0.001f)
				{
					((ExplainedNumber)(ref __result)).AddFactor(num2, new TextObject("{=AIInfluence_DiseaseCombatDef}Disease (defender)", (Dictionary<string, object>)null));
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private static readonly HashSet<Agent> _infectedAgents = new HashSet<Agent>();

	private static readonly Dictionary<Agent, CombatModifiers> _agentEffects = new Dictionary<Agent, CombatModifiers>();

	private static readonly HashSet<Agent> _contourApplied = new HashSet<Agent>();

	private static readonly HashSet<Agent> _oneTimeModsApplied = new HashSet<Agent>();

	private static Mission _lastMission;

	private static readonly uint DISEASE_CONTOUR_COLOR = 4284530752u;

	public static bool IsAgentInfected(Agent agent)
	{
		return agent != null && _infectedAgents.Contains(agent);
	}

	public static CombatModifiers GetAgentEffects(Agent agent)
	{
		if (agent != null && _agentEffects.TryGetValue(agent, out var value))
		{
			return value;
		}
		return null;
	}

	private static void ClearAll()
	{
		_infectedAgents.Clear();
		_agentEffects.Clear();
		_contourApplied.Clear();
		_oneTimeModsApplied.Clear();
	}

	public static Hero GetHeroFromAgent(Agent agent)
	{
		if (agent == null)
		{
			return null;
		}
		try
		{
			BasicCharacterObject character = agent.Character;
			BasicCharacterObject obj = ((character is CharacterObject) ? character : null);
			return (obj != null) ? ((CharacterObject)obj).HeroObject : null;
		}
		catch
		{
			return null;
		}
	}

	public static MobileParty GetPartyFromAgent(Agent agent)
	{
		if (agent == null)
		{
			return null;
		}
		try
		{
			IAgentOriginBase origin = agent.Origin;
			IBattleCombatant obj = ((origin != null) ? origin.BattleCombatant : null);
			PartyBase val = (PartyBase)(object)((obj is PartyBase) ? obj : null);
			return (val != null) ? val.MobileParty : null;
		}
		catch
		{
			return null;
		}
	}

	private static bool ShouldTroopBeInfected(MobileParty party)
	{
		if (party == null || DiseaseManager.Instance == null)
		{
			return false;
		}
		if (!DiseaseManager.Instance.PartyHasInfectedTroops(party))
		{
			return false;
		}
		float num = DiseaseManager.Instance.GetPartyInfectionRate(party) / 100f;
		return MBRandom.RandomFloat < num;
	}

	public static float GetDamageMultiplier(Hero hero)
	{
		if (hero == null || DiseaseManager.Instance == null)
		{
			return 1f;
		}
		return DiseaseEffectSystem.GetHeroDiseaseEffects(hero)?.CombatModifiers?.DamageMultiplier ?? 1f;
	}

	public static float GetDefenseMultiplier(Hero hero)
	{
		if (hero == null || DiseaseManager.Instance == null)
		{
			return 1f;
		}
		return DiseaseEffectSystem.GetHeroDiseaseEffects(hero)?.CombatModifiers?.DefenseMultiplier ?? 1f;
	}

	public static float GetSpeedMultiplier(Hero hero)
	{
		if (hero == null || DiseaseManager.Instance == null)
		{
			return 1f;
		}
		return DiseaseEffectSystem.GetHeroDiseaseEffects(hero)?.CombatModifiers?.SpeedMultiplier ?? 1f;
	}

	public static float GetAccuracyMultiplier(Hero hero)
	{
		if (hero == null || DiseaseManager.Instance == null)
		{
			return 1f;
		}
		return DiseaseEffectSystem.GetHeroDiseaseEffects(hero)?.CombatModifiers?.AccuracyMultiplier ?? 1f;
	}

	public static Hero GetHeroFromAgentPublic(Agent agent)
	{
		return GetHeroFromAgent(agent);
	}
}
