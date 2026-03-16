using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using TaleWorlds.TwoDimension.Standalone.Native.Windows;

namespace TaleWorlds.TwoDimension.Standalone;

public class LayeredWindowController
{
	private const int GwlExStyle = -20;

	private const uint WsExLayered = 524288u;

	private readonly IntPtr _windowHandle;

	private readonly IntPtr _screenDC;

	private readonly IntPtr _memoryDC;

	private Size _windowSize;

	private byte[] _pixelData;

	private BlendFunction _blendFunction;

	private System.Drawing.Point _localOriginPoint;

	private BitmapInfo _bitmapInfo;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LayeredWindowController(IntPtr windowHandle, int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateBitmapInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PostRender()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}
}
