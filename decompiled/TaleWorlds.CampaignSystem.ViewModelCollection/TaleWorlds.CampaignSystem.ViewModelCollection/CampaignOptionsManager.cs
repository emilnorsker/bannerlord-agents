using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public static class CampaignOptionsManager
{
	private static readonly List<ICampaignOptionProvider> _optionProviders;

	private static List<ICampaignOptionData> _currentOptions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetOptionWithIdExists(string identifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearCachedOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ICampaignOptionData> GetGameplayCampaignOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ICampaignOptionData> GetCharacterCreationCampaignOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CampaignOptionsManager()
	{
		throw null;
	}
}
