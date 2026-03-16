using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public class WidgetAttributeContext
{
	private List<WidgetAttributeKeyType> _registeredKeyTypes;

	private List<WidgetAttributeValueType> _registeredValueTypes;

	private WidgetAttributeKeyTypeAttribute _widgetAttributeKeyTypeAttribute;

	private WidgetAttributeValueTypeDefault _widgetAttributeValueTypeDefault;

	public IEnumerable<WidgetAttributeKeyType> RegisteredKeyTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<WidgetAttributeValueType> RegisteredValueTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetAttributeContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterKeyType(WidgetAttributeKeyType keyType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterValueType(WidgetAttributeValueType valueType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetAttributeKeyType GetKeyType(string key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WidgetAttributeValueType GetValueType(string value)
	{
		throw null;
	}
}
