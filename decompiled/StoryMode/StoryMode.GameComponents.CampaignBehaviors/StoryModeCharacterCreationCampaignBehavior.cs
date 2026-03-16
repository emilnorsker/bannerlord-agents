using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace StoryMode.GameComponents.CampaignBehaviors;

public class StoryModeCharacterCreationCampaignBehavior : CampaignBehaviorBase, ICharacterCreationContentHandler
{
	private const string BrotherNarrativeCharacterStringId = "brother_character";

	private const string PlayerEscapeNarrativeCharacterStringId = "player_escape_character";

	private int _focusToAdd;

	private int _skillLevelToAdd;

	private int _attributeLevelToAdd;

	private CharacterCreationManager _characterCreationManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCharacterCreationIsOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateHomeSettlementsOfFamily()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeFamilyStory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCharacterCreationInitialized(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeCharacterCreationStages(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeData(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.InitializeContent(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.AfterInitializeContent(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.OnStageCompleted(CharacterCreationStageBase stage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICharacterCreationContentHandler.OnCharacterCreationFinalize(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyCulture(CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FaceGenUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ModifyParentMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NarrativeMenuCharacterArgs> GetEscapeMenuNarrativeMenuCharacterArgs(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEscapeMenu(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEscapeNarrativeMenuOptions(NarrativeMenu narrativeMenu)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEscapeSubduedRaiderNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EscapeSubduedRaiderNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EscapeSubduedRaiderNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEscapeArrowNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EscapeArrowNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EscapeArrowNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEscapeHorseNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EscapeHorseNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EscapeHorseNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEscapeTrickedNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EscapeTrickedNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EscapeTrickedNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEscapeBreakOutNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool EscapeBreakOutNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EscapeBreakOutNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetMakeshiftFortificationNarrativeOptionArgs(NarrativeMenuOptionArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MakeshiftFortificationNarrativeOptionOnCondition(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeshiftFortificationNarrativeOptionOnSelect(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeParentsAndLittleSiblings(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeMainHeroAndElderBrother(CharacterCreationManager characterCreationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CreateSibling(Hero hero, BodyProperties motherBodyProperties, BodyProperties fatherBodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeCharacterCreationCampaignBehavior()
	{
		throw null;
	}
}
