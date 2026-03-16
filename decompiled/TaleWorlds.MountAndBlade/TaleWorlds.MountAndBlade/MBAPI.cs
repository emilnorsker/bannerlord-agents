using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public static class MBAPI
{
	internal static IMBTestRun IMBTestRun;

	internal static IMBActionSet IMBActionSet;

	internal static IMBAgent IMBAgent;

	internal static IMBAgentVisuals IMBAgentVisuals;

	internal static IMBAnimation IMBAnimation;

	internal static IMBDelegate IMBDelegate;

	internal static IMBItem IMBItem;

	internal static IMBEditor IMBEditor;

	internal static IMBMission IMBMission;

	internal static IMBMultiplayerData IMBMultiplayerData;

	internal static IMouseManager IMouseManager;

	internal static IMBNetwork IMBNetwork;

	internal static IMBPeer IMBPeer;

	internal static IMBSkeletonExtensions IMBSkeletonExtensions;

	internal static IMBGameEntityExtensions IMBGameEntityExtensions;

	internal static IMBScreen IMBScreen;

	internal static IMBSoundEvent IMBSoundEvent;

	internal static IMBVoiceManager IMBVoiceManager;

	internal static IMBTeam IMBTeam;

	internal static IMBWorld IMBWorld;

	internal static IInput IInput;

	internal static IMBMessageManager IMBMessageManager;

	internal static IMBWindowManager IMBWindowManager;

	internal static IMBDebugExtensions IMBDebugExtensions;

	internal static IMBGame IMBGame;

	internal static IMBFaceGen IMBFaceGen;

	internal static IMBMapScene IMBMapScene;

	internal static IMBBannerlordChecker IMBBannerlordChecker;

	internal static IMBBannerlordTableauManager IMBBannerlordTableauManager;

	internal static IMBBannerlordConfig IMBBannerlordConfig;

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
}
