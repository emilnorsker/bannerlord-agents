using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace TaleWorlds.PlayerServices;

public class TimeoutWebClient : WebClient
{
	public int Timeout
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
	public TimeoutWebClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TimeoutWebClient(int timeout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override WebRequest GetWebRequest(Uri address)
	{
		throw null;
	}
}
