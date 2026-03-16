using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class MPPerkObject : IReadOnlyPerkObject
{
	private class MPOnSpawnPerkHandlerInstance : MPOnSpawnPerkHandler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MPOnSpawnPerkHandlerInstance(IEnumerable<IReadOnlyPerkObject> perks)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MPOnSpawnPerkHandlerInstance(MissionPeer peer)
		{
			throw null;
		}
	}

	private class MPPerkHandlerInstance : MPPerkHandler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MPPerkHandlerInstance(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MPPerkHandlerInstance(MissionPeer peer)
		{
			throw null;
		}
	}

	private class MPCombatPerkHandlerInstance : MPCombatPerkHandler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MPCombatPerkHandlerInstance(Agent attacker, Agent defender)
		{
			throw null;
		}
	}

	public class MPOnSpawnPerkHandler
	{
		private IEnumerable<IReadOnlyPerkObject> _perks;

		public bool IsWarmup
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MPOnSpawnPerkHandler(IEnumerable<IReadOnlyPerkObject> perks)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MPOnSpawnPerkHandler(MissionPeer peer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetExtraTroopCount()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IEnumerable<(EquipmentIndex, EquipmentElement)> GetAlternativeEquipments(bool isPlayer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetDrivenPropertyBonusOnSpawn(bool isPlayer, DrivenProperty drivenProperty, float baseValue)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetHitpoints(bool isPlayer)
		{
			throw null;
		}
	}

	public class MPPerkHandler
	{
		private readonly Agent _agent;

		private readonly MBReadOnlyList<MPPerkObject> _perks;

		public bool IsWarmup
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MPPerkHandler(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MPPerkHandler(MissionPeer peer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnEvent(MPPerkCondition.PerkEventFlags flags)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnEvent(Agent agent, MPPerkCondition.PerkEventFlags flags)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnTick(int tickCount)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetDrivenPropertyBonus(DrivenProperty drivenProperty, float baseValue)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetRangedAccuracy()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetThrowingWeaponSpeed(WeaponComponentData attackerWeapon)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetDamageInterruptionThreshold()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetMountManeuver()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetMountSpeed()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetGoldOnKill(float attackerValue, float victimValue)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetGoldOnAssist()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetRewardedGoldOnAssist()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool GetIsTeamRewardedOnDeath()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IEnumerable<(MissionPeer, int)> GetTeamGoldRewardsOnDeath()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetEncumbrance(bool isOnBody)
		{
			throw null;
		}
	}

	public class MPCombatPerkHandler
	{
		private readonly Agent _attacker;

		private readonly Agent _defender;

		private readonly MBReadOnlyList<MPPerkObject> _attackerPerks;

		private readonly MBReadOnlyList<MPPerkObject> _defenderPerks;

		public bool IsWarmup
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MPCombatPerkHandler(Agent attacker, Agent defender)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetDamage(WeaponComponentData attackerWeapon, DamageTypes damageType, bool isAlternativeAttack)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetDamageTaken(WeaponComponentData attackerWeapon, DamageTypes damageType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetSpeedBonusEffectiveness(WeaponComponentData attackerWeapon, DamageTypes damageType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetShieldDamage(bool isCorrectSideBlock)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetShieldDamageTaken(bool isCorrectSideBlock)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetRangedHeadShotDamage()
		{
			throw null;
		}
	}

	private readonly MissionPeer _peer;

	private readonly MPConditionalEffect.ConditionalEffectContainer _conditionalEffects;

	private readonly MPPerkCondition.PerkEventFlags _perkEventFlags;

	private readonly string _name;

	private readonly string _description;

	private readonly List<MPPerkEffectBase> _effects;

	public TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasBannerBearer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public List<string> GameModes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public int PerkListIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string IconId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string HeroIdleAnimOverride
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string HeroMountIdleAnimOverride
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string TroopIdleAnimOverride
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string TroopMountIdleAnimOverride
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPPerkObject(MissionPeer peer, string name, string description, List<string> gameModes, int perkListIndex, string iconId, IEnumerable<MPConditionalEffect> conditionalEffects, IEnumerable<MPPerkEffectBase> effects, string heroIdleAnimOverride, string heroMountIdleAnimOverride, string troopIdleAnimOverride, string troopMountIdleAnimOverride)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MPPerkObject(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPPerkObject Clone(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEvent(bool isWarmup, MPPerkCondition.PerkEventFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEvent(bool isWarmup, Agent agent, MPPerkCondition.PerkEventFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTick(bool isWarmup, int tickCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDamage(bool isWarmup, Agent agent, WeaponComponentData attackerWeapon, DamageTypes damageType, bool isAlternativeAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMountDamage(bool isWarmup, Agent agent, WeaponComponentData attackerWeapon, DamageTypes damageType, bool isAlternativeAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDamageTaken(bool isWarmup, Agent agent, WeaponComponentData attackerWeapon, DamageTypes damageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMountDamageTaken(bool isWarmup, Agent agent, WeaponComponentData attackerWeapon, DamageTypes damageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSpeedBonusEffectiveness(bool isWarmup, Agent agent, WeaponComponentData attackerWeapon, DamageTypes damageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetShieldDamage(bool isWarmup, Agent attacker, Agent defender, bool isCorrectSideBlock)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetShieldDamageTaken(bool isWarmup, Agent attacker, Agent defender, bool isCorrectSideBlock)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetRangedAccuracy(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetThrowingWeaponSpeed(bool isWarmup, Agent agent, WeaponComponentData attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDamageInterruptionThreshold(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMountManeuver(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMountSpeed(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetRangedHeadShotDamage(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetExtraTroopCount(bool isWarmup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<(EquipmentIndex, EquipmentElement)> GetAlternativeEquipments(bool isWarmup, bool isPlayer, List<(EquipmentIndex, EquipmentElement)> alternativeEquipments, bool getAllEquipments = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDrivenPropertyBonus(bool isWarmup, Agent agent, DrivenProperty drivenProperty, float baseValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDrivenPropertyBonusOnSpawn(bool isWarmup, bool isPlayer, DrivenProperty drivenProperty, float baseValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetHitpoints(bool isWarmup, bool isPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetEncumbrance(bool isWarmup, Agent agent, bool isOnBody)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetGoldOnKill(bool isWarmup, Agent agent, float attackerValue, float victimValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetGoldOnAssist(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetRewardedGoldOnAssist(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsTeamRewardedOnDeath(bool isWarmup, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateRewardedGoldOnDeath(bool isWarmup, Agent agent, List<(MissionPeer, int)> teamMembers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetTroopCount(MultiplayerClassDivisions.MPHeroClass heroClass, int botsPerFormation, MPOnSpawnPerkHandler onSpawnPerkHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IReadOnlyPerkObject Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPPerkHandler GetPerkHandler(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPPerkHandler GetPerkHandler(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPCombatPerkHandler GetCombatPerkHandler(Agent attacker, Agent defender)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPOnSpawnPerkHandler GetOnSpawnPerkHandler(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MPOnSpawnPerkHandler GetOnSpawnPerkHandler(IEnumerable<IReadOnlyPerkObject> perks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RaiseEventForAllPeers(MPPerkCondition.PerkEventFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RaiseEventForAllPeersOnTeam(Team side, MPPerkCondition.PerkEventFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TickAllPeerPerks(int tickCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("raise_event", "mp_perks")]
	public static string RaiseEventForAllPeersCommand(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("tick_perks", "mp_perks")]
	public static string TickAllPeerPerksCommand(List<string> strings)
	{
		throw null;
	}
}
