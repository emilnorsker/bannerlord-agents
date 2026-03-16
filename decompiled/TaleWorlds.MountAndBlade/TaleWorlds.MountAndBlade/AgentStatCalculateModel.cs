using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public abstract class AgentStatCalculateModel : MBGameModel<AgentStatCalculateModel>
{
	protected const float MaxHorizontalErrorRadian = MathF.PI / 90f;

	private float _AILevelMultiplier;

	public abstract void InitializeAgentStats(Agent agent, Equipment spawnEquipment, AgentDrivenProperties agentDrivenProperties, AgentBuildData agentBuildData);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeMissionEquipment(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeAgentStatsAfterDeploymentFinished(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void InitializeMissionEquipmentAfterDeploymentFinished(Agent agent)
	{
		throw null;
	}

	public abstract void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties);

	public abstract float GetDifficultyModifier();

	public abstract bool CanAgentRideMount(Agent agent, Agent targetMount);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool HasHeavyArmor(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetEffectiveArmorEncumbrance(Agent agent, Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetEffectiveMaxHealth(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetEnvironmentSpeedFactor(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float CalculateAIAttackOnDecideMaxValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetWeaponInaccuracy(Agent agent, WeaponComponentData weapon, int weaponSkill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetDetachmentCostMultiplierOfAgent(Agent agent, IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetInteractionDistance(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetMaxCameraZoom(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual int GetEffectiveSkill(Agent agent, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual int GetEffectiveSkillForWeapon(Agent agent, WeaponComponentData weapon)
	{
		throw null;
	}

	public abstract float GetWeaponDamageMultiplier(Agent agent, WeaponComponentData weapon);

	public abstract float GetEquipmentStealthBonus(Agent agent);

	public abstract float GetSneakAttackMultiplier(Agent agent, WeaponComponentData weapon);

	public abstract float GetKnockBackResistance(Agent agent);

	public abstract float GetKnockDownResistance(Agent agent, StrikeType strikeType = StrikeType.Invalid);

	public abstract float GetDismountResistance(Agent agent);

	public abstract float GetBreatheHoldMaxDuration(Agent agent, float baseBreatheHoldMaxDuration);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual string GetMissionDebugInfoForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetAILevelMultiplier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAILevelMultiplier(float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected int GetMeleeSkill(Agent agent, WeaponComponentData equippedItem, WeaponComponentData secondaryItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float CalculateAILevel(Agent agent, int relevantSkillLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetAiRelatedProperties(Agent agent, AgentDrivenProperties agentDrivenProperties, WeaponComponentData equippedItem, WeaponComponentData secondaryItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetAllWeaponInaccuracy(Agent agent, AgentDrivenProperties agentDrivenProperties, int equippedIndex, WeaponComponentData equippedWeaponComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected AgentStatCalculateModel()
	{
		throw null;
	}
}
