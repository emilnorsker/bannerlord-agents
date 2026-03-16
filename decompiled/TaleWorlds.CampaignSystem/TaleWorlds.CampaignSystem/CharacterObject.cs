using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;

namespace TaleWorlds.CampaignSystem;

public sealed class CharacterObject : BasicCharacterObject, ICharacterData
{
	private CharacterRestrictionFlags _characterRestrictionFlags;

	[SaveableField(101)]
	private Hero _heroObject;

	[SaveableField(103)]
	private CharacterObject _originCharacter;

	private TraitObject _persona;

	private PropertyOwner<TraitObject> _characterTraits;

	private CharacterObject _civilianEquipmentTemplate;

	private CharacterObject _battleEquipmentTemplate;

	private Occupation _occupation;

	public override TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string EncyclopediaLink
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject EncyclopediaLinkWithName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HiddenInEncyclopedia
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsNotTransferableInPartyScreen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsNotTransferableInHideouts
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CharacterObject OriginalCharacter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsOriginalCharacter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Hero HeroObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal set
		{
			throw null;
		}
	}

	public override Equipment Equipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override IEnumerable<Equipment> BattleEquipments
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override IEnumerable<Equipment> CivilianEquipments
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<Equipment> StealthEquipments
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override Equipment FirstBattleEquipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override Equipment FirstCivilianEquipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Equipment FirstStealthEquipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override Equipment RandomBattleEquipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override Equipment RandomCivilianEquipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int HitPoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Equipment RandomStealthEquipment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ExplainedNumber MaxHitPointsExplanation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int Level
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CharacterObject PlayerCharacter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static CharacterObject OneToOneConversationCharacter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<CharacterObject> ConversationCharacters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMariner
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

	public new CultureObject Culture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public override bool IsFemale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsBasicTroop
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool IsTemplate
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

	public bool IsChildTemplate
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

	public override bool IsPlayerCharacter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRegular
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Occupation Occupation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float Age
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int ConformityNeededToRecruitPrisoner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CharacterObject[] UpgradeTargets
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

	public ItemCategory UpgradeRequiresItemFromCategory
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

	public override bool IsMounted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsRanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int TroopWage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Tier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static MBReadOnlyList<CharacterObject> All
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsCharacterObject(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_heroObject(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_originCharacter(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int MaxHitPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterObject()
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
	private void Init()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject CreateFrom(CharacterObject character, StaticBodyProperties? staticBodyProperties = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterRegister()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override BodyProperties GetBodyPropertiesMin(bool returnBaseValue = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override BodyProperties GetBodyPropertiesMax(bool returnBaseValue = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdatePlayerCharacterBodyProperties(BodyProperties properties, int race, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Occupation GetDefaultOccupation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasThrowingWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUpgradeXpCost(PartyBase party, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUpgradeGoldCost(PartyBase party, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeHeroCharacterOnAfterLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetPower()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetBattlePower()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMoraleResistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSimulationAttackPower(out float attackPoints, out float defencePoints, Equipment equipment = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetHeadArmorSum(Equipment.EquipmentType equipmentType = Equipment.EquipmentType.Battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBodyArmorSum(Equipment.EquipmentType equipmentType = Equipment.EquipmentType.Battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLegArmorSum(Equipment.EquipmentType equipmentType = Equipment.EquipmentType.Battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetArmArmorSum(Equipment.EquipmentType equipmentType = Equipment.EquipmentType.Battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetHorseArmorSum(Equipment.EquipmentType equipmentType = Equipment.EquipmentType.Battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTotalArmorSum(Equipment.EquipmentType equipmentType = Equipment.EquipmentType.Battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Equipment GetEquipmentByType(Equipment.EquipmentType equipmentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override BodyProperties GetBodyProperties(Equipment equipment, int seed = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTransferableInPartyScreen(bool isTransferable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTransferableInHideouts(bool isTransferable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAttributes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTraitLevel(TraitObject trait)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPerkValue(PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillValue(SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TraitObject GetPersona()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMountKeySeed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override FormationClass GetFormationClass()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject Find(string idString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject FindFirst(Predicate<CharacterObject> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<CharacterObject> FindAll(Predicate<CharacterObject> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetPowerImp(int tier, bool isHero = false, bool isMounted = false)
	{
		throw null;
	}
}
