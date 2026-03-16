using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public class Imgui
{
	public enum ColorStyle
	{
		Text,
		TextDisabled,
		WindowBg,
		ChildWindowBg,
		PopupBg,
		Border,
		BorderShadow,
		FrameBg,
		FrameBgHovered,
		FrameBgActive,
		TitleBg,
		TitleBgCollapsed,
		TitleBgActive,
		MenuBarBg,
		ScrollbarBg,
		ScrollbarGrab,
		ScrollbarGrabHovered,
		ScrollbarGrabActive,
		ComboBg,
		CheckMark,
		SliderGrab,
		SliderGrabActive,
		Button,
		ButtonHovered,
		ButtonActive,
		Header,
		HeaderHovered,
		HeaderActive,
		Column,
		ColumnHovered,
		ColumnActive,
		ResizeGrip,
		ResizeGripHovered,
		ResizeGripActive,
		CloseButton,
		CloseButtonHovered,
		CloseButtonActive,
		PlotLines,
		PlotLinesHovered,
		PlotHistogram,
		PlotHistogramHovered,
		TextSelectedBg,
		ModalWindowDarkening
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginMainThreadScope()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndMainThreadScope()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PushStyleColor(ColorStyle style, ref Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PopStyleColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void NewFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Render()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Begin(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Begin(string text, ref bool is_open)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void End()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Text(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool Checkbox(string text, ref bool is_checked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TreeNode(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TreePop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Separator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool Button(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PlotLines(string name, float[] values, int valuesCount, int valuesOffset, string overlayText, float minScale, float maxScale, float graphWidth, float graphHeight, int stride)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ProgressBar(float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void NewLine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SameLine(float posX = 0f, float spacingWidth = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool Combo(string label, ref int selectedIndex, string items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ComboCustomSeperator(string label, ref int selectedIndex, string items, char seperator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputInt(string label, ref int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SliderFloat(string label, ref float value, float min, float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Columns(int count = 1, string id = "", bool border = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void NextColumn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool RadioButton(string label, bool active)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CollapsingHeader(string label)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsItemHovered()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTooltip(string label)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SmallButton(string label)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputFloat(string label, ref float val, float step, float stepFast, int decimalPrecision = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputText(string label, ref string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputTextMultilineCopyPaste(string label, int textBoxHeight, ref string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputFloat2(string label, ref float val0, ref float val1, int decimalPrecision = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputFloat3(string label, ref float val0, ref float val1, ref float val2, int decimalPrecision = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InputFloat4(string label, ref float val0, ref float val1, ref float val2, ref float val3, int decimalPrecision = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Imgui()
	{
		throw null;
	}
}
