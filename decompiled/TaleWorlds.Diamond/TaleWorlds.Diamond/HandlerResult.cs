using System.Runtime.CompilerServices;

namespace TaleWorlds.Diamond;

public class HandlerResult
{
	public bool IsSuccessful
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string Error
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Message NextMessage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected HandlerResult(bool isSuccessful, string error = null, Message followUp = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HandlerResult CreateSuccessful()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HandlerResult CreateSuccessful(Message nextMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HandlerResult CreateFailed(string error)
	{
		throw null;
	}
}
