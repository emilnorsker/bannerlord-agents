using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIImgui : IImgui
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BeginDelegate(byte[] text);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BeginMainThreadScopeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BeginWithCloseButtonDelegate(byte[] text, [MarshalAs(UnmanagedType.U1)] ref bool is_open);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ButtonDelegate(byte[] text);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckboxDelegate(byte[] text, [MarshalAs(UnmanagedType.U1)] ref bool is_checked);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CollapsingHeaderDelegate(byte[] label);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ColumnsDelegate(int count, byte[] id, [MarshalAs(UnmanagedType.U1)] bool border);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ComboDelegate(byte[] label, ref int selectedIndex, byte[] items);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ComboCustomSeperatorDelegate(byte[] label, ref int selectedIndex, byte[] items, byte[] seperator);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EndDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EndMainThreadScopeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool InputFloatDelegate(byte[] label, ref float val, float step, float stepFast, int decimalPrecision);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool InputFloat2Delegate(byte[] label, ref float val0, ref float val1, int decimalPrecision);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool InputFloat3Delegate(byte[] label, ref float val0, ref float val1, ref float val2, int decimalPrecision);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool InputFloat4Delegate(byte[] label, ref float val0, ref float val1, ref float val2, ref float val3, int decimalPrecision);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool InputIntDelegate(byte[] label, ref int value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int InputTextDelegate(byte[] label, byte[] inputTest, [MarshalAs(UnmanagedType.U1)] ref bool changed);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int InputTextMultilineCopyPasteDelegate(byte[] label, byte[] inputTest, int textBoxHeight, [MarshalAs(UnmanagedType.U1)] ref bool changed);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsItemHoveredDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void NewFrameDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void NewLineDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void NextColumnDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PlotLinesDelegate(byte[] name, IntPtr values, int valuesCount, int valuesOffset, byte[] overlayText, float minScale, float maxScale, float graphWidth, float graphHeight, int stride);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PopStyleColorDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ProgressBarDelegate(float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PushStyleColorDelegate(int style, ref Vec3 color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RadioButtonDelegate(byte[] label, [MarshalAs(UnmanagedType.U1)] bool active);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SameLineDelegate(float posX, float spacingWidth);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SeparatorDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTooltipDelegate(byte[] label);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SliderFloatDelegate(byte[] label, ref float value, float min, float max);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SmallButtonDelegate(byte[] label);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TextDelegate(byte[] text);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool TreeNodeDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TreePopDelegate();

	private static readonly Encoding _utf8;

	public static BeginDelegate call_BeginDelegate;

	public static BeginMainThreadScopeDelegate call_BeginMainThreadScopeDelegate;

	public static BeginWithCloseButtonDelegate call_BeginWithCloseButtonDelegate;

	public static ButtonDelegate call_ButtonDelegate;

	public static CheckboxDelegate call_CheckboxDelegate;

	public static CollapsingHeaderDelegate call_CollapsingHeaderDelegate;

	public static ColumnsDelegate call_ColumnsDelegate;

	public static ComboDelegate call_ComboDelegate;

	public static ComboCustomSeperatorDelegate call_ComboCustomSeperatorDelegate;

	public static EndDelegate call_EndDelegate;

	public static EndMainThreadScopeDelegate call_EndMainThreadScopeDelegate;

	public static InputFloatDelegate call_InputFloatDelegate;

	public static InputFloat2Delegate call_InputFloat2Delegate;

	public static InputFloat3Delegate call_InputFloat3Delegate;

	public static InputFloat4Delegate call_InputFloat4Delegate;

	public static InputIntDelegate call_InputIntDelegate;

	public static InputTextDelegate call_InputTextDelegate;

	public static InputTextMultilineCopyPasteDelegate call_InputTextMultilineCopyPasteDelegate;

	public static IsItemHoveredDelegate call_IsItemHoveredDelegate;

	public static NewFrameDelegate call_NewFrameDelegate;

	public static NewLineDelegate call_NewLineDelegate;

	public static NextColumnDelegate call_NextColumnDelegate;

	public static PlotLinesDelegate call_PlotLinesDelegate;

	public static PopStyleColorDelegate call_PopStyleColorDelegate;

	public static ProgressBarDelegate call_ProgressBarDelegate;

	public static PushStyleColorDelegate call_PushStyleColorDelegate;

	public static RadioButtonDelegate call_RadioButtonDelegate;

	public static RenderDelegate call_RenderDelegate;

	public static SameLineDelegate call_SameLineDelegate;

	public static SeparatorDelegate call_SeparatorDelegate;

	public static SetTooltipDelegate call_SetTooltipDelegate;

	public static SliderFloatDelegate call_SliderFloatDelegate;

	public static SmallButtonDelegate call_SmallButtonDelegate;

	public static TextDelegate call_TextDelegate;

	public static TreeNodeDelegate call_TreeNodeDelegate;

	public static TreePopDelegate call_TreePopDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Begin(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginMainThreadScope()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginWithCloseButton(string text, ref bool is_open)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Button(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Checkbox(string text, ref bool is_checked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CollapsingHeader(string label)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Columns(int count, string id, bool border)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Combo(string label, ref int selectedIndex, string items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ComboCustomSeperator(string label, ref int selectedIndex, string items, string seperator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void End()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndMainThreadScope()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InputFloat(string label, ref float val, float step, float stepFast, int decimalPrecision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InputFloat2(string label, ref float val0, ref float val1, int decimalPrecision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InputFloat3(string label, ref float val0, ref float val1, ref float val2, int decimalPrecision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InputFloat4(string label, ref float val0, ref float val1, ref float val2, ref float val3, int decimalPrecision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InputInt(string label, ref int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string InputText(string label, string inputTest, ref bool changed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string InputTextMultilineCopyPaste(string label, string inputTest, int textBoxHeight, ref bool changed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsItemHovered()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void NewFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void NewLine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void NextColumn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlotLines(string name, float[] values, int valuesCount, int valuesOffset, string overlayText, float minScale, float maxScale, float graphWidth, float graphHeight, int stride)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PopStyleColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProgressBar(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PushStyleColor(int style, ref Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RadioButton(string label, bool active)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Render()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SameLine(float posX, float spacingWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Separator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTooltip(string label)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SliderFloat(string label, ref float value, float min, float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SmallButton(string label)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Text(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TreeNode(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TreePop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIImgui()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIImgui()
	{
		throw null;
	}
}
