using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Incidents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.GameState;

public class MapState : TaleWorlds.Core.GameState
{
	private Incident _nextIncident;

	private MenuContext _menuContext;

	private bool _mapConversationActive;

	private bool _closeScreenNextFrame;

	private IMapStateHandler _handler;

	private BattleSimulation _battleSimulation;

	public Incident NextIncident
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

	public MenuContext MenuContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public string GameMenuId
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

	public bool AtMenu
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MapConversationActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IMapStateHandler Handler
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

	public bool IsSimulationActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnIdleTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnJoinArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLeaveArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFadeInAndOut(float fadeOutTime, float blackTime, float fadeInTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDispersePlayerLeadedArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnArmyCreated(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartIncident(Incident incident)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMainPartyEncounter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessTravel(CampaignVec2 moveTargetPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMenuModeTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapModeTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLoadingFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapConversationStarts(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapConversationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnSignalPeriodicEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnterMenuMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExitMenuMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartBattleSimulation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndBattleSimulation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerSiegeActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerSiegeDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSiegeEngineClick(MatrixFrame siegeEngineFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapState()
	{
		throw null;
	}
}
