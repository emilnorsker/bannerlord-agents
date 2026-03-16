using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Diamond;

public class LobbyClientConnectResult
{
	public bool Connected
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

	public TextObject Error
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
	public LobbyClientConnectResult(bool connected, TextObject error)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LobbyClientConnectResult FromServerConnectResult(string errorCode, Dictionary<string, string> parameters)
	{
		throw null;
	}
}
