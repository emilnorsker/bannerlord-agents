using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;

namespace TaleWorlds.CampaignSystem;

public class CampaignObjectManager
{
	private interface ICampaignObjectType : IEnumerable
	{
		Type ObjectClass { get; }

		void PreAfterLoad();

		void AfterLoad();

		uint GetMaxObjectSubId();
	}

	private class CampaignObjectType<T> : ICampaignObjectType, IEnumerable, IEnumerable<T> where T : MBObjectBase
	{
		private readonly IEnumerable<T> _registeredObjects;

		public uint MaxCreatedPostfixIndex
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

		Type ICampaignObjectType.ObjectClass
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CampaignObjectType(IEnumerable<T> registeredObjects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void PreAfterLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AfterLoad()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public uint GetMaxObjectSubId()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnItemAdded(T item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RegisterItem(T item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UnregisterItem(T item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public T Find(string id)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public T FindFirst(Predicate<T> predicate)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MBReadOnlyList<T> FindAll(Predicate<T> predicate)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string FindNextUniqueStringId(List<CampaignObjectType<T>> lists, string id)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static (string str, uint number) GetIdParts(string stringId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool Exist(List<CampaignObjectType<T>> lists, string id)
		{
			throw null;
		}
	}

	private enum CampaignObjects
	{
		DeadOrDisabledHeroes,
		AliveHeroes,
		Clans,
		Kingdoms,
		MobileParty,
		ObjectCount
	}

	internal const uint HeroObjectManagerTypeID = 32u;

	internal const uint MobilePartyObjectManagerTypeID = 14u;

	internal const uint ClanObjectManagerTypeID = 18u;

	internal const uint KingdomObjectManagerTypeID = 20u;

	private ICampaignObjectType[] _objects;

	private Dictionary<Type, uint> _objectTypesAndNextIds;

	[SaveableField(20)]
	private readonly MBList<Hero> _deadOrDisabledHeroes;

	[SaveableField(30)]
	private readonly MBList<Hero> _aliveHeroes;

	[SaveableField(40)]
	private readonly MBList<Clan> _clans;

	[SaveableField(50)]
	private readonly MBList<Kingdom> _kingdoms;

	private MBList<IFaction> _factions;

	[SaveableField(71)]
	private MBList<MobileParty> _mobileParties;

	private MBList<MobileParty> _caravanParties;

	private MBList<MobileParty> _patrolParties;

	private MBList<MobileParty> _militiaParties;

	private MBList<MobileParty> _garrisonParties;

	private MBList<MobileParty> _banditParties;

	private MBList<MobileParty> _villagerParties;

	private MBList<MobileParty> _customParties;

	private MBList<MobileParty> _lordParties;

	private MBList<MobileParty> _partiesWithoutPartyComponent;

	[SaveableProperty(80)]
	public MBReadOnlyList<Settlement> Settlements
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

	public MBReadOnlyList<MobileParty> MobileParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> CaravanParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> PatrolParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> MilitiaParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> GarrisonParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> BanditParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> VillagerParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> LordParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> CustomParties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MobileParty> PartiesWithoutPartyComponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Hero> AliveHeroes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Hero> DeadOrDisabledHeroes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Clan> Clans
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Kingdom> Kingdoms
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<IFaction> Factions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignObjectManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeManagerObjectLists()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LoadInitializationCallback]
	private void OnLoad(MetaData metaData, ObjectLoadData objectLoadData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void PreAfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeOnLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeOnNewGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCachedData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddMobileParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveMobileParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BeforePartyComponentChanged(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AfterPartyComponentChanged(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnregisterDeadHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroAdded(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void HeroStateChanged(Hero hero, Hero.CharacterStates oldState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddKingdom(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPartyToAppropriateList(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemovePartyFromAppropriateList(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemAdded<T>(CampaignObjects targetList, T obj) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemRemoved<T>(CampaignObjects targetList, T obj) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T FindFirst<T>(Predicate<T> predicate) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<T> FindAll<T>(Predicate<T> predicate) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private uint GetNextUniqueObjectIdOfType<T>() where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T Find<T>(string id) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string FindNextUniqueStringId<T>(string id) where T : MBObjectBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsCampaignObjectManager(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValueSettlements(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_deadOrDisabledHeroes(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_aliveHeroes(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_clans(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_kingdoms(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_mobileParties(object o)
	{
		throw null;
	}
}
