using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineStruct("rglScene_initialization_data", false, null)]
public struct SceneInitializationData
{
	public MatrixFrame CamPosFromScene;

	[MarshalAs(UnmanagedType.U1)]
	public bool InitPhysicsWorld;

	[MarshalAs(UnmanagedType.U1)]
	public bool LoadNavMesh;

	[MarshalAs(UnmanagedType.U1)]
	public bool InitFloraNodes;

	[MarshalAs(UnmanagedType.U1)]
	public bool UsePhysicsMaterials;

	[MarshalAs(UnmanagedType.U1)]
	public bool EnableFloraPhysics;

	[MarshalAs(UnmanagedType.U1)]
	public bool UseTerrainMeshBlending;

	[MarshalAs(UnmanagedType.U1)]
	public bool DoNotUseLoadingScreen;

	[MarshalAs(UnmanagedType.U1)]
	public bool CreateOros;

	[MarshalAs(UnmanagedType.U1)]
	public bool ForTerrainShaderCompile;

	[MarshalAs(UnmanagedType.U1)]
	public bool InitSkyboxFromStart;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SceneInitializationData(bool initializeWithDefaults)
	{
		throw null;
	}
}
