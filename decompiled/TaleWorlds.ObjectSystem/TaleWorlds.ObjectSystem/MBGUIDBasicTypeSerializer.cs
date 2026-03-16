using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem.Definition;

namespace TaleWorlds.ObjectSystem;

internal class MBGUIDBasicTypeSerializer : IBasicTypeSerializer
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
	public MBGUIDBasicTypeSerializer()
	{
		throw null;
	}
}
