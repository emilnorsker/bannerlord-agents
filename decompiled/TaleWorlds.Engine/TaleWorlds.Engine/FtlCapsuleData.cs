using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineStruct("ftlCapsule_data", false, null)]
internal struct FtlCapsuleData
{
	public Vec3 P1;

	public Vec3 P2;

	public float Radius;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoxMin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoxMax()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FtlCapsuleData(float radius, Vec3 p1, Vec3 p2)
	{
		throw null;
	}
}
