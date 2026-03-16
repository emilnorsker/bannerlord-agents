using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Diamond;

public class AccessObjectResult
{
	public AccessObject AccessObject
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

	public bool Success
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

	public TextObject FailReason
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
	public AccessObjectResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AccessObjectResult CreateSuccess(AccessObject accessObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AccessObjectResult CreateFailed(TextObject failReason)
	{
		throw null;
	}
}
