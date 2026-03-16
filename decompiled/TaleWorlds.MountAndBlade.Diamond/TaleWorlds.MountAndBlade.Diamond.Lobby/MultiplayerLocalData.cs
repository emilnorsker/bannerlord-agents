using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.Lobby;

public abstract class MultiplayerLocalData
{
	public abstract bool HasSameContentWith(MultiplayerLocalData other);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MultiplayerLocalData()
	{
		throw null;
	}
}
