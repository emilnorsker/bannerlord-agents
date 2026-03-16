using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public abstract class PrefabExtension
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void RegisterAttributeTypes(WidgetAttributeContext widgetAttributeContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnWidgetCreated(WidgetCreationData widgetCreationData, WidgetInstantiationResult widgetInstantiationResult, int childCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnSave(PrefabExtensionContext prefabExtensionContext, XmlNode node, WidgetTemplate widgetTemplate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnAttributesSet(WidgetCreationData widgetCreationData, WidgetInstantiationResult widgetInstantiationResult, Dictionary<string, WidgetAttributeTemplate> parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void DoLoading(PrefabExtensionContext prefabExtensionContext, WidgetAttributeContext widgetAttributeContext, WidgetTemplate template, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnLoadingFinished(WidgetPrefab widgetPrefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void AfterAttributesSet(WidgetCreationData widgetCreationData, WidgetInstantiationResult widgetInstantiationResult, Dictionary<string, WidgetAttributeTemplate> parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PrefabExtension()
	{
		throw null;
	}
}
