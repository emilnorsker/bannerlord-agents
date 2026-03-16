using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CharacterCreationContent;

public sealed class NarrativeMenu
{
	public delegate List<NarrativeMenuCharacterArgs> GetNarrativeMenuCharacterArgsDelegate(CultureObject culture, string occupationType, CharacterCreationManager characterCreationManager);

	public readonly string StringId;

	public readonly string InputMenuId;

	public readonly string OutputMenuId;

	public readonly TextObject Title;

	public readonly TextObject Description;

	private readonly List<NarrativeMenuCharacter> _characters;

	private readonly MBList<NarrativeMenuOption> _characterCreationMenuOptions;

	public readonly GetNarrativeMenuCharacterArgsDelegate GetNarrativeMenuCharacterArgs;

	public List<NarrativeMenuCharacter> Characters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<NarrativeMenuOption> CharacterCreationMenuOptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NarrativeMenu(string stringId, string inputMenuId, string outputMenuId, TextObject title, TextObject description, List<NarrativeMenuCharacter> characters, GetNarrativeMenuCharacterArgsDelegate getNarrativeMenuCharacterArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNarrativeMenuOption(NarrativeMenuOption narrativeMenuOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveNarrativeMenuOption(NarrativeMenuOption narrativeMenuOption)
	{
		throw null;
	}
}
