using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Network;

public static class DebugNetworkEventStatistics
{
	public class TotalEventData
	{
		public readonly int TotalPackets;

		public readonly int TotalUpload;

		public readonly int TotalConstantsUpload;

		public readonly int TotalReliableUpload;

		public readonly int TotalReplicationUpload;

		public readonly int TotalUnreliableUpload;

		public readonly int TotalOtherUpload;

		public bool HasData
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected bool Equals(TotalEventData other)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool Equals(object obj)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int GetHashCode()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TotalEventData()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TotalEventData(int totalPackets, int totalUpload, int totalConstants, int totalReliable, int totalReplication, int totalUnreliable)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TotalEventData operator -(TotalEventData d1, TotalEventData d2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool operator ==(TotalEventData d1, TotalEventData d2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool operator !=(TotalEventData d1, TotalEventData d2)
		{
			throw null;
		}
	}

	private class PerEventData : IComparable<PerEventData>
	{
		public string Name;

		public int DataSize;

		public int TotalDataSize;

		public int Count;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int CompareTo(PerEventData other)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PerEventData()
		{
			throw null;
		}
	}

	public class PerSecondEventData
	{
		public readonly int TotalUploadPerSecond;

		public readonly int ConstantsUploadPerSecond;

		public readonly int ReliableUploadPerSecond;

		public readonly int ReplicationUploadPerSecond;

		public readonly int UnreliableUploadPerSecond;

		public readonly int OtherUploadPerSecond;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PerSecondEventData(int totalUploadPerSecond, int constantsUploadPerSecond, int reliableUploadPerSecond, int replicationUploadPerSecond, int unreliableUploadPerSecond, int otherUploadPerSecond)
		{
			throw null;
		}
	}

	private class TotalData
	{
		public float TotalTime;

		public int TotalFrameCount;

		public int TotalCount;

		public int TotalDataSize;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TotalData()
		{
			throw null;
		}
	}

	private static TotalData _totalData;

	private static int _curEventType;

	private static Dictionary<int, PerEventData> _statistics;

	private static int _samplesPerSecond;

	public static int MaxGraphPointCount;

	private static bool _showUploadDataText;

	private static bool _useAbsoluteMaximum;

	private static float _collectSampleCheck;

	private static float _collectFpsSampleCheck;

	private static float _curMaxGraphHeight;

	private static float _targetMaxGraphHeight;

	private static float _currMaxLossGraphHeight;

	private static float _targetMaxLossGraphHeight;

	private static PerSecondEventData UploadPerSecondEventData;

	private static readonly Queue<TotalEventData> _eventSamples;

	private static readonly Queue<float> _lossSamples;

	private static TotalEventData _prevEventData;

	private static TotalEventData _currEventData;

	private static readonly List<float> _fpsSamplesUntilNextSampling;

	private static readonly Queue<float> _fpsSamples;

	private static bool _useImgui;

	public static bool TrackFps;

	public static int SamplesPerSecond
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public static bool IsActive
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

	public static event Action<IEnumerable<TotalEventData>> OnEventDataUpdated
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

	public static event Action<PerSecondEventData> OnPerSecondEventDataUpdated
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

	public static event Action<IEnumerable<float>> OnFPSEventUpdated
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

	public static event Action OnOpenExternalMonitor
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
	static DebugNetworkEventStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void StartEvent(string eventName, int eventType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void EndEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AddDataToStatistic(int bitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenExternalMonitor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlJustDump()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlDumpAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlClear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearNetGraphs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearFpsGraph()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlClearAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ControlDumpReplicationData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectFpsSample(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ToggleActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DumpData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetFormattedDebugUploadDataOutput(ref MBStringBuilder outStr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShowUploadData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TotalEventData GetCurrentEventData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DumpReplicationData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ClearReplicationData()
	{
		throw null;
	}
}
