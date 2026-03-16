using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.GameState;

public class PortState : TaleWorlds.Core.GameState
{
	public readonly PortScreenModes PortScreenMode;

	public readonly PartyBase LeftOwner;

	public readonly PartyBase RightOwner;

	public readonly MBReadOnlyList<Ship> LeftShips;

	public readonly MBReadOnlyList<Ship> RightShips;

	public readonly Action OnEndAction;

	public override bool IsMenuState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortState(PartyBase leftOwner, PartyBase rightOwner, PortScreenModes portScreenMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortState(PartyBase leftOwner, PartyBase rightOwner, Action onEndAction, PortScreenModes portScreenMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortState(MBReadOnlyList<Ship> leftShips, MBReadOnlyList<Ship> rightShips, PortScreenModes portScreenMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortState(PartyBase leftOwner, PartyBase rightOwner, MBReadOnlyList<Ship> leftShips, MBReadOnlyList<Ship> rightShips, PortScreenModes portScreenMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortState(Settlement settlement, PartyBase rightOwner, PortScreenModes portScreenMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}
}
