using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace TaleWorlds.CampaignSystem;

public class CharacterData
{
	public class PropertyObjectData
	{
		[XmlElement]
		public string StringId;

		[XmlElement]
		public int Value;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PropertyObjectData(string id, int value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PropertyObjectData()
		{
			throw null;
		}
	}

	public class SkillObjectData : PropertyObjectData
	{
		[XmlElement]
		public int Focus;

		[XmlElement]
		public int Progress;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SkillObjectData(string id, int value, int progress, int focus)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SkillObjectData()
		{
			throw null;
		}
	}

	public const string CharacterDataExtension = "char";

	[XmlElement]
	public string Name;

	[XmlElement]
	public bool IsFemale;

	[XmlElement]
	public int Gold;

	[XmlElement]
	public int Race;

	[XmlElement]
	public int Level;

	[XmlElement]
	public string Culture;

	[XmlElement]
	public float Age;

	[XmlElement]
	public float Weight;

	[XmlElement]
	public float Build;

	[XmlElement]
	public string CivilianEquipmentCode;

	[XmlElement]
	public string BattleEquipmentCode;

	[XmlElement]
	public string StealthEquipmentCode;

	[XmlArray("BodyPropertyKeys")]
	[XmlArrayItem("Key")]
	public ulong[] BodyPropertyKeys;

	[XmlElement]
	public int UnspentFocusPoints;

	[XmlElement]
	public int UnspentAttributePoints;

	[XmlArray("Perks")]
	[XmlArrayItem("Perk")]
	public string[] UnlockedPerks;

	[XmlArray("Attributes")]
	[XmlArrayItem("Attribute")]
	public PropertyObjectData[] AttributesArray;

	[XmlArray("Traits")]
	[XmlArrayItem("Trait")]
	public PropertyObjectData[] Traits;

	[XmlArray("Skills")]
	[XmlArrayItem("Skill")]
	public SkillObjectData[] SkillsArray;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static CharacterData CreateFrom(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeHeroFromCharacterData(Hero target, CharacterData characterData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportCharacter(Hero hero, string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ImportCharacter(Hero hero, string path)
	{
		throw null;
	}
}
