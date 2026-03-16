using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem.Definition;

internal class Vec2BasicTypeSerializer : IBasicTypeSerializer
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBasicTypeSerializer.Serialize(IWriter writer, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	object IBasicTypeSerializer.Deserialize(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	int IBasicTypeSerializer.GetSizeInBytes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2BasicTypeSerializer()
	{
		throw null;
	}
}
