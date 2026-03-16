using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public static class WidgetExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetObjectAndProperty(object parent, string name, int nameStartIndex, out object targetObject, out PropertyInfo targetPropertyInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetWidgetAttributeFromString(object target, string name, string value, BrushFactory brushFactory, SpriteData spriteData, Dictionary<string, VisualDefinitionTemplate> visualDefinitionTemplates, Dictionary<string, ConstantDefinition> constants, Dictionary<string, WidgetAttributeTemplate> parameters, Dictionary<string, XmlElement> customElements, Dictionary<string, string> defaultParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetWidgetAttributeFromStringAux(object target, string name, string value, BrushFactory brushFactory, SpriteData spriteData, Dictionary<string, VisualDefinitionTemplate> visualDefinitionTemplates, Dictionary<string, ConstantDefinition> constants, Dictionary<string, WidgetAttributeTemplate> parameters, Dictionary<string, XmlElement> customElements, Dictionary<string, string> defaultParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Type GetWidgetAttributeType(object target, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetWidgetAttribute(UIContext context, object target, string name, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object ConvertObject(UIContext context, object input, Type targetType)
	{
		throw null;
	}
}
