using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.ArmyManagement;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapBar;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Map;

public class GauntletMapBarGlobalLayer : GlobalLayer
{
	protected MapBarVM _dataSource;

	protected GauntletLayer _gauntletLayer;

	protected GauntletMovieIdentifier _movie;

	protected SpriteCategory _mapBarCategory;

	protected MapScreen _mapScreen;

	protected INavigationHandler _mapNavigationHandler;

	protected MapEncyclopediaView _encyclopediaManager;

	protected float _contextAlphaTarget;

	protected float _contextAlphaModifider;

	private GauntletLayer _armyManagementLayer;

	private SpriteCategory _armyManagementCategory;

	private ArmyManagementVM _armyManagementVM;

	private GauntletMovieIdentifier _gauntletArmyManagementMovie;

	private CampaignTimeControlMode _timeControlModeBeforeArmyManagementOpened;

	public bool IsInArmyManagement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapBarGlobalLayer(MapScreen mapScreen, INavigationHandler navigationHandler, float contextAlphaModifider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(MapBarVM dataSource)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapConversationStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMapConversationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MapBarShortcuts GetMapBarShortcuts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleArmyManagementInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePanelSwitching()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool HandlePanelSwitchingInput(InputContext inputContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenArmyManagement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CloseArmyManagement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEscaped()
	{
		throw null;
	}
}
