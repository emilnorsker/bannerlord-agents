using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.Multiplayer;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class ChatLogMessageManager : MessageManagerBase
{
	public struct ChatLineData
	{
		public string Text;

		public uint Color;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ChatLineData(string text, uint color)
		{
			throw null;
		}
	}

	private const uint WarningColor = 4292235858u;

	private const uint SuccessColor = 4285126986u;

	private MPChatVM _chatDataSource;

	private ConcurrentQueue<ChatLineData> _queue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChatLogMessageManager(MPChatVM chatDataSource)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDisplayMessageReceived(InformationMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PostWarningLine(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PostSuccessLine(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PostMessageLineFormatted(string text, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PostMessageLine(string text, uint color)
	{
		throw null;
	}
}
