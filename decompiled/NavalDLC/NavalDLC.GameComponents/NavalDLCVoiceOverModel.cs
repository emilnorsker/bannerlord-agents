using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Localization;

namespace NavalDLC.GameComponents;

public class NavalDLCVoiceOverModel : VoiceOverModel
{
	private const string NordClass = "nord";

	private const string CultureSouthernPirates = "southern_pirates";

	private const string SouthernPiratesClass = "southern_pirates";

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
	public NavalDLCVoiceOverModel()
	{
		throw null;
	}
}
