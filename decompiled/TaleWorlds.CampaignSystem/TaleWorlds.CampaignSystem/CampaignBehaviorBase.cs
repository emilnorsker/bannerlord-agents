using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem;

public abstract class CampaignBehaviorBase : ICampaignBehavior
{
	public readonly string StringId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignBehaviorBase(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignBehaviorBase()
	{
		throw null;
	}

	public abstract void RegisterEvents();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetCampaignBehavior<T>()
	{
		throw null;
	}

	public abstract void SyncData(IDataStore dataStore);
}
