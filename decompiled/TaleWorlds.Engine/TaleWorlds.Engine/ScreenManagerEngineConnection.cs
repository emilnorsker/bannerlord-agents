using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.Engine;

public class ScreenManagerEngineConnection : IScreenManagerEngineConnection
{
	float IScreenManagerEngineConnection.RealScreenResolutionWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	float IScreenManagerEngineConnection.RealScreenResolutionHeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	float IScreenManagerEngineConnection.AspectRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	Vec2 IScreenManagerEngineConnection.DesktopResolution
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScreenManagerEngineConnection.ActivateMouseCursor(CursorType mouseId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScreenManagerEngineConnection.SetMouseVisible(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScreenManagerEngineConnection.GetMouseVisible()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScreenManagerEngineConnection.GetIsEnterButtonRDown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScreenManagerEngineConnection.BeginDebugPanel(string panelTitle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScreenManagerEngineConnection.EndDebugPanel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScreenManagerEngineConnection.DrawDebugText(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScreenManagerEngineConnection.DrawDebugTreeNode(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScreenManagerEngineConnection.PopDebugTreeNode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScreenManagerEngineConnection()
	{
		throw null;
	}
}
