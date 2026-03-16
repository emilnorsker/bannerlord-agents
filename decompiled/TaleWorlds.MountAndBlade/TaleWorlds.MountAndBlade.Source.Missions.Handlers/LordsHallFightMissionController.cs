using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.Objects;

namespace TaleWorlds.MountAndBlade.Source.Missions.Handlers;

public class LordsHallFightMissionController : MissionLogic, IMissionAgentSpawnLogic, IMissionBehavior
{
	private class MissionSide
	{
		private readonly BattleSideEnum _side;

		private readonly IMissionTroopSupplier _troopSupplier;

		private readonly bool _isPlayerSide;

		private bool _troopSpawningActive;

		private int _numberOfSpawnedTroops;

		public bool TroopSpawningActive
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int NumberOfActiveTroops
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MissionSide(BattleSideEnum side, IMissionTroopSupplier troopSupplier, bool isPlayerSide)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SpawnTroops(Dictionary<int, Dictionary<int, AreaData>> areaMarkerDictionary, int spawnCount)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SpawnTroops(int spawnCount, bool isReinforcement)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSpawnTroops(bool spawnTroops)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IEnumerable<IAgentOriginBase> GetAllTroops()
		{
			throw null;
		}
	}

	private class AreaData
	{
		[CompilerGenerated]
		private sealed class _003CGetAvailableMachines_003Ed__12 : IEnumerable<AreaEntityData>, IEnumerable, IEnumerator<AreaEntityData>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private AreaEntityData _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private bool isArcher;

			public bool _003C_003E3__isArcher;

			public AreaData _003C_003E4__this;

			private List<AreaEntityData>.Enumerator _003C_003E7__wrap1;

			AreaEntityData IEnumerator<AreaEntityData>.Current
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[DebuggerHidden]
				get
				{
					throw null;
				}
			}

			object IEnumerator.Current
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[DebuggerHidden]
				get
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			public _003CGetAvailableMachines_003Ed__12(int _003C_003E1__state)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool MoveNext()
			{
				throw null;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void _003C_003Em__Finally1()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			IEnumerator<AreaEntityData> IEnumerable<AreaEntityData>.GetEnumerator()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				throw null;
			}
		}

		private const string ArcherSpawnPointTag = "defender_archer";

		private const string InfantrySpawnPointTag = "defender_infantry";

		private readonly List<FightAreaMarker> _areaList;

		private readonly List<AreaEntityData> _archerUsablePoints;

		private readonly List<AreaEntityData> _infantryUsablePoints;

		public IEnumerable<FightAreaMarker> AreaList
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public IEnumerable<AreaEntityData> ArcherUsablePoints
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public IEnumerable<AreaEntityData> InfantryUsablePoints
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AreaData(List<FightAreaMarker> areaList)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003CGetAvailableMachines_003Ed__12))]
		public IEnumerable<AreaEntityData> GetAvailableMachines(bool isArcher)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddAreaMarker(FightAreaMarker marker)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AreaEntityData FindAgentMachine(Agent agent)
		{
			throw null;
		}
	}

	private class AreaEntityData
	{
		public readonly GameEntity Entity;

		public Agent UserAgent
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

		public bool InUse
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AreaEntityData(GameEntity entity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AssignAgent(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void StopUse()
		{
			throw null;
		}
	}

	private const int ReinforcementWaveAgentCount = 5;

	private readonly float _areaLostRatio;

	private readonly float _attackerDefenderTroopCountRatio;

	private readonly int _attackerSideTroopCountMax;

	private readonly int _defenderSideTroopCountMax;

	private readonly MissionSide[] _missionSides;

	private Team[] _attackerTeams;

	private Team[] _defenderTeams;

	private Dictionary<int, Dictionary<int, AreaData>> _dividedAreaDictionary;

	private List<int> _areaIndexList;

	private int _lastAreaLostByDefender;

	private bool _troopsInitialized;

	private bool _isMissionInitialized;

	private bool _spawnReinforcements;

	private bool _setChargeOrderNextFrame;

	private BattleSideEnum _playerSide;

	private int _removedAllyCounter;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LordsHallFightMissionController(IMissionTroopSupplier[] suppliers, float areaLostRatio, float attackerDefenderTroopCountRatio, int attackerSideTroopCountMax, int defenderSideTroopCountMax, BattleSideEnum playerSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<int, AreaEntityData> FindAgentMachine(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForReinforcement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartSpawner(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopSpawner(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideSpawnEnabled(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetReinforcementInterval()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideDepleted(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPlayerControllableTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<IAgentOriginBase> GetAllTroopsForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetSpawnHorses(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfAnyAreaIsLostByDefender()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAreaLost(int areaIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartAreaPullBack(AreaData areaData, int nextAreaIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AreaEntityData FindPosition(int nextAreaIndex, bool isArcher)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int SelectBestSubArea(int areaIndex, bool isArcher)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetAreaAvailabilityRatio(AreaData areaData, bool isArcher)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAreaLostByDefender(AreaData areaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAgentInArea(Agent agent, AreaData areaData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FormationClass GetLordsHallFightTroopClass(BattleSideEnum side, BasicCharacterObject agentCharacter)
	{
		throw null;
	}
}
