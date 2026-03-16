using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class MissionCommunityClientComponent : MissionLobbyComponent
{
	private CommunityClient _communityClient;

	private bool _isServerEndedBeforeClientLoaded;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetServerEndingBeforeClientLoaded(bool isServerEndingBeforeClientLoaded)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void QuitMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionCommunityClientComponent()
	{
		throw null;
	}
}
