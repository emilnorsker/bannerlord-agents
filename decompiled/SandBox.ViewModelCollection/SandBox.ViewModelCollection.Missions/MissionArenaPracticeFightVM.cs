using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics.Arena;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.ViewModelCollection.Missions;

public class MissionArenaPracticeFightVM : ViewModel
{
	private readonly Mission _mission;

	private readonly ArenaPracticeFightMissionController _practiceMissionController;

	private string _opponentsBeatenText;

	private string _opponentsRemainingText;

	private bool _isPlayerPracticing;

	private string _prizeText;

	[DataSourceProperty]
	public string OpponentsBeatenText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string PrizeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string OpponentsRemainingText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public bool IsPlayerPracticing
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionArenaPracticeFightVM(ArenaPracticeFightMissionController practiceMissionController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdatePrizeText()
	{
		throw null;
	}
}
