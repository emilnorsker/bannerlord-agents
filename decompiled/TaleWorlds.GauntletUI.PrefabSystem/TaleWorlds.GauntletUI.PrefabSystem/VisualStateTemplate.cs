using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public class VisualStateTemplate
{
	private Dictionary<string, string> _attributes;

	public string State
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualStateTemplate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAttribute(string name, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, string> GetAttributes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAttribute(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualState CreateVisualState(BrushFactory brushFactory, SpriteData spriteData, Dictionary<string, VisualDefinitionTemplate> visualDefinitionTemplates, Dictionary<string, ConstantDefinition> constants, Dictionary<string, WidgetAttributeTemplate> parameters, Dictionary<string, string> defaultParameters)
	{
		throw null;
	}
}
