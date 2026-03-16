using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public class RichText : IText
{
	public ILanguage CurrentLanguage;

	private TextHorizontalAlignment _horizontalAlignment;

	private TextVerticalAlignment _verticalAlignment;

	private bool _meshNeedsUpdate;

	private bool _preferredSizeNeedsUpdate;

	private bool _positionNeedsUpdate;

	private bool _tokensNeedUpdate;

	private bool _isFixedWidth;

	private bool _isFixedHeight;

	private Vector2 _preferredSize;

	private string _text;

	private List<TextToken> _tokens;

	private float _widthSize;

	protected const float ExtraLetterPaddingHorizontal = 0.5f;

	protected const float ExtraLetterPaddingVertical = 5f;

	private const float RichTextIconHorizontalPadding = 8f;

	private const float RichTextIconVerticalPadding = 0f;

	private List<RichTextPart> _richTextParts;

	private List<RichTextLinkGroup> _linkGroups;

	private Stack<string> _styleStack;

	private TextTokenOutput _focusedToken;

	private RichTextLinkGroup _focusedLinkGroup;

	private bool _gotFocus;

	private int _numOfAddedSeparators;

	protected readonly Func<int, Font> _getUsableFontForCharacter;

	private bool _shouldAddNewLineWhenExceedingContainerWidth;

	private bool _canBreakWords;

	internal int Width
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

	internal int Height
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

	internal float WidthSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string CurrentStyle
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

	public int TextHeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public StyleFontContainer StyleFontContainer
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

	public TextHorizontalAlignment HorizontalAlignment
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

	public TextVerticalAlignment VerticalAlignment
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

	public string Value
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

	internal TextOutput TextOutput
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

	private int _textLength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public RichTextLinkGroup FocusedLinkGroup
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool SkipLineOnContainerExceeded
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

	public bool CanBreakWords
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
	public RichText(int width, int height, Font font, Func<int, Font> getUsableFontForCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Update(float dt, SpriteData spriteData, Vector2 focusPosition, bool focus, bool isFixedWidth, bool isFixedHeight, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAllDirty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetEmptyCharacterWidth(Font font, float scaleValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetPreferredSize(bool fixedWidth, float widthSize, bool fixedHeight, float heightSize, SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CalculateTextOutput(float width, float height, SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextTokenOutput GetTokenUnderPosition(Vector2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PositionTokensInTextOutput(SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindLinkGroups()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RichTextPart GetOrCreateTextPartOfStyle(string style, Font font, float x, float y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillPartsWithTokens(SpriteData spriteData, float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenerateMeshes(float renderScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Font GetFontForTextToken(TextToken token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<RichTextPart> GetParts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RichTextLinkGroup FindLinkGroup(TextToken textToken)
	{
		throw null;
	}
}
