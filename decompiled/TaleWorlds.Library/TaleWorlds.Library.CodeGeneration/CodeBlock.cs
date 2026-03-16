using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.CodeGeneration;

public class CodeBlock
{
	private List<string> _lines;

	public List<string> Lines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CodeBlock()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLine(string line)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLines(IEnumerable<string> lines)
	{
		throw null;
	}
}
