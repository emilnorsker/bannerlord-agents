using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.PrefabSystem;
using TaleWorlds.Library.CodeGeneration;

namespace TaleWorlds.GauntletUI.CodeGenerator;

public class WidgetTemplateGenerateContext
{
	private WidgetPrefab _prefab;

	private WidgetTemplate _rootWidgetTemplate;

	private UICodeGenerationVariantExtension _variantExtension;

	private WidgetCodeGenerationInfo _rootWidgetCodeGenerationInfo;

	public WidgetFactory WidgetFactory
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

	public UICodeGenerationContext UICodeGenerationContext
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

	public VariableCollection VariableCollection
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

	public string PrefabName
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

	public string VariantName
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

	public string ClassName
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

	public Dictionary<string, object> Data
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

	public List<WidgetCodeGenerationInfo> WidgetCodeGenerationInformations
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

	public PrefabDependencyContext PrefabDependencyContext
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

	public WidgetTemplateGenerateContextType ContextType
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

	public bool GotLogicalChildrenLocation
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
	private WidgetTemplateGenerateContext(UICodeGenerationContext uiCodeGenerationContext, PrefabDependencyContext prefabDependencyContext, WidgetTemplateGenerateContextType contextType, string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WidgetTemplateGenerateContext CreateAsRoot(UICodeGenerationContext uiCodeGenerationContext, string prefabName, string variantName, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WidgetTemplateGenerateContext CreateAsDependendPrefab(UICodeGenerationContext uiCodeGenerationContext, PrefabDependencyContext prefabDependencyContext, string prefabName, string variantName, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data, Dictionary<string, WidgetAttributeTemplate> givenParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WidgetTemplateGenerateContext CreateAsInheritedDependendPrefab(UICodeGenerationContext uiCodeGenerationContext, PrefabDependencyContext prefabDependencyContext, string prefabName, string variantName, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data, Dictionary<string, WidgetAttributeTemplate> givenParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WidgetTemplateGenerateContext CreateAsCustomWidgetTemplate(UICodeGenerationContext uiCodeGenerationContext, PrefabDependencyContext prefabDependencyContext, WidgetTemplate widgetTemplate, string identifierName, VariableCollection variableCollection, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareAsPrefab(string prefabName, string variantName, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data, Dictionary<string, WidgetAttributeTemplate> givenParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareAsWidgetTemplate(WidgetTemplate rootWidgetTemplate, VariableCollection variableCollection, UICodeGenerationVariantExtension variantExtension, Dictionary<string, object> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WidgetTemplate FindLogicalChildrenLocation(WidgetTemplate template)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CommentSection CreateCommentSection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Type GetWidgetTypeWithinPrefabRoots(string typeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfInheritsAnotherPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddInheritedType(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateInto(NamespaceCode namespaceCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenerateAddChildToLogicalLocationMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MethodCode GenerateCreatorMethod()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetUseableName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetUseablePrefabClassName(string name, string variantName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WidgetCodeGenerationInfo FindWidgetCodeGenerationInformation(WidgetTemplate widgetTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateWidgetInformations(WidgetTemplate widgetTemplate, string variableName, WidgetCodeGenerationInfo parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDependencies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillWidgetVariables(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBuiltinType(WidgetTemplate widgetTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenerateCreateWidgetsMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenerateSetIdsMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenerateSetAttributesMethod(ClassCode classCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetCodeFileType(Type type)
	{
		throw null;
	}
}
