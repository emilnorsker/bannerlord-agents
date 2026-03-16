using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerData : MBMultiplayerData
{
	public readonly int AutoTeamBalanceLimit;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMultiplayerTeamAvailable(int peerNo, int teamNo)
	{
		throw null;
	}
}
