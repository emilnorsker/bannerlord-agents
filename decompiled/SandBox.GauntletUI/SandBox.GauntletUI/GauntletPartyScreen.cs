using System;
using System.Runtime.CompilerServices;
using SandBox.View;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(PartyState))]
public class GauntletPartyScreen : ScreenBase, IGameStateListener, IChangeableScreen, IPartyScreenLogicHandler, IPartyScreenPrisonHandler, IPartyScreenTroopHandler
{
	private PartyVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private SpriteCategory _partyscreenCategory;

	private readonly PartyState _partyState;

	public bool IsTroopUpgradesDisabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletPartyScreen(PartyState partyState)
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
	void IGameStateListener.OnActivate()
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
	void IPartyScreenPrisonHandler.ExecuteTakeAllPrisonersScript()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPartyScreenPrisonHandler.ExecuteDoneScript()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPartyScreenPrisonHandler.ExecuteResetScript()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPartyScreenPrisonHandler.ExecuteSellAllPrisoners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPartyScreenTroopHandler.PartyTroopTransfer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestUserInput(string text, Action accept, Action cancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleResetInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCancelInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPartyScreenTroopHandler.ExecuteDoneScript()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDoneInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCompanionRemoved(Hero arg1, RemoveCompanionDetail arg2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IChangeableScreen.AnyUnsavedChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IChangeableScreen.CanChangesBeApplied()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChangeableScreen.ApplyChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChangeableScreen.ResetChanges()
	{
		throw null;
	}
}
