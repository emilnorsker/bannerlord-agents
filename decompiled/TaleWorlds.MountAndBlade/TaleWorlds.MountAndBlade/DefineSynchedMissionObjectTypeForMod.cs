using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class DefineSynchedMissionObjectTypeForMod : Attribute
{
	public readonly Type Type;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefineSynchedMissionObjectTypeForMod(Type type)
	{
		throw null;
	}
}
