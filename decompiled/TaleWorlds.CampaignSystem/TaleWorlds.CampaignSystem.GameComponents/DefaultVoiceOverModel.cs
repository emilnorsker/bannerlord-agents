using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultVoiceOverModel : VoiceOverModel
{
	private const string ImperialHighClass = "imperial_high";

	private const string ImperialLowClass = "imperial_low";

	private const string VlandianClass = "vlandian";

	private const string SturgianClass = "sturgian";

	private const string KhuzaitClass = "khuzait";

	private const string AseraiClass = "aserai";

	private const string BattanianClass = "battanian";

	private const string ForestBanditClass = "forest_bandits";

	private const string SeaBanditClass = "sea_raiders";

	private const string MountainBanditClass = "mountain_bandits";

	private const string DesertBanditClass = "desert_bandits";

	private const string SteppeBanditClass = "steppe_bandits";

	private const string LootersClass = "looters";

	private const string Male = "male";

	private const string Female = "female";

	private const string GenericPersonaId = "generic";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetSoundPathForCharacter(CharacterObject character, VoiceObject voiceObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckPossibleMatches(VoiceObject voiceObject, List<string> possibleMatches, ref List<string> possibleVoicePaths, bool doubleCheckForGender = false, bool isFemale = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetAccentClass(CultureObject culture, bool isHighClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultVoiceOverModel()
	{
		throw null;
	}
}
