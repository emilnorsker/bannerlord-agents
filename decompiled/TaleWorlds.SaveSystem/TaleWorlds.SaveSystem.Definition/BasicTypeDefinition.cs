using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem.Definition;

internal class BasicTypeDefinition : TypeDefinitionBase
{
	public IBasicTypeSerializer Serializer
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
	public BasicTypeDefinition(Type type, int saveId, IBasicTypeSerializer serializer)
	{
		throw null;
	}
}
