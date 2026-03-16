using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineStruct("ftlSphere_data", false, null)]
public struct SphereData
{
	public Vec3 Origin;

	public float Radius;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SphereData(float radius, Vec3 origin)
	{
		throw null;
	}
}
