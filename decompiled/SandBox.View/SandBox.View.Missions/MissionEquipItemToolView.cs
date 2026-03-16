using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionEquipItemToolView : MissionView
{
	private enum Filter
	{
		Head = 5,
		Cape = 9,
		Body = 6,
		Hand = 8,
		Leg = 7,
		Shield = 12,
		Bow = 13,
		Crossbow = 15,
		Horse = 10,
		Onehanded = 1,
		Twohanded = 2,
		Polearm = 3,
		Thrown = 4,
		Arrow = 14,
		Bolt = 16,
		Harness = 11
	}

	private delegate void MainThreadDelegate();

	private class ItemData
	{
		public GameEntity Entity;

		public string Name;

		public string Id;

		public BasicCultureObject Culture;

		public ItemTypeEnum itemType;

		public GenderEnum Gender;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemData()
		{
			throw null;
		}
	}

	public enum GenderEnum
	{
		Male = 1,
		Unisex,
		Female
	}

	private string str;

	private int _itemCulture;

	private bool[] _filters;

	private bool _genderSet;

	private Agent _mainAgent;

	private List<ItemObject> _allItemObjects;

	private List<ItemData> _allItems;

	private List<ItemData> _currentItems;

	private List<Tuple<int, int, int, int>> _currentArmorValues;

	private List<CultureObject> _allFactions;

	private List<CharacterObject> _allCharacters;

	private List<FormationClass> _groups;

	private int _activeIndex;

	private int _factionIndex;

	private int _groupIndex;

	private XmlDocument _charactersXml;

	private List<XmlDocument> _itemsXmls;

	private string[] _attributes;

	private string[] _spawnAttributes;

	private bool underscoreGuard;

	private bool yGuard;

	private bool zGuard;

	private bool xGuard;

	private bool _capsLock;

	private List<ItemObject> _activeItems;

	private int _setIndex;

	private int _spawnSetIndex;

	private Camera _cam;

	private bool _init;

	private int _index;

	private float _diff;

	private int _activeFilter;

	private int _activeWeaponSlot;

	private Vec3 _textStart;

	private List<BoundingBox> _bounds;

	private float _pivotDiff;

	private Agent _mountAgent;

	private ItemObject _horse;

	private ItemObject _harness;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetItems(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEquipToolDebugTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SortFilter(ItemTypeEnum type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnHorse(ItemObject horse, ItemObject harness)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAgent(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PositionCurrentItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EditNode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateActiveItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SlotCheck(string slotName, int index, XmlNode parentNode, ItemObject obj = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveToXml()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Clear(bool[] array)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionEquipItemToolView()
	{
		throw null;
	}
}
