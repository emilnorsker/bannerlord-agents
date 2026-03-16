using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Tournaments.AgentControllers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Tournaments.MissionLogics;

public class TownHorseRaceMissionController : MissionLogic, ITournamentGameBehavior
{
	public class CheckPoint
	{
		private readonly VolumeBox _volumeBox;

		private readonly List<GameEntity> _bestTargetList;

		public string Name
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CheckPoint(VolumeBox volumeBox)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Vec3 GetBestTargetPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddToCheckList(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveFromCheckList(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnAgentsEnterCheckBox(VolumeBox volumeBox, List<Agent> agentsInVolume)
		{
			throw null;
		}
	}

	public const int TourCount = 2;

	private readonly List<TownHorseRaceAgentController> _agents;

	private List<Team> _teams;

	private List<GameEntity> _startPoints;

	private BasicMissionTimer _startTimer;

	private CultureObject _culture;

	public List<CheckPoint> CheckPoints
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
	public TownHorseRaceMissionController(CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectCheckPointsAndStartPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetStartFrame(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetItemsAndSpawnCharacter(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TownHorseRaceAgentController AddHorseRaceAgentController(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTeams(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartMatch(TournamentMatch match, bool isLastRound)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SkipMatch(TournamentMatch match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMatchEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMatchEnded()
	{
		throw null;
	}
}
