using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TaleWorlds.Library;

[Serializable]
[JsonConverter(typeof(ApplicationVersionJsonConverter))]
public struct ApplicationVersion
{
	public const int DefaultChangeSet = 110062;

	[JsonIgnore]
	public static readonly ApplicationVersion Empty;

	[JsonIgnore]
	public ApplicationVersionType ApplicationVersionType
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

	[JsonIgnore]
	public int Major
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

	[JsonIgnore]
	public int Minor
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

	[JsonIgnore]
	public int Revision
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

	[JsonIgnore]
	public int ChangeSet
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
	public ApplicationVersion(ApplicationVersionType applicationVersionType, int major, int minor, int revision, int changeSet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ApplicationVersion FromParametersFile(string customParameterFilePath = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ApplicationVersion FromString(string versionAsString, int defaultChangeSet = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSame(ApplicationVersion other, bool checkChangeSet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOlderThan(ApplicationVersion other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsNewerThan(ApplicationVersion other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ApplicationVersionType ApplicationVersionTypeFromString(string applicationVersionTypeAsString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPrefix(ApplicationVersionType applicationVersionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(ApplicationVersion a, ApplicationVersion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(ApplicationVersion a, ApplicationVersion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator >(ApplicationVersion a, ApplicationVersion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator <(ApplicationVersion a, ApplicationVersion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator >=(ApplicationVersion a, ApplicationVersion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator <=(ApplicationVersion a, ApplicationVersion b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ApplicationVersion()
	{
		throw null;
	}
}
