using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public class WidgetPrefab
{
	public Dictionary<string, VisualDefinitionTemplate> VisualDefinitionTemplates
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

	public Dictionary<string, ConstantDefinition> Constants
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

	public Dictionary<string, string> Parameters
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

	public Dictionary<string, XmlElement> CustomElements
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

	public WidgetTemplate RootTemplate
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
	public WidgetPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Dictionary<string, VisualDefinitionTemplate> LoadVisualDefinitions(XmlNode visualDefinitionsNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SaveVisualDefinitionsTo(XmlNode visualDefinitionsNode, Dictionary<string, VisualDefinitionTemplate> visualDefinitionTemplates)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Dictionary<string, string> LoadParameters(XmlNode constantsNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Dictionary<string, XmlElement> LoadCustomElements(XmlNode customElementsNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SaveParametersTo(XmlNode parametersNode, Dictionary<string, string> parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Dictionary<string, ConstantDefinition> LoadConstants(XmlNode constantsNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SaveConstantsTo(XmlNode constantsNode, Dictionary<string, ConstantDefinition> constants)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WidgetPrefab LoadFrom(PrefabExtensionContext prefabExtensionContext, WidgetAttributeContext widgetAttributeContext, string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public XmlDocument Save(PrefabExtensionContext prefabExtensionContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetInstantiationResult Instantiate(WidgetCreationData widgetCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetInstantiationResult Instantiate(WidgetCreationData widgetCreationData, Dictionary<string, WidgetAttributeTemplate> parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRelease()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConstantDefinition GetConstantValue(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetParameterDefaultValue(string name)
	{
		throw null;
	}
}
