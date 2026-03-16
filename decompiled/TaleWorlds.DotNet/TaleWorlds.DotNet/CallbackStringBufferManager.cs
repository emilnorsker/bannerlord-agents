using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

public static class CallbackStringBufferManager
{
	internal const int CallbackStringBufferMaxSize = 1024;

	[ThreadStatic]
	private static byte[] _stringBuffer0;

	[ThreadStatic]
	private static byte[] _stringBuffer1;

	[ThreadStatic]
	private static byte[] _stringBuffer2;

	[ThreadStatic]
	private static byte[] _stringBuffer3;

	[ThreadStatic]
	private static byte[] _stringBuffer4;

	[ThreadStatic]
	private static byte[] _stringBuffer5;

	public static byte[] StringBuffer0
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static byte[] StringBuffer1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static byte[] StringBuffer2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static byte[] StringBuffer3
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static byte[] StringBuffer4
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static byte[] StringBuffer5
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}
}
