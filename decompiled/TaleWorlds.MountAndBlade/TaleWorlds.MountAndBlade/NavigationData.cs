using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[Serializable]
[EngineStruct("Navigation_data", false, null)]
public struct NavigationData
{
	private const int MaxPathSize = 1024;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public Vec2[] Points;

	public Vec3 StartPoint;

	public Vec3 EndPoint;

	public readonly int PointSize;

	public readonly float AgentRadius;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavigationData(Vec3 startPoint, Vec3 endPoint, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public void TickDebug()
	{
		throw null;
	}
}
