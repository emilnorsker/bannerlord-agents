using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions.TaskSystem;

[Serializable]
public class TaskStep
{
	public TaskStepType StepType { get; set; }

	public TaskStepStatus Status { get; set; }

	public string TargetSettlementId { get; set; }

	public string TargetPartyId { get; set; }

	public float WaitDays { get; set; }

	public CampaignTime? WaitStartTime { get; set; }

	public CampaignTime? WaitUntilTime { get; set; }

	public string CustomData { get; set; }

	public float PatrolDurationDays { get; set; }

	public bool PatrolAutoReturn { get; set; }

	public float WaitNearDurationDays { get; set; }

	public float WaitNearRadius { get; set; }

	public string Description { get; set; }

	public TaskStep()
	{
		Status = TaskStepStatus.Pending;
	}

	public TaskStep(TaskStepType stepType, string description = null)
	{
		StepType = stepType;
		Status = TaskStepStatus.Pending;
		Description = description;
	}

	public static TaskStep CreateGoToSettlement(Settlement settlement, string description = null)
	{
		return new TaskStep(TaskStepType.GoToSettlement, description ?? $"Go to {((settlement != null) ? settlement.Name : null)}")
		{
			TargetSettlementId = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null)
		};
	}

	public static TaskStep CreateWaitInSettlement(Settlement settlement, float waitDays, string description = null)
	{
		return new TaskStep(TaskStepType.WaitInSettlement, description ?? $"Wait in {((settlement != null) ? settlement.Name : null)} for {waitDays} days")
		{
			TargetSettlementId = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null),
			WaitDays = waitDays
		};
	}

	public static TaskStep CreateReturnToPlayer(string description = null)
	{
		return new TaskStep(TaskStepType.ReturnToPlayer, description ?? "Return to player");
	}

	public static TaskStep CreateFollowPlayer(string description = null)
	{
		return new TaskStep(TaskStepType.FollowPlayer, description ?? "Follow player");
	}

	public static TaskStep CreateAttackParty(string targetPartyStringId, string description = null)
	{
		return new TaskStep(TaskStepType.AttackParty, description ?? ("Attack party " + targetPartyStringId))
		{
			TargetPartyId = targetPartyStringId
		};
	}

	public static TaskStep CreateSiegeSettlement(Settlement settlement, string description = null)
	{
		return new TaskStep(TaskStepType.SiegeSettlement, description ?? $"Besiege {((settlement != null) ? settlement.Name : null)}")
		{
			TargetSettlementId = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null)
		};
	}

	public static TaskStep CreatePatrolSettlement(Settlement settlement, float durationDays, bool autoReturn, string description = null)
	{
		return new TaskStep(TaskStepType.PatrolSettlement, description ?? $"Patrol around {((settlement != null) ? settlement.Name : null)} for {durationDays} days")
		{
			TargetSettlementId = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null),
			PatrolDurationDays = durationDays,
			PatrolAutoReturn = autoReturn
		};
	}

	public static TaskStep CreateWaitNearSettlement(Settlement settlement, float durationDays, float radius, string description = null)
	{
		return new TaskStep(TaskStepType.WaitNearSettlement, description ?? $"Hold position near {((settlement != null) ? settlement.Name : null)} for {durationDays} days at radius {radius}")
		{
			TargetSettlementId = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null),
			WaitNearDurationDays = durationDays,
			WaitNearRadius = radius
		};
	}

	public static TaskStep CreateRaidVillage(Settlement village, string description = null)
	{
		return new TaskStep(TaskStepType.RaidVillage, description ?? $"Raid village {((village != null) ? village.Name : null)}")
		{
			TargetSettlementId = ((village != null) ? ((MBObjectBase)village).StringId : null)
		};
	}

	public Settlement GetTargetSettlement()
	{
		if (string.IsNullOrEmpty(TargetSettlementId))
		{
			return null;
		}
		return ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == TargetSettlementId));
	}

	public MobileParty GetTargetParty()
	{
		if (string.IsNullOrEmpty(TargetPartyId))
		{
			return null;
		}
		return ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == TargetPartyId));
	}

	public bool IsWaitCompleted()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (StepType != TaskStepType.WaitInSettlement || !WaitUntilTime.HasValue)
		{
			return false;
		}
		return CampaignTime.Now >= WaitUntilTime.Value;
	}

	public void StartWaiting()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (StepType == TaskStepType.WaitInSettlement && WaitDays > 0f)
		{
			WaitStartTime = CampaignTime.Now;
			WaitUntilTime = CampaignTime.Now + CampaignTime.Days(WaitDays);
			Status = TaskStepStatus.InProgress;
		}
	}
}
