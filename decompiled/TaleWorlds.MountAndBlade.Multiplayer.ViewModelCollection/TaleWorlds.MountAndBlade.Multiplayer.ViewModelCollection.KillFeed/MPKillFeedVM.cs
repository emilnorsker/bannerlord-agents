using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.KillFeed.General;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.KillFeed.Personal;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.KillFeed;

public class MPKillFeedVM : ViewModel
{
	private MPGeneralKillNotificationVM _generalCasualty;

	private MPPersonalKillNotificationVM _personalCasualty;

	[DataSourceProperty]
	public MPGeneralKillNotificationVM GeneralCasualty
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
	public MPPersonalKillNotificationVM PersonalCasualty
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
	public MPKillFeedVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, bool isPersonalFeedEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPersonalAssist(string victimAgentName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPersonalDamage(int damageAmount, bool isFatal, bool isMountDamage, bool isFriendlyDamage, bool isHeadshot, string killedAgentName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetAssistedAgent(Agent affectedAgent, Agent affectorAgent)
	{
		throw null;
	}
}
