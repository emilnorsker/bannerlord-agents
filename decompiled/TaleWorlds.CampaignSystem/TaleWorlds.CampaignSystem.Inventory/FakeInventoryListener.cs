using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Inventory;

public class FakeInventoryListener : InventoryListener
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetGold()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetTraderName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetGold(int gold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTransaction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PartyBase GetOppositeParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FakeInventoryListener()
	{
		throw null;
	}
}
