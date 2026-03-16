using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public static class Common
{
	private static IPlatformFileHelper _fileHelper;

	private static DateTime lastGCTime;

	private static ParallelOptions _parallelOptions;

	public static IPlatformFileHelper PlatformFileHelper
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

	public static string ConfigName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ParallelOptions ParallelOptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] CombineBytes(byte[] arr1, byte[] arr2, byte[] arr3 = null, byte[] arr4 = null, byte[] arr5 = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CreateNanoIdFrom(string input)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CalculateMD5Hash(string input)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ToRoman(int number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetDJB2(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] SerializeObjectAsJson(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string SerializeObjectAsJsonString(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T DeserializeObjectFromJson<T>(string json)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] FromUrlSafeBase64(string base64)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Type FindType(string typeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MemoryCleanupGC(bool forceTimer = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object DynamicInvokeWithLog(this Delegate method, params object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object InvokeWithLog(this MethodInfo methodInfo, object obj, params object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object InvokeWithLog(this ConstructorInfo constructorInfo, params object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetStackTraceRaw(Exception e, int skipCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WalkInnerExceptionRecursive(Exception InnerException, ref string StackStr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PrintDynamicInvokeDebugInfo(Exception e, MethodInfo methodInfo, object obj, params object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TextContainsSpecialCharacters(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint ParseIpAddress(string address)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAllLetters(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAllLettersOrWhiteSpaces(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsCharAsian(char character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetInvariantCulture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MethodInfo GetMethodInfo(Expression<Action> expression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MethodInfo GetMethodInfo<T, TResult>(Expression<Func<T, TResult>> expression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MethodInfo GetMethodInfo(LambdaExpression expression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Common()
	{
		throw null;
	}
}
