using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension.Standalone.Native.Windows;

namespace TaleWorlds.TwoDimension.Standalone;

public class GraphicsForm : IMessageCommunicator
{
	public const int WM_NCLBUTTONDOWN = 161;

	public const int HT_CAPTION = 2;

	private WindowsForm _windowsForm;

	private InputData _currentInputData;

	private InputData _oldInputData;

	private InputData _messageLoopInputData;

	private object _inputDataLocker;

	private bool _mouseOverDragArea;

	private bool _isDragging;

	private LayeredWindowController _layeredWindowController;

	public GraphicsContext GraphicsContext
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

	public int Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GraphicsForm(int width, int height, ResourceDepot resourceDepot, bool borderlessWindow = false, bool enableWindowBlur = false, bool layeredWindow = false, string name = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GraphicsForm(int x, int y, int width, int height, ResourceDepot resourceDepot, bool borderlessWindow = false, bool enableWindowBlur = false, bool layeredWindow = false, string name = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GraphicsForm(WindowsForm windowsForm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initalize(bool layeredWindow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CompareRecrangles(DXGI.RECT Rect1, DXGI.RECT Rect2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DXGI.RECT DecideWindowPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MinimizeWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeGraphicsContext(ResourceDepot resourceDepot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MessageLoop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateInput(bool mouseOverDragArea = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PostRender()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetKeyDown(InputKey keyCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetKey(InputKey keyCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetKeyUp(InputKey keyCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMouseDeltaZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool LeftMouse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool LeftMouseDown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool LeftMouseUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RightMouse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RightMouseDown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RightMouseUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 MousePosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool MouseMove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillInputDataFromCurrent(InputData inputData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MessageHandler(WindowMessage message, long wParam, long lParam)
	{
		throw null;
	}
}
