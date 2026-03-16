using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.EndOfRound;

public class MultiplayerEndOfRoundVM : ViewModel
{
	private readonly MissionScoreboardComponent _scoreboardComponent;

	private readonly MissionLobbyComponent _missionLobbyComponent;

	private readonly IRoundComponent _multiplayerRoundComponent;

	private readonly string _victoryText;

	private readonly string _defeatText;

	private readonly TextObject _roundEndReasonAllyTeamSideDepletedTextObject;

	private readonly TextObject _roundEndReasonEnemyTeamSideDepletedTextObject;

	private readonly TextObject _roundEndReasonAllyTeamRoundTimeEndedTextObject;

	private readonly TextObject _roundEndReasonEnemyTeamRoundTimeEndedTextObject;

	private readonly TextObject _roundEndReasonAllyTeamGameModeSpecificEndedTextObject;

	private readonly TextObject _roundEndReasonEnemyTeamGameModeSpecificEndedTextObject;

	private readonly TextObject _roundEndReasonRoundTimeEndedWithDrawTextObject;

	private bool _isShown;

	private bool _hasAttackerMVP;

	private bool _hasDefenderMVP;

	private string _title;

	private string _description;

	private string _cultureId;

	private bool _isRoundWinner;

	private MultiplayerEndOfRoundSideVM _attackerSide;

	private MultiplayerEndOfRoundSideVM _defenderSide;

	private MPPlayerVM _attackerMVP;

	private MPPlayerVM _defenderMVP;

	private string _attackerMVPTitleText;

	private string _defenderMVPTitleText;

	[DataSourceProperty]
	public bool IsShown
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
	public bool HasAttackerMVP
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
	public bool HasDefenderMVP
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
	public string Title
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
	public string Description
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
	public string CultureId
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
	public bool IsRoundWinner
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
	public MultiplayerEndOfRoundSideVM AttackerSide
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
	public MultiplayerEndOfRoundSideVM DefenderSide
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
	public MPPlayerVM AttackerMVP
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
	public MPPlayerVM DefenderMVP
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
	public string AttackerMVPTitleText
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
	public string DefenderMVPTitleText
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
	public MultiplayerEndOfRoundVM(MissionScoreboardComponent scoreboardComponent, MissionLobbyComponent missionLobbyComponent, IRoundComponent multiplayerRoundComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMVPSelected(MissionPeer mvpPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetMVPTitleText(BasicCultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIsShownChanged()
	{
		throw null;
	}
}
