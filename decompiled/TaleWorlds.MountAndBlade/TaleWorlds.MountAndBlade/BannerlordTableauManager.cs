using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public static class BannerlordTableauManager
{
	public delegate void RequestCharacterTableauSetupDelegate(int characterCodeId, Scene scene, GameEntity poseEntity);

	private static Scene[] _tableauCharacterScenes;

	private static bool _isTableauRenderSystemInitialized;

	public static RequestCharacterTableauSetupDelegate RequestCallback;

	public static Scene[] TableauCharacterScenes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RequestCharacterTableauRender(int characterCodeId, string path, GameEntity poseEntity, Camera cameraObject, int tableauType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeCharacterTableauRenderSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfPendingTableauRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void RequestCharacterTableauSetup(int characterCodeId, Scene scene, GameEntity poseEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void RegisterCharacterTableauScene(Scene scene, int type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BannerlordTableauManager()
	{
		throw null;
	}
}
