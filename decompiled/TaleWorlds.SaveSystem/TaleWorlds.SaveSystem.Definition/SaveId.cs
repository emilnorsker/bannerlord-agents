using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem.Definition;

public abstract class SaveId
{
	public abstract string GetStringId();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	public abstract void WriteTo(IWriter writer);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveId ReadSaveIdFrom(IReader reader)
	{
		throw null;
	}

	public abstract int GetSizeInBytes();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected SaveId()
	{
		throw null;
	}
}
