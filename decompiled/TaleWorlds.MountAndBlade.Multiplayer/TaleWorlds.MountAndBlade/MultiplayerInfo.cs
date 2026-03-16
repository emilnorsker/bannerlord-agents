using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerInfo
{
	protected MultiplayerData multiplayerDataValues;

	public MultiplayerData MultiplayerDataValues
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMultiplayerTeamAvailable(int peerNo, int teamNo)
	{
		throw null;
	}
}
