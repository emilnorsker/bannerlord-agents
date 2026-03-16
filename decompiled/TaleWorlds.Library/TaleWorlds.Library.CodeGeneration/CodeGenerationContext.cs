using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.CodeGeneration;

public class CodeGenerationContext
{
	public List<NamespaceCode> Namespaces
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
	public CodeGenerationContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NamespaceCode FindOrCreateNamespace(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateInto(CodeGenerationFile codeGenerationFile)
	{
		throw null;
	}
}
