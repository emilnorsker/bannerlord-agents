using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace SandBox.CampaignBehaviors;

public class DumpIntegrityCampaignBehavior : CampaignBehaviorBase
{
	private readonly List<KeyValuePair<string, string>> _saveIntegrityDumpInfo;

	private readonly List<KeyValuePair<string, string>> _usedModulesDumpInfo;

	private readonly List<KeyValuePair<string, string>> _usedVersionsDumpInfo;

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
	private void OnConfigChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDumpInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendDataToWatchdog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsGameIntegrityAchieved(out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIfVersionIntegrityIsAchieved(out string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIfModulesAreDefault(out string unofficialModulesCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckCheatUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DumpIntegrityCampaignBehavior()
	{
		throw null;
	}
}
