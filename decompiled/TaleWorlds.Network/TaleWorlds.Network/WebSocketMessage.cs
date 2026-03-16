using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Network;

[Obsolete]
public class WebSocketMessage
{
	public static Encoding Encoding;

	public byte[] Payload
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public MessageInfo MessageInfo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int Cursor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public MessageTypes MessageType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WebSocketMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTextPayload(string payload)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteTo(bool fromServer, Stream stream)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WebSocketMessage ReadFrom(bool fromServer, byte[] payload)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WebSocketMessage ReadFrom(bool fromServer, Stream stream)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WebSocketMessage CreateCursorMessage(int cursor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WebSocketMessage CreateCloseMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCursor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static WebSocketMessage()
	{
		throw null;
	}
}
