using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.Options;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade;

public class VoiceChatHandler : MissionNetwork
{
	private class PeerVoiceData
	{
		private const int PlayDelaySizeInMilliseconds = 150;

		private const int PlayDelaySizeInBytes = 3600;

		private const float PlayDelayResetTimeInMilliseconds = 300f;

		public readonly MissionPeer Peer;

		private readonly Queue<short> _voiceData;

		private readonly Queue<short> _voiceToPlayInTick;

		private int _playDelayRemainingSizeInBytes;

		private MissionTime _nextPlayDelayResetTime;

		public bool IsReadyOnPlatform
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
		public PeerVoiceData(MissionPeer peer)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void WriteVoiceData(byte[] dataBuffer, int bufferSize)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetReadyOnPlatform()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ProcessVoiceData()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Queue<short> GetVoiceToPlayForTick()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool HasAnyVoiceData()
		{
			throw null;
		}
	}

	private const int MillisecondsToShorts = 12;

	private const int MillisecondsToBytes = 24;

	private const int OpusFrameSizeCoefficient = 6;

	private const int VoiceFrameRawSizeInMilliseconds = 60;

	public const int VoiceFrameRawSizeInBytes = 1440;

	private const int CompressionMaxChunkSizeInBytes = 8640;

	private const int VoiceRecordMaxChunkSizeInBytes = 72000;

	private List<PeerVoiceData> _playerVoiceDataList;

	private bool _isVoiceChatDisabled;

	private bool _isVoiceRecordActive;

	private bool _stopRecordingOnNextTick;

	private Queue<byte> _voiceToSend;

	private bool _playedAnyVoicePreviousTick;

	private bool _localUserInitialized;

	private bool IsVoiceRecordActive
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

	public event Action OnVoiceRecordStarted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnVoiceRecordStopped
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<MissionPeer, bool> OnPeerVoiceStatusUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<MissionPeer> OnPeerMuteStatusUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreDisplayMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSendVoiceRecord(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSendVoiceToPlay(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckStopVoiceRecord()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VoiceTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecompressVoiceChunk(int clientID, byte[] compressedVoiceBuffer, int compressedBufferLength, ref byte[] voiceBuffer, out int bufferLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CompressVoiceChunk(int clientIndex, byte[] voiceBuffer, ref byte[] compressedBuffer, out int compressedBufferLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PeerVoiceData GetPlayerVoiceData(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPlayerToVoiceChat(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemovePlayerFromVoiceChat(int indexInVoiceDataList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MissionPeerOnTeamChanged(NetworkCommunicator peer, Team previousTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckPlayerForVoiceChatOnTeamChange(NetworkCommunicator peer, Team previousTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVoiceChatEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNativeOptionChanged(NativeOptions.NativeOptionsType changedNativeOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManagedOptionChanged(ManagedOptions.ManagedOptionsType changedManagedOptionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerDisconnectedFromServer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleNewClientAfterSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VoiceChatHandler()
	{
		throw null;
	}
}
