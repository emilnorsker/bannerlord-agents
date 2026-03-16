using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;

namespace SandBox.CampaignBehaviors;

public class HeirSelectionCampaignBehavior : CampaignBehaviorBase
{
	private readonly ItemRoster _itemsThatWillBeInherited;

	private readonly ItemRoster _equipmentsThatWillBeInherited;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforePlayerCharacterChanged(Hero oldPlayer, Hero newPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerCharacterChanged(Hero oldPlayer, Hero newPlayer, MobileParty newMainParty, bool isMainPartyChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforeMainCharacterDied(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeirSelectionOver(Hero selectedHeir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowGameStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GameOverCleanup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HeirSelectionCampaignBehavior()
	{
		throw null;
	}
}
