using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.BaseTypes;

public class OnlineImageTextureWidget : TextureWidget
{
	public enum ImageSizePolicies
	{
		Stretch,
		OriginalSize,
		ScaleToBiggerDimension
	}

	private string _onlineImageSourceUrl;

	public ImageSizePolicies ImageSizePolicy
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

	[Editor(false)]
	public string OnlineImageSourceUrl
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
	public OnlineImageTextureWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSizePolicy()
	{
		throw null;
	}
}
