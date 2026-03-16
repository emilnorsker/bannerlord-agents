using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Nameplate;

public class PartyNameplatesVM : ViewModel
{
	private class NameplateDistanceComparer : IComparer<PartyNameplateVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(PartyNameplateVM x, PartyNameplateVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NameplateDistanceComparer()
		{
			throw null;
		}
	}

	private class NameplatePool
	{
		private readonly List<PartyNameplateVM> _nameplates;

		private int _initialCapacity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NameplatePool()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PartyNameplateVM Get()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Release(PartyNameplateVM nameplate)
		{
			throw null;
		}
	}

	private readonly Camera _mapCamera;

	private readonly Action _resetCamera;

	private readonly NameplateDistanceComparer _nameplateComparer;

	private readonly NameplatePool _nameplatePool;

	private readonly ParallelForAuxPredicate _updateNameplatesDelegate;

	private readonly Dictionary<MobileParty, PartyNameplateVM> _nameplatesByParty;

	private readonly List<MobileParty> _visibilityDirtyParties;

	private MBBindingList<PartyNameplateVM> _nameplates;

	private PartyPlayerNameplateVM _playerNameplate;

	[DataSourceProperty]
	public MBBindingList<PartyNameplateVM> Nameplates
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
	public PartyPlayerNameplateVM PlayerNameplate
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
	public PartyNameplatesVM(Camera mapCamera, Action resetCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateNameplateFor(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveNameplate(PartyNameplateVM nameplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangeKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomActionDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyVisibilityChanged(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMobilePartyVisibility(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateNameplatesInRange(int beginInclusive, int endExclusive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerCharacterChangedEvent(Hero oldPlayer, Hero newPlayer, MobileParty newMainParty, bool isMainPartyChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty destroyedParty, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnregisterEvents()
	{
		throw null;
	}
}
