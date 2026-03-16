using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class Extensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<Type> GetTypesSafe(this Assembly assembly, Func<Type, bool> func = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Assembly[] GetReferencingAssembliesSafe(this Assembly baseAssembly, Func<Assembly, bool> func = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this Type type, Type attributeType, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this Type type, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Attribute> GetCustomAttributesSafe(this Type type, Type attributeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this PropertyInfo property, Type attributeType, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this PropertyInfo property, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Attribute> GetCustomAttributesSafe(this PropertyInfo property, Type attributeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this FieldInfo field, Type attributeType, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this FieldInfo field, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Attribute> GetCustomAttributesSafe(this FieldInfo field, Type attributeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this MethodInfo method, Type attributeType, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this MethodInfo method, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Attribute> GetCustomAttributesSafe(this MethodInfo method, Type attributeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this Assembly assembly, Type attributeType, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object[] GetCustomAttributesSafe(this Assembly assembly, bool inherit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Attribute> GetCustomAttributesSafe(this Assembly assembly, Type attributeType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<T> ToMBList<T>(this T[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<T> ToMBList<T>(this List<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<T> ToMBList<T>(this IEnumerable<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AppendList<T>(this List<T> list1, List<T> list2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBReadOnlyDictionary<TKey, TValue> GetReadOnlyDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasAnyFlag<T>(this T p1, T p2) where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasAllFlags<T>(this T p1, T p2) where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetDeterministicHashCode(this string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IndexOfMin<TSource>(this IReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IndexOfMin<TSource>(this MBReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IndexOfMax<TSource>(this IReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IndexOfMax<TSource>(this MBReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IndexOf<TValue>(this TValue[] source, TValue item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndex<TValue>(this IReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndex<TValue>(this MBReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindLastIndex<TValue>(this IReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindLastIndex<TValue>(this MBReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Randomize<T>(this IList<T> array)
	{
		throw null;
	}
}
