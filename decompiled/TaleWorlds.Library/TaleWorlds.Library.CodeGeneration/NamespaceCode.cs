using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.CodeGeneration;

public class NamespaceCode
{
	public string Name
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

	public List<ClassCode> Classes
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
	public NamespaceCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateInto(CodeGenerationFile codeGenerationFile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddClass(ClassCode clasCode)
	{
		throw null;
	}
}
