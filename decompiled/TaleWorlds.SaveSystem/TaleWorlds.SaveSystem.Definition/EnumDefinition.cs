using System;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem.Resolvers;

namespace TaleWorlds.SaveSystem.Definition;

internal class EnumDefinition : TypeDefinitionBase
{
	public readonly IEnumResolver Resolver;

	public readonly bool HasFlags;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnumDefinition(Type type, SaveId saveId, IEnumResolver resolver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnumDefinition(Type type, int saveId, IEnumResolver resolver)
	{
		throw null;
	}
}
