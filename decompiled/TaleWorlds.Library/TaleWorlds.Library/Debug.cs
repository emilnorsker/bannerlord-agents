using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class Debug
{
	public enum DebugColor
	{
		DarkRed,
		DarkGreen,
		DarkBlue,
		Red,
		Green,
		Blue,
		DarkCyan,
		Cyan,
		DarkYellow,
		Yellow,
		Purple,
		Magenta,
		White,
		BrightWhite
	}

	public enum DebugUserFilter : ulong
	{
		None = 0uL,
		Unused0 = 1uL,
		Unused1 = 2uL,
		Koray = 4uL,
		Armagan = 8uL,
		Intern = 16uL,
		Mustafa = 32uL,
		Oguzhan = 64uL,
		Omer = 128uL,
		Ates = 256uL,
		Unused3 = 512uL,
		Basak = 1024uL,
		Can = 2048uL,
		Unused4 = 4096uL,
		Cem = 8192uL,
		Unused5 = 16384uL,
		Unused6 = 32768uL,
		Emircan = 65536uL,
		Unused7 = 131072uL,
		All = 4294967295uL,
		Default = 0uL,
		DamageDebug = 72uL
	}

	public enum DebugSystemFilter : ulong
	{
		None = 0uL,
		Graphics = 4294967296uL,
		ArtificialIntelligence = 8589934592uL,
		MultiPlayer = 17179869184uL,
		IO = 34359738368uL,
		Network = 68719476736uL,
		CampaignEvents = 137438953472uL,
		MemoryManager = 274877906944uL,
		TCP = 549755813888uL,
		FileManager = 1099511627776uL,
		NaturalInteractionDevice = 2199023255552uL,
		UDP = 4398046511104uL,
		ResourceManager = 8796093022208uL,
		Mono = 17592186044416uL,
		ONO = 35184372088832uL,
		Old = 70368744177664uL,
		Sound = 281474976710656uL,
		CombatLog = 562949953421312uL,
		Notifications = 1125899906842624uL,
		Quest = 2251799813685248uL,
		Dialog = 4503599627370496uL,
		Steam = 9007199254740992uL,
		All = 18446744069414584320uL,
		DefaultMask = 18446744069414584320uL
	}

	public static IDebugManager DebugManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public static ITelemetryManager TelemetryManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public static event Action<string, ulong> OnPrint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TelemetryLevelMask GetTelemetryLevelMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCrashReportCustomString(string customString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCrashReportCustomStack(string customStack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void Assert(bool condition, string message, [CallerFilePath] string callerFile = "", [CallerMemberName] string callerMethod = "", [CallerLineNumber] int callerLine = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FailedAssert(string message, [CallerFilePath] string callerFile = "", [CallerMemberName] string callerMethod = "", [CallerLineNumber] int callerLine = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SilentAssert(bool condition, string message = "", bool getDump = false, [CallerFilePath] string callerFile = "", [CallerMemberName] string callerMethod = "", [CallerLineNumber] int callerLine = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ShowError(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DoDelayedexit(int returnCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void ShowWarning(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReportMemoryBookmark(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Print(string message, int logLevel = 0, DebugColor color = DebugColor.White, ulong debugFilter = 17592186044416uL)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ShowMessageBox(string lpText, string lpCaption, uint uType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void PrintWarning(string warning, ulong debugFilter = 17592186044416uL)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void PrintError(string error, string stackTrace = null, ulong debugFilter = 17592186044416uL)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void DisplayDebugMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void WatchVariable(string name, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("NOT_SHIPPING")]
	[Conditional("ENABLE_PROFILING_APIS_IN_SHIPPING")]
	public static void StartTelemetryConnection(bool showErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("NOT_SHIPPING")]
	[Conditional("ENABLE_PROFILING_APIS_IN_SHIPPING")]
	public static void StopTelemetryConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("NOT_SHIPPING")]
	[Conditional("ENABLE_PROFILING_APIS_IN_SHIPPING")]
	internal static void BeginTelemetryScopeInternal(TelemetryLevelMask levelMask, string scopeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("NOT_SHIPPING")]
	[Conditional("ENABLE_PROFILING_APIS_IN_SHIPPING")]
	internal static void BeginTelemetryScopeBaseLevelInternal(TelemetryLevelMask levelMask, string scopeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("NOT_SHIPPING")]
	[Conditional("ENABLE_PROFILING_APIS_IN_SHIPPING")]
	internal static void EndTelemetryScopeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("NOT_SHIPPING")]
	[Conditional("ENABLE_PROFILING_APIS_IN_SHIPPING")]
	internal static void EndTelemetryScopeBaseLevelInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void WriteDebugLineOnScreen(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugLine(Vec3 position, Vec3 direction, uint color = uint.MaxValue, bool depthCheck = false, float time = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugLineWithThickness(Vec3 position, Vec3 direction, uint color = uint.MaxValue, bool depthCheck = false, float time = 0f, int thickness = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugSphere(Vec3 position, float radius, uint color = uint.MaxValue, bool depthCheck = false, float time = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugFrame(MatrixFrame frame, float lineLength, float time = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugText(float screenX, float screenY, string text, uint color = uint.MaxValue, float time = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugRectWithColor(float left, float bottom, float right, float top, uint color = uint.MaxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void RenderDebugText3D(Vec3 position, string text, uint color = uint.MaxValue, int screenPosOffsetX = 0, int screenPosOffsetY = 0, float time = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 GetDebugVector()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDebugVector(Vec3 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTestModeEnabled(bool testModeEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AbortGame()
	{
		throw null;
	}
}
