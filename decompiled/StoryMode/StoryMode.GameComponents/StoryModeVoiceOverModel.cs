using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Localization;

namespace StoryMode.GameComponents;

public class StoryModeVoiceOverModel : VoiceOverModel
{
	private const string Male = "male";

	private const string Female = "female";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetSoundPathForCharacter(CharacterObject character, VoiceObject voiceObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetAccentClass(CultureObject culture, bool isHighClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeVoiceOverModel()
	{
		throw null;
	}
}
