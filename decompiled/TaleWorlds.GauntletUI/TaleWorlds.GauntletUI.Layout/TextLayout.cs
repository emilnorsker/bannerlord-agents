using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.GauntletUI.Layout;

public class TextLayout : ILayout
{
	private ILayout _defaultLayout;

	private IText _text;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextLayout(IText text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vector2 ILayout.MeasureChildren(Widget widget, Vector2 measureSpec, SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILayout.OnLayout(Widget widget, float left, float bottom, float right, float top)
	{
		throw null;
	}
}
