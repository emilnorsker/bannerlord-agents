using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct AttackInformation
{
	public Agent AttackerAgent;

	public Agent VictimAgent;

	public float ArmorAmountFloat;

	public WeaponComponentData ShieldOnBack;

	public AgentFlag VictimAgentFlags;

	public Agent.AIStateFlag VictimAgentAIStateFlags;

	public float VictimAgentAbsorbedDamageRatio;

	public float DamageMultiplierOfBone;

	public float CombatDifficultyMultiplier;

	public MissionWeapon AttackerWeapon;

	public MissionWeapon VictimMainHandWeapon;

	public MissionWeapon VictimShield;

	public bool CanGiveDamageToAgentShield;

	public bool IsVictimAgentLeftStance;

	public bool IsFriendlyFire;

	public bool DoesAttackerHaveMountAgent;

	public bool DoesVictimHaveMountAgent;

	public Vec2 AttackerAgentMovementVelocity;

	public Vec2 AttackerAgentMountMovementDirection;

	public float AttackerMovementDirectionAsAngle;

	public Vec2 VictimAgentMovementVelocity;

	public Vec2 VictimAgentMountMovementDirection;

	public float VictimMovementDirectionAsAngle;

	public bool IsVictimAgentSameWithAttackerAgent;

	public bool IsAttackerAgentMine;

	public bool DoesAttackerHaveRiderAgent;

	public bool IsAttackerAgentRiderAgentMine;

	public bool IsAttackerAgentMount;

	public bool IsVictimAgentMine;

	public bool DoesVictimHaveRiderAgent;

	public bool IsVictimAgentRiderAgentMine;

	public bool IsVictimAgentMount;

	public bool IsAttackerAgentNull;

	public bool IsAttackerAIControlled;

	public BasicCharacterObject AttackerAgentCharacter;

	public BasicCharacterObject AttackerRiderAgentCharacter;

	public Monster AttackerAgentMonster;

	public IAgentOriginBase AttackerAgentOrigin;

	public IAgentOriginBase AttackerRiderAgentOrigin;

	public BasicCharacterObject VictimAgentCharacter;

	public BasicCharacterObject VictimRiderAgentCharacter;

	public IAgentOriginBase VictimAgentOrigin;

	public IAgentOriginBase VictimRiderAgentOrigin;

	public Vec3 AttackerAgentPosition;

	public Vec2 AttackerAgentMovementDirection;

	public Vec3 AttackerAgentVelocity;

	public Vec3 VictimAgentPosition;

	public float AttackerAgentMountChargeDamageProperty;

	public Vec3 VictimAgentVelocity;

	public Vec2 VictimAgentMovementDirection;

	public Vec3 AttackerAgentCurrentWeaponOffset;

	public bool IsAttackerAgentHuman;

	public bool IsAttackerAgentActive;

	public bool IsAttackerAgentDoingPassiveAttack;

	public bool IsVictimAgentNull;

	public float VictimAgentScale;

	public float VictimAgentWeight;

	public float VictimAgentHealth;

	public float VictimAgentMaxHealth;

	public float VictimAgentTotalEncumbrance;

	public bool IsVictimAgentHuman;

	public int WeaponAttachBoneIndex;

	public MissionWeapon OffHandItem;

	public bool IsHeadShot;

	public bool IsVictimRiderAgentSameAsAttackerAgent;

	public BasicCharacterObject AttackerCaptainCharacter;

	public BasicCharacterObject VictimCaptainCharacter;

	public Formation AttackerFormation;

	public Formation VictimFormation;

	public float AttackerHitPointRate;

	public float VictimHitPointRate;

	public bool IsAttackerPlayer;

	public bool IsVictimPlayer;

	public DestructableComponent HitObjectDestructibleComponent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AttackInformation(Agent attackerAgent, Agent victimAgent, WeakGameEntity hitObject, in AttackCollisionData attackCollisionData, in MissionWeapon attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AttackInformation(Agent attackerAgent, Agent victimAgent, float armorAmountFloat, WeaponComponentData shieldOnBack, AgentFlag victimAgentFlags, Agent.AIStateFlag victimAgentAIStateFlags, float victimAgentAbsorbedDamageRatio, float damageMultiplierOfBone, float combatDifficultyMultiplier, MissionWeapon attackerWeapon, MissionWeapon victimMainHandWeapon, MissionWeapon victimShield, bool canGiveDamageToAgentShield, bool isVictimAgentLeftStance, bool isFriendlyFire, bool doesAttackerHaveMountAgent, bool doesVictimHaveMountAgent, Vec2 attackerAgentMovementVelocity, Vec2 attackerAgentMountMovementDirection, float attackerMovementDirectionAsAngle, Vec2 victimAgentMovementVelocity, Vec2 victimAgentMountMovementDirection, float victimMovementDirectionAsAngle, bool isVictimAgentSameWithAttackerAgent, bool isAttackerAgentMine, bool doesAttackerHaveRiderAgent, bool isAttackerAgentRiderAgentMine, bool isAttackerAgentMount, bool isVictimAgentMine, bool doesVictimHaveRiderAgent, bool isVictimAgentRiderAgentMine, bool isVictimAgentMount, bool isAttackerAgentNull, bool isAttackerAIControlled, BasicCharacterObject attackerAgentCharacter, BasicCharacterObject attackerRiderAgentCharacter, Monster attackerAgentMonster, IAgentOriginBase attackerAgentOrigin, IAgentOriginBase attackerRiderAgentOrigin, BasicCharacterObject victimAgentCharacter, BasicCharacterObject victimRiderAgentCharacter, IAgentOriginBase victimAgentOrigin, IAgentOriginBase victimRiderAgentOrigin, Vec3 attackerAgentPosition, Vec2 attackerAgentMovementDirection, Vec3 attackerAgentVelocity, float attackerAgentMountChargeDamageProperty, Vec3 attackerAgentCurrentWeaponOffset, bool isAttackerAgentHuman, bool isAttackerAgentActive, bool isAttackerAgentDoingPassiveAttack, bool isVictimAgentNull, float victimAgentScale, float victimAgentHealth, float victimAgentMaxHealth, float victimAgentWeight, float victimAgentTotalEncumbrance, bool isVictimAgentHuman, Vec3 victimAgentPosition, Vec2 victimAgentMovementDirection, Vec3 victimAgentVelocity, int weaponAttachBoneIndex, MissionWeapon offHandItem, bool isHeadShot, bool isVictimRiderAgentSameAsAttackerAgent, bool isAttackerPlayer, bool isVictimPlayer, DestructableComponent hitObjectDestructibleComponent)
	{
		throw null;
	}
}
