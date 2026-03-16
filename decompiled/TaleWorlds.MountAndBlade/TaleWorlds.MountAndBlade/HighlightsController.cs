using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class HighlightsController : MissionLogic
{
	public struct HighlightType
	{
		public string Id
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

		public string Description
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

		public string GroupId
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

		public int StartDelta
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

		public int EndDelta
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

		public float MinVisibilityScore
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

		public float MaxHighlightDistance
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

		public bool IsVisibilityRequired
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
		public HighlightType(string id, string description, string groupId, int startDelta, int endDelta, float minVisibilityScore, float maxHighlightDistance, bool isVisibilityRequired)
		{
			throw null;
		}
	}

	public struct Highlight
	{
		public HighlightType HighlightType;

		public float Start;

		public float End;
	}

	private bool _isKillingSpreeHappening;

	private List<float> _playerKillTimes;

	private const int MinKillingSpreeKills = 4;

	private const float MaxKillingSpreeDuration = 10f;

	private const float HighShotDifficultyThreshold = 7.5f;

	private bool _isArcherSalvoHappening;

	private List<float> _archerSalvoKillTimes;

	private const int MinArcherSalvoKills = 5;

	private const float MaxArcherSalvoDuration = 4f;

	private bool _isFirstImpact;

	private List<float> _cavalryChargeHitTimes;

	private const float CavalryChargeImpactTimeFrame = 3f;

	private const int MinCavalryChargeHits = 5;

	private Tuple<float, float> _lastSavedHighlightData;

	private List<Highlight> _highlightSaveQueue;

	private const float IgnoreIfOverlapsLastVideoPercent = 0.5f;

	private List<string> _savedHighlightGroups;

	private List<string> _highlightGroupIds;

	protected static List<HighlightType> HighlightTypes
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

	public static bool IsHighlightsInitialized
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

	public bool IsAnyHighlightSaved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveHighlights()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HighlightType GetHighlightTypeWithId(string highlightId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveVideo(string highlightID, string groupID, int startDelta, int endDelta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddHighlightType(HighlightType highlightType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveHighlight(Highlight highlight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveHighlight(Highlight highlight, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanSaveHighlight(HighlightType highlightType, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPlayerIsLookingAtPositionScore(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanSeePosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ShowSummary()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickHighlightsToBeSaved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HighlightsController()
	{
		throw null;
	}
}
