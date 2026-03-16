using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class ShipPlacementDetachment : IDetachment
{
	private class ShipPlacementPosition
	{
		private bool _isHighPos;

		private Agent _extraAgent;

		public Agent AssignedAgent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		public MatrixFrame LocalFrame
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public bool IsOuterPos
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public bool HasExtraAgent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		public bool LentToOtherFrame
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int ExtraFrameIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipPlacementPosition(MatrixFrame frame, bool isOuterPos, bool isHighPos)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveAgent()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void LendToExtraPosition(int extraFrameIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ResetPlacementPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ResetExtraPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetAgent(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetExtraAgent(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalculateDefaultScore(out float resultScore, out float resultPossibleGain, out PositionCondition outGainCondition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalculateUnderMissileFireScore(out float resultScore, out float resultPossibleGain, out PositionCondition outGainCondition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalculateBoardingScore(Vec2 boardingLocalPosition, out float resultScore, out float resultPossibleGain, out PositionCondition outGainCondition, out bool requestExtraAgent)
		{
			throw null;
		}
	}

	private enum PositionCondition
	{
		Any,
		RangedOrShield,
		Ranged
	}

	private readonly Agent[] _agents;

	private readonly MBList<Formation> _userFormations;

	private readonly MBList<ShipPlacementPosition> _shipPlacementPositions;

	private readonly MissionShip _ownerShip;

	private bool _isUnderMissileFire;

	private bool _isBoarding;

	private Vec2 _boardingDirection;

	private MissionTimer _placementDetachmentTimer;

	private bool _isTickRequired;

	public MBReadOnlyList<Formation> UserFormations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLoose
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CountOfAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public bool HasAvailableSlots
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsTickRequired
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipPlacementDetachment(in MissionShip ownerShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgent(Agent agent, int slotIndex, AIScriptedFrameFlags customFlags = (AIScriptedFrameFlags)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentAtSlotIndex(Agent agent, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.FormationStartUsing(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.FormationStopUsing(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUsedByFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Agent IDetachment.GetMovingAgentAtSlotIndex(int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.GetSlotIndexWeightTuples(List<(int, float)> slotIndexWeightTuples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsSlotAtIndexAvailableForAgent(int slotIndex, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsAgentEligible(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.UnmarkDetachment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsDetachmentRecentlyEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.MarkSlotAtIndex(int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsAgentUsingOrInterested(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.OnFormationLeave(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsStandingPointAvailableForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<float> GetTemplateCostsOfAgent(Agent candidate, List<float> oldValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetExactCostOfAgentAtSlot(Agent candidate, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTemplateWeightOfAgent(Agent candidate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfAgentAtNextSlot(List<Agent> newAgents, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfAgentAtNextSlot(List<(Agent, float)> agentTemplateScores, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfAgentAtOccupiedSlot(Agent detachedAgent, List<Agent> newAgents, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfUsableSlots()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUnderMissileFire(bool isUnderMissileFire)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoarding(bool isBoarding, Vec2 localDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldFrame? GetAgentFrame(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfNextSlot(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWeightOfOccupiedSlot(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetDetachmentWeight(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.ResetEvaluation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.SetAsEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetDetachmentWeightFromCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.ComputeAndCacheDetachmentWeight(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent PickLastAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckCondition(PositionCondition positionCondition, Agent checkedAgent)
	{
		throw null;
	}
}
