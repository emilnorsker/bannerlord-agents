using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Items;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;

public class CharacterCreationGainedPropertiesVM : ViewModel
{
	private readonly CharacterCreationManager _characterCreationManager;

	private readonly Dictionary<CharacterAttribute, Tuple<int, int>> _affectedAttributesMap;

	private readonly Dictionary<SkillObject, Tuple<int, int>> _affectedSkillMap;

	private MBBindingList<CharacterCreationGainGroupItemVM> _gainGroups;

	private MBBindingList<EncyclopediaTraitItemVM> _gainedTraits;

	private MBBindingList<CharacterCreationGainedSkillItemVM> _otherSkills;

	[DataSourceProperty]
	public MBBindingList<CharacterCreationGainGroupItemVM> GainGroups
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
	public MBBindingList<EncyclopediaTraitItemVM> GainedTraits
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
	public MBBindingList<CharacterCreationGainedSkillItemVM> OtherSkills
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
	public CharacterCreationGainedPropertiesVM(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateInitialValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateGainedAttributeValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateGainedTraitValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterCreationGainedAttributeItemVM GetItemFromAttribute(CharacterAttribute attribute)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterCreationGainedSkillItemVM GetItemFromSkill(SkillObject skill)
	{
		throw null;
	}
}
