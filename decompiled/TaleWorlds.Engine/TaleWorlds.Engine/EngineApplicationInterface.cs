using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine;

internal class EngineApplicationInterface
{
	internal static IPath IPath;

	internal static IShader IShader;

	internal static ITexture ITexture;

	internal static IMaterial IMaterial;

	internal static IMetaMesh IMetaMesh;

	internal static IDecal IDecal;

	internal static IClothSimulatorComponent IClothSimulatorComponent;

	internal static ICompositeComponent ICompositeComponent;

	internal static IPhysicsShape IPhysicsShape;

	internal static IBodyPart IBodyPart;

	internal static IParticleSystem IParticleSystem;

	internal static IMesh IMesh;

	internal static IMeshBuilder IMeshBuilder;

	internal static ICamera ICamera;

	internal static ISkeleton ISkeleton;

	internal static IGameEntity IGameEntity;

	internal static IGameEntityComponent IGameEntityComponent;

	internal static IScene IScene;

	internal static IScriptComponent IScriptComponent;

	internal static ILight ILight;

	internal static IAsyncTask IAsyncTask;

	internal static IPhysicsMaterial IPhysicsMaterial;

	internal static ISceneView ISceneView;

	internal static IView IView;

	internal static ITableauView ITableauView;

	internal static ITextureView ITextureView;

	internal static IVideoPlayerView IVideoPlayerView;

	internal static IThumbnailCreatorView IThumbnailCreatorView;

	internal static IDebug IDebug;

	internal static ITwoDimensionView ITwoDimensionView;

	internal static IUtil IUtil;

	internal static IEngineSizeChecker IEngineSizeChecker;

	internal static IInput IInput;

	internal static ITime ITime;

	internal static IScreen IScreen;

	internal static IMusic IMusic;

	internal static IImgui IImgui;

	internal static IMouseManager IMouseManager;

	internal static IHighlights IHighlights;

	internal static ISoundEvent ISoundEvent;

	internal static ISoundManager ISoundManager;

	internal static IConfig IConfig;

	internal static IManagedMeshEditOperations IManagedMeshEditOperations;

	private static Dictionary<string, object> _objects;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T GetObject<T>() where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SetObjects(Dictionary<string, object> objects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EngineApplicationInterface()
	{
		throw null;
	}
}
