using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class BaseNetworkComponentData : UdpNetworkComponent
{
	public const float MaxIntermissionStateTime = 240f;

	public int CurrentBattleIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCurrentBattleIndex(int currentBattleIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BaseNetworkComponentData()
	{
		throw null;
	}
}
