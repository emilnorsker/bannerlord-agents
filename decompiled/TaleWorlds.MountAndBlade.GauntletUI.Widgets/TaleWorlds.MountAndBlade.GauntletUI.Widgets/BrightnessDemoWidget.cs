using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets;

public class BrightnessDemoWidget : TextureWidget
{
	public enum DemoTypes
	{
		None = -1,
		BrightnessWide,
		ExposureTexture1,
		ExposureTexture2,
		ExposureTexture3,
		ExposureTexture4,
		ExposureTexture5,
		ExposureTexture6
	}

	private DemoTypes _demoType;

	[Editor(false)]
	public DemoTypes DemoType
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BrightnessDemoWidget(UIContext context)
	{
		throw null;
	}
}
