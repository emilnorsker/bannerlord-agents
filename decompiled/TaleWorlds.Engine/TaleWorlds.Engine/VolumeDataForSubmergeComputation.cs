using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
[EngineStruct("rglWater_renderer::Volume_data_for_submerge_computation", false, null)]
public struct VolumeDataForSubmergeComputation
{
	public Vec3 DynamicLocalBottomPos;

	public MatrixFrame LocalFrame;

	public Vec3 LocalScale;

	public FloaterVolumeDynamicUpAxis DynamicUpAxis;

	public Vec3 OutGlobalWaterSurfaceNormal;

	public float InOutWaterHeightWrtVolume;

	public float Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Depth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 Up
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 Side
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 Forward
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}
}
