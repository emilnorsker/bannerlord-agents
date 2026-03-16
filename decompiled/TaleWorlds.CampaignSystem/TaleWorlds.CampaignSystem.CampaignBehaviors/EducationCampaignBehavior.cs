using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.MapNotificationTypes;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class EducationCampaignBehavior : CampaignBehaviorBase, IEducationLogic
{
	private enum ChildAgeState : short
	{
		Invalid = -1,
		Year2 = 0,
		Year5 = 1,
		Year8 = 2,
		Year11 = 3,
		Year14 = 4,
		Year16 = 5,
		Count = 6,
		First = 0,
		Last = 5
	}

	private class EducationOption
	{
		public delegate bool EducationOptionConditionDelegate(EducationOption option, List<EducationOption> previousOptions);

		public delegate bool EducationOptionConsequenceDelegate(EducationOption option);

		public readonly EducationOptionConditionDelegate Condition;

		private readonly EducationOptionConsequenceDelegate _consequence;

		public readonly TextObject Title;

		public readonly TextObject Description;

		public readonly TextObject Effect;

		public readonly CharacterAttribute[] Attributes;

		public readonly SkillObject[] Skills;

		public readonly EducationCharacterProperties ChildProperties;

		public readonly EducationCharacterProperties SpecialCharacterProperties;

		public readonly int RandomValue;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnConsequence(Hero child)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationOption(TextObject title, TextObject description, TextObject effect, EducationOptionConditionDelegate condition, EducationOptionConsequenceDelegate consequence, CharacterAttribute[] attributes, SkillObject[] skills, EducationCharacterProperties childProperties, EducationCharacterProperties specialCharacterProperties = default(EducationCharacterProperties))
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private TextObject GetEffectText(TextObject effect)
		{
			throw null;
		}
	}

	private class EducationStage
	{
		private List<List<EducationPage>> _superPages;

		public readonly ChildAgeState Target;

		public int PageCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationStage(ChildAgeState targetAge)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationPage AddPage(int pageIndex, TextObject title, TextObject description, TextObject instruction, EducationCharacterProperties childProperties = default(EducationCharacterProperties), EducationCharacterProperties specialCharacterProperties = default(EducationCharacterProperties), EducationPage.EducationPageConditionDelegate condition = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Equipment GetChildEquipmentForOption(Hero child, string optionKey, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Equipment GetChildEquipmentForPage(Hero child, EducationPage page, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private EducationCharacterProperties GetChildPropertiesForOption(Hero child, string optionKey, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private EducationCharacterProperties GetChildPropertiesForPage(Hero child, EducationPage page, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private CharacterObject GetSpecialCharacterForOption(Hero child, string optionKey, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private EducationCharacterProperties GetSpecialCharacterPropertiesForPage(Hero child, EducationPage page, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private EducationCharacterProperties GetSpecialCharacterPropertiesForOption(Hero child, string optionKey, List<string> previousOptions)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationOption GetOption(string optionKey)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationPage GetPage(List<string> previousOptionKeys)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<EducationOption> StringIdToEducationOption(List<string> previousOptionKeys)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal EducationCharacterProperties[] GetCharacterPropertiesForPage(Hero child, EducationPage page, List<string> previousChoices)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal EducationCharacterProperties[] GetCharacterPropertiesForOption(Hero child, EducationOption option, string optionKey, List<string> previousOptions)
		{
			throw null;
		}
	}

	public struct EducationCharacterProperties
	{
		public readonly CharacterObject Character;

		public readonly Equipment Equipment;

		public readonly string ActionId;

		public readonly string PrefabId;

		public readonly bool UseOffHand;

		public static readonly EducationCharacterProperties Default;

		public static readonly EducationCharacterProperties Invalid;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationCharacterProperties(CharacterObject character, Equipment equipment, string actionId, string prefabId, bool useOffHand)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationCharacterProperties(string actionId, string prefabId, bool useOffHand)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationCharacterProperties(string actionId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool operator ==(EducationCharacterProperties a, EducationCharacterProperties b)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool operator !=(EducationCharacterProperties a, EducationCharacterProperties b)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Equals(EducationCharacterProperties other)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool Equals(object obj)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int GetHashCode()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public sbyte GetUsedHandBoneIndex()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EducationCharacterProperties()
		{
			throw null;
		}
	}

	private class EducationPage
	{
		public delegate bool EducationPageConditionDelegate(EducationPage page, List<EducationOption> previousOptions);

		public readonly EducationPageConditionDelegate Condition;

		public readonly TextObject Title;

		public readonly TextObject Description;

		public readonly TextObject Instruction;

		private readonly string _id;

		private int _keyIndex;

		private readonly Dictionary<string, EducationOption> _options;

		public readonly EducationCharacterProperties ChildProperties;

		public readonly EducationCharacterProperties SpecialCharacterProperties;

		public IEnumerable<EducationOption> Options
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationPage(string id, TextObject title, TextObject description, TextObject instruction, EducationCharacterProperties childProperties, EducationCharacterProperties specialCharacterProperties, EducationPageConditionDelegate condition = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddOption(EducationOption option)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EducationOption GetOption(string optionKey)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string[] GetAvailableOptions(List<EducationOption> previousEducationOptions)
		{
			throw null;
		}
	}

	private const char Separator = ';';

	private const int AttributeIncrease = 1;

	private const int FocusIncrease = 1;

	private const int SkillIncrease = 15;

	private readonly TextObject _pickAttributeText;

	private readonly TextObject _confirmResultsText;

	private readonly TextObject _chooseTalentText;

	private readonly TextObject _chooseTutorText;

	private readonly TextObject _guideTutorText;

	private readonly TextObject _chooseFocusText;

	private readonly TextObject _chooseSkillText;

	private readonly TextObject _chooseGiftText;

	private readonly TextObject _chooseAchievementText;

	private Dictionary<Hero, short> _previousEducations;

	private readonly TextObject _chooseTaskText;

	private readonly TextObject _chooseRequestText;

	private Hero _activeChild;

	private EducationStage _activeStage;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroComesOfAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail details, bool showNotifications)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCharacterCreationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetOptionProperties(Hero child, string optionKey, List<string> previousOptions, out TextObject optionTitle, out TextObject description, out TextObject effect, out (CharacterAttribute, int)[] attributes, out (SkillObject, int)[] skills, out (SkillObject, int)[] focusPoints, out EducationCharacterProperties[] educationCharacterProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPageProperties(Hero child, List<string> previousChoices, out TextObject title, out TextObject description, out TextObject instruction, out EducationCharacterProperties[] defaultCharacterProperties, out string[] availableOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValidEducationNotification(EducationMapNotification data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetStageProperties(Hero child, out int pageCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChildAgeState GetClosestStage(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChildAgeState GetLastDoneStage(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFinalize(EducationStage stage, Hero child, List<string> chosenOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasNotificationForAge(Hero child, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowEducationNotification(Hero child, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoEducationUntil(Hero child, ChildAgeState childAgeState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoStage(Hero child, EducationStage stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Finalize(Hero child, List<string> chosenOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHeroChildOfPlayer(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildCultureHasLorekeeper(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ChildCultureHasBard(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage GetStage(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage GetStage(Hero child, ChildAgeState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int ChildStateToAge(ChildAgeState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Stage2Selection(List<SkillObject> skills, EducationPage previousPage, EducationPage currentPage, EducationCharacterProperties[] childProperties, EducationCharacterProperties[] tutorProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Stage16Selection((TextObject, TextObject, SkillObject)[] titleDescSkillTuple, EducationPage currentPage, EducationCharacterProperties[] childProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage CreateStage2(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage CreateStage5(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage CreateStage8(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage CreateStage11(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage CreateStage14(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationStage CreateStage16(Hero child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetHighestThreeAttributes(Hero hero, out (CharacterAttribute, int)[] maxAttributes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EducationCampaignBehavior()
	{
		throw null;
	}
}
