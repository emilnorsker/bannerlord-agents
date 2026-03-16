using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TaleWorlds.Engine;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.View.Screens.Scripts;

public class MultiThreadedStressTestsScreen : ScreenBase
{
	public static class MultiThreadedTestFunctions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void MeshMerger(InputLayout layout)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SceneHandler(SceneView view)
		{
			throw null;
		}
	}

	private List<Thread> _workerThreads;

	private Scene _scene;

	private SceneView _sceneView;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiThreadedStressTestsScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}
}
