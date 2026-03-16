using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public readonly struct UndoRedoKey
{
	public readonly int Gender;

	public readonly int Race;

	public readonly BodyProperties BodyProperties;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UndoRedoKey(int gender, int race, BodyProperties bodyProperties)
	{
		throw null;
	}
}
