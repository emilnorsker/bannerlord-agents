using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(ClanState))]
public class GauntletClanScreen : ScreenBase, IGameStateListener
{
	protected GauntletLayer _gauntletLayer;

	protected SpriteCategory _clanCategory;

	protected readonly ClanState _clanState;

	protected bool _isCreatingPartyWithMembers;

	public ClanManagementVM _dataSource
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
	public GauntletClanScreen(ClanState clanState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual ClanManagementVM CreateDataSource()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool IsRoleSelectionPopupActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OpenPartyScreenForNewClanParty(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OpenBannerEditorWithPlayerClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ShowHeroOnMap(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CloseClanScreen()
	{
		throw null;
	}
}
