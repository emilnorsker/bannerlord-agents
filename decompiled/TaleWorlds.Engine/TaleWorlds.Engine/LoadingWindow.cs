using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine;

public static class LoadingWindow
{
	public static bool IsLoadingWindowActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public static ILoadingWindowManager LoadingWindowManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeWith<T>() where T : class, ILoadingWindowManager, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisableGlobalLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnableGlobalLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCurrentModeIsMultiplayer(bool isMultiplayer)
	{
		throw null;
	}
}
