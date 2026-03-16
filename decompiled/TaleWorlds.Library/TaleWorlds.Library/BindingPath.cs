using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class BindingPath
{
	private readonly string _path;

	public string Path
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string[] Nodes
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

	public string FirstNode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string LastNode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public BindingPath SubPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public BindingPath ParentPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BindingPath(string path, string[] nodes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BindingPath(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BindingPath(int path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BindingPath CreateFromProperty(string propertyName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BindingPath(IEnumerable<string> nodes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BindingPath(string[] firstNodes, string[] secondNodes)
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
	public static bool operator ==(BindingPath a, BindingPath b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(BindingPath a, BindingPath b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsRelatedWithPathAsString(string path, string referencePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsRelatedWithPath(string path, BindingPath referencePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsRelatedWith(BindingPath referencePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DecrementIfRelatedWith(BindingPath path, int startIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BindingPath Simplify()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BindingPath Append(BindingPath bindingPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
