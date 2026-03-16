using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.DotNet;

public class NativeTelemetryManager : ITelemetryManager
{
	public static TelemetryLevelMask TelemetryLevelMask
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
	public TelemetryLevelMask GetTelemetryLevelMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeTelemetryManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartTelemetryConnection(bool showErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopTelemetryConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginTelemetryScopeInternal(TelemetryLevelMask levelMask, string scopeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndTelemetryScopeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginTelemetryScopeBaseLevelInternal(TelemetryLevelMask levelMask, string scopeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndTelemetryScopeBaseLevelInternal()
	{
		throw null;
	}
}
