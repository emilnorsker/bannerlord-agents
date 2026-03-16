using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[Obsolete]
public class DestructedPrefabInfoMissionObject : MissionObject
{
	public string DestructedPrefabName;

	public Vec3 Translate;

	public Vec3 Rotation;

	public Vec3 Scale;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DestructedPrefabInfoMissionObject()
	{
		throw null;
	}
}
