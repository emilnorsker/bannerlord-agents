using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
internal sealed class DefineSynchedMissionObjectType : Attribute
{
	public readonly Type Type;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefineSynchedMissionObjectType(Type type)
	{
		throw null;
	}
}
