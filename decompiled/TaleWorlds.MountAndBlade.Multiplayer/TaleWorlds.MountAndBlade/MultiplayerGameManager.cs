using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.PlatformService;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerGameManager : MBGameManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerGameManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void DoLoadingForGameManager(GameManagerLoadingSteps gameManagerLoadingStep, out GameManagerLoadingSteps nextStep)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterCampaignStart(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNewCampaignStart(Game game, object starterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSessionInvitationAccepted(SessionInvitationType sessionInvitationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlatformRequestedMultiplayer()
	{
		throw null;
	}
}
