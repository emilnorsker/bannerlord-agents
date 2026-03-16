using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class EditorAttribute : Attribute
{
	public readonly bool IncludeInnerProperties;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EditorAttribute(bool includeInnerProperties = false)
	{
		throw null;
	}
}
