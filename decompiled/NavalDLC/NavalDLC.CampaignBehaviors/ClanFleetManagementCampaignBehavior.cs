using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace NavalDLC.CampaignBehaviors;

public class ClanFleetManagementCampaignBehavior : CampaignBehaviorBase, IFleetManagementCampaignBehavior
{
	private class SentTroopsData
	{
		[SaveableProperty(0)]
		public TroopRoster SentTroops
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

		[SaveableProperty(1)]
		public CampaignTime TroopReturnTime
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

		[SaveableProperty(2)]
		public TextObject ShipName
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

		[SaveableProperty(3)]
		public TextObject PartyName
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
		public static SentTroopsData GetSentTroops(TroopRoster troops, CampaignTime returnTime, TextObject shipName, TextObject partyName)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SentTroopsData()
		{
			throw null;
		}
	}

	public class ClanFleetManagementCampaignBehaviorTypeDefiner : SaveableTypeDefiner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ClanFleetManagementCampaignBehaviorTypeDefiner()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineContainerDefinitions()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void DefineClassTypes()
		{
			throw null;
		}
	}

	private List<SentTroopsData> _sentTroops;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogs(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeTroopsReturn(SentTroopsData sentTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_clan_member_manage_fleet_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_clan_member_manage_fleet_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManageOtherFleetDone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendShipToParty(Ship ship, MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendShipToClan(Ship ship, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanFleetManagementCampaignBehavior()
	{
		throw null;
	}
}
