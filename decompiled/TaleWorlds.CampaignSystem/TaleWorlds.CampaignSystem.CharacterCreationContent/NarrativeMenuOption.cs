using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CharacterCreationContent;

public sealed class NarrativeMenuOption
{
	public readonly string StringId;

	public readonly TextObject Text;

	public readonly TextObject DescriptionText;

	private NarrativeMenuOptionOnConditionDelegate _onConditionInternal;

	private NarrativeMenuOptionOnSelectDelegate _onSelectInternal;

	private NarrativeMenuOptionOnConsequenceDelegate _onConsequenceInternal;

	private readonly GetNarrativeMenuOptionArgsDelegate _getNarrativeMenuOptionArgs;

	public readonly NarrativeMenuOptionArgs Args;

	public TextObject PositiveEffectText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NarrativeMenuOption(string stringId, TextObject text, TextObject descriptionText, GetNarrativeMenuOptionArgsDelegate getNarrativeMenuOptionArgs, NarrativeMenuOptionOnConditionDelegate onCondition, NarrativeMenuOptionOnSelectDelegate onSelect, NarrativeMenuOptionOnConsequenceDelegate onConsequence)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool OnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnConsequence(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOnCondition(NarrativeMenuOptionOnConditionDelegate onCondition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOnSelect(NarrativeMenuOptionOnSelectDelegate onSelect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOnConsequence(NarrativeMenuOptionOnConsequenceDelegate onConsequence)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyFinalEffects(CharacterCreationContent characterCreationContent)
	{
		throw null;
	}
}
