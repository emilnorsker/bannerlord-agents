using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TaleWorlds.Library;

public class UniqueSceneId
{
	private static readonly Lazy<Regex> IdentifierPattern;

	public string UniqueToken
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string Revision
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UniqueSceneId(string uniqueToken, string revision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string Serialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryParse(string uniqueMapId, out UniqueSceneId identifiers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static UniqueSceneId()
	{
		throw null;
	}
}
