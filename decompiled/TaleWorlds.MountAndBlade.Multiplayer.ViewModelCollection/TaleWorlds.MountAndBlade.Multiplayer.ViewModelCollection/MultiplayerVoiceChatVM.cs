using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection;

public class MultiplayerVoiceChatVM : ViewModel
{
	private readonly Mission _mission;

	private readonly VoiceChatHandler _voiceChatHandler;

	private MBBindingList<MPVoicePlayerVM> _activeVoicePlayers;

	[DataSourceProperty]
	public MBBindingList<MPVoicePlayerVM> ActiveVoicePlayers
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
	public MultiplayerVoiceChatVM(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeerVoiceStatusUpdated(MissionPeer peer, bool isTalking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnVoiceRecordStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnVoiceRecordStopped()
	{
		throw null;
	}
}
