using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem.Definition;

public class SaveCodeGenerationContext
{
	private Dictionary<Assembly, SaveCodeGenerationContextAssembly> _assemblies;

	private DefinitionContext _definitionContext;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveCodeGenerationContext(DefinitionContext definitionContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAssembly(Assembly assembly, string defaultNamespace, string location, string fileName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal SaveCodeGenerationContextAssembly FindAssemblyInformation(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void FillFiles()
	{
		throw null;
	}
}
