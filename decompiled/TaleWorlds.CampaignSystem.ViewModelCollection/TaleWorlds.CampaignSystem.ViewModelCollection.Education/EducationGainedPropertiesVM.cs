using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Education;

public class EducationGainedPropertiesVM : ViewModel
{
	private readonly Hero _child;

	private readonly int _pageCount;

	private readonly IEducationLogic _educationBehavior;

	private readonly Dictionary<CharacterAttribute, Tuple<int, int>> _affectedAttributesMap;

	private readonly Dictionary<SkillObject, Tuple<int, int>> _affectedSkillFocusMap;

	private readonly Dictionary<SkillObject, Tuple<int, int>> _affectedSkillValueMap;

	private MBBindingList<EducationGainGroupItemVM> _gainGroups;

	private MBBindingList<EducationGainedSkillItemVM> _otherSkills;

	[DataSourceProperty]
	public MBBindingList<EducationGainGroupItemVM> GainGroups
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
	public MBBindingList<EducationGainedSkillItemVM> OtherSkills
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
	public EducationGainedPropertiesVM(Hero child, int pageCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateWithSelections(List<string> selectedOptions, int currentPageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateInitialValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateGainedAttributeValues(List<string> selectedOptions, int currentPageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationGainedAttributeItemVM GetItemFromAttribute(CharacterAttribute attribute)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EducationGainedSkillItemVM GetItemFromSkill(SkillObject skill)
	{
		throw null;
	}
}
