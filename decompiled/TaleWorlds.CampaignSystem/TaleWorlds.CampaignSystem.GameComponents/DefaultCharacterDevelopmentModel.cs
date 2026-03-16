using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultCharacterDevelopmentModel : CharacterDevelopmentModel
{
	private const int MaxCharacterLevels = 62;

	private const int SkillPointsAtLevel1 = 1;

	private const int SkillPointsGainNeededInitialValue = 1000;

	private const int SkillPointsGainNeededIncreasePerLevel = 1000;

	private readonly int[] _skillsRequiredForLevel;

	private const int FocusPointsPerLevelConst = 1;

	private const int LevelsPerAttributePointConst = 4;

	private const int FocusPointsAtStartConst = 5;

	private const int AttributePointsAtStartConst = 15;

	private const int MaxSkillLevels = 1024;

	private readonly int[] _xpRequiredForSkillLevel;

	private const int XpRequirementForFirstLevel = 30;

	private const int MaxSkillPoint = int.MaxValue;

	private const float BaseLearningRate = 1.25f;

	private const int TraitThreshold2 = 4000;

	private const int TraitMaxValue1 = 2500;

	private const int TraitThreshold1 = 1000;

	private const int TraitMaxValue2 = 6000;

	private const int SkillLevelVariant = 10;

	private static readonly TextObject _attributeEffectText;

	private static readonly TextObject _skillFocusText;

	private static readonly TextObject _overLimitText;

	public override int MaxFocusPerSkill
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxAttribute
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int AttributePointsAtStart
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int LevelsPerAttributePoint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int FocusPointsPerLevel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int FocusPointsAtStart
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxSkillRequiredForEpicPerkBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MinSkillRequiredForEpicPerkBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultCharacterDevelopmentModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeSkillsRequiredForLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeXpRequiredForSkillLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int SkillsRequiredForLevel(int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMaxSkillPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetXpRequiredForSkillLevel(int skillLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillLevelChange(Hero hero, SkillObject skill, float skillXp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetXpAmountForSkillLevelChange(Hero hero, SkillObject skill, int skillLevelChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetTraitLevelForTraitXp(Hero hero, TraitObject trait, int xpValue, out int traitLevel, out int clampedTraitXp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTraitXpRequiredForTraitLevel(TraitObject trait, int traitLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateLearningLimit(IReadOnlyPropertyOwner<CharacterAttribute> characterAttributes, int focusValue, SkillObject skill, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateLearningRate(IReadOnlyPropertyOwner<CharacterAttribute> characterAttributes, int focusValue, int skillValue, SkillObject skill, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override SkillObject GetNextSkillToAddFocus(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CharacterAttribute GetNextAttributeToUpgrade(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PerkObject GetNextPerkToChoose(Hero hero, PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultCharacterDevelopmentModel()
	{
		throw null;
	}
}
