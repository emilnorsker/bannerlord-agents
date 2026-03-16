using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public class ReplayCaptureLogic : MissionView
{
	private ReplayMissionView _replayLogic;

	private bool _renderActive;

	public const float CaptureFrameRate = 60f;

	private float _replayTimeDiff;

	private bool _frameSkip;

	private Path _path;

	private PlatformDirectoryPath _directoryPath;

	private bool _saveScreenshots;

	private readonly KeyValuePair<float, MatrixFrame> _invalid;

	private SortedDictionary<float, SortedDictionary<int, MatrixFrame>> _cameraKeys;

	private bool _isRendered;

	private int _lastUsedIndex;

	private int _ssNum;

	private bool RenderActive
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

	private Camera MissionCamera
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float ReplayTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool SaveScreenshots
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

	private KeyValuePair<float, MatrixFrame> PreviousKey
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private KeyValuePair<float, MatrixFrame> NextKey
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckFixedDeltaTimeMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KeyValuePair<float, MatrixFrame> GetPreviousKey()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private KeyValuePair<float, MatrixFrame> GetNextKey()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplayCaptureLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InsertCamKey()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveToNextFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GoToKey(float keyTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Render(bool saveScreenshots = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SaveScreenshot()
	{
		throw null;
	}
}
