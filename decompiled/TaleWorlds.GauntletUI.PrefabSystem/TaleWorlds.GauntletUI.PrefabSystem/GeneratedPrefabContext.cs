using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public class GeneratedPrefabContext
{
	private Assembly[] _assemblies;

	private List<IGeneratedUIPrefabCreator> _prefabCreators;

	private Dictionary<string, Dictionary<string, CreateGeneratedWidget>> _generatedPrefabs;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GeneratedPrefabContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CollectPrefabs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddGeneratedPrefab(string prefabName, string variantName, CreateGeneratedWidget creator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly[] GetPrefabAssemblies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindGeneratedPrefabCreators()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GeneratedPrefabInstantiationResult InstantiatePrefab(UIContext conext, string prefabName, string variantName, Dictionary<string, object> data)
	{
		throw null;
	}
}
