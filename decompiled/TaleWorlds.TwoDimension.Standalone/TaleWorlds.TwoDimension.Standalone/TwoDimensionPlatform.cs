using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension.Standalone;

public class TwoDimensionPlatform : ITwoDimensionPlatform, ITwoDimensionResourceContext
{
	private GraphicsContext _graphicsContext;

	private GraphicsForm _form;

	private bool _isAssetsUnderDefaultFolders;

	float ITwoDimensionPlatform.Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	float ITwoDimensionPlatform.Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	float ITwoDimensionPlatform.ReferenceWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	float ITwoDimensionPlatform.ReferenceHeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	float ITwoDimensionPlatform.ApplicationTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TwoDimensionPlatform(GraphicsForm form, bool isAssetsUnderDefaultFolders)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	void ITwoDimensionPlatform.DrawImage(SimpleMaterial material, in ImageDrawObject drawObject2D, int layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	void ITwoDimensionPlatform.DrawText(TextMaterial material, in TextDrawObject drawObject2D, int layer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	void ITwoDimensionPlatform.OnFrameBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	void ITwoDimensionPlatform.OnFrameEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	void ITwoDimensionPlatform.Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Texture ITwoDimensionResourceContext.LoadTexture(ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.PlaySound(string soundName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.SetScissor(ScissorTestInfo scissorTestInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.ResetScissors()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.CreateSoundEvent(string soundName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.StopAndRemoveSoundEvent(string soundName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.PlaySoundEvent(string soundName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.OpenOnScreenKeyboard(string initialText, string descriptionText, int maxLength, int keyboardTypeEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.BeginDebugPanel(string panelTitle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.EndDebugPanel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.DrawDebugText(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ITwoDimensionPlatform.IsDebugModeEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ITwoDimensionPlatform.DrawDebugTreeNode(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.DrawCheckbox(string label, ref bool isChecked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool ITwoDimensionPlatform.IsDebugItemHovered()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITwoDimensionPlatform.PopDebugTreeNode()
	{
		throw null;
	}
}
