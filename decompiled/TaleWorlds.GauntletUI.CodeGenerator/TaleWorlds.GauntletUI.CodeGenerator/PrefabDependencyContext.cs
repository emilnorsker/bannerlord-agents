using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.PrefabSystem;
using TaleWorlds.Library.CodeGeneration;

namespace TaleWorlds.GauntletUI.CodeGenerator;

public class PrefabDependencyContext
{
	private List<PrefabDependency> _prefabDependencies;

	private int _dependencyIndex;

	public string RootClassName
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
	public PrefabDependencyContext(string rootClassName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GenerateDependencyName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDependentWidgetTemplateGenerateContext(WidgetTemplateGenerateContext widgetTemplateGenerateContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PrefabDependency GetDependendPrefab(string type, Dictionary<string, WidgetAttributeTemplate> givenParameters, Dictionary<string, object> data, bool isRoot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CompareGivenParameters(Dictionary<string, WidgetAttributeTemplate> a, Dictionary<string, WidgetAttributeTemplate> b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CompareData(Dictionary<string, object> a, Dictionary<string, object> b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateInto(NamespaceCode namespaceCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsDependency(string type, Dictionary<string, WidgetAttributeTemplate> givenParameters, Dictionary<string, object> data, bool isRoot)
	{
		throw null;
	}
}
