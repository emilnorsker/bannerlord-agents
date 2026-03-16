using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

internal class EngineScreenManager
{
	private static NativeArrayEnumerator<int> _lastPressedKeys;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EngineScreenManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void PreTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	public static void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void LateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void OnOnscreenKeyboardDone(string inputText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void OnOnscreenKeyboardCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void OnGameWindowFocusChange(bool focusGained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void InitializeLastPressedKeys(NativeArray lastKeysPressed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EngineScreenManager()
	{
		throw null;
	}
}
