using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MBDebugManager : IDebugManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.SetCrashReportCustomString(string customString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.SetCrashReportCustomStack(string customStack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.ShowWarning(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.ShowError(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.ShowMessageBox(string lpText, string lpCaption, uint uType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.Assert(bool condition, string message, string callerFile, string callerMethod, int callerLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.SilentAssert(bool condition, string message, bool getDump, string callerFile, string callerMethod, int callerLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.Print(string message, int logLevel, Debug.DebugColor color, ulong debugFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.PrintError(string error, string stackTrace, ulong debugFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.PrintWarning(string warning, ulong debugFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.DisplayDebugMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.WatchVariable(string name, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.WriteDebugLineOnScreen(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.RenderDebugLine(Vec3 position, Vec3 direction, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.RenderDebugSphere(Vec3 position, float radius, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.RenderDebugFrame(MatrixFrame frame, float lineLength, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.RenderDebugText(float screenX, float screenY, string text, uint color, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.RenderDebugText3D(Vec3 position, string text, uint color, int screenPosOffsetX, int screenPosOffsetY, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.RenderDebugRectWithColor(float left, float bottom, float right, float top, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec3 IDebugManager.GetDebugVector()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.SetDebugVector(Vec3 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.SetTestModeEnabled(bool testModeEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.AbortGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.DoDelayedexit(int returnCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDebugManager.ReportMemoryBookmark(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBDebugManager()
	{
		throw null;
	}
}
