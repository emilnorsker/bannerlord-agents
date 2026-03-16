using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection;

public class MPVoicePlayerVM : MPPlayerVM
{
	public const int UpdatesRequiredToRemoveForSilence = 30;

	public readonly bool IsMyPeer;

	public int UpdatesSinceSilence;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPVoicePlayerVM(MissionPeer peer)
	{
		throw null;
	}
}
