using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public class TextToken
{
	public enum TokenType
	{
		EmptyCharacter,
		ZeroWidthSpace,
		NonBreakingSpace,
		WordJoiner,
		NewLine,
		Tab,
		Character,
		Tag
	}

	public char Token
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

	public TokenType Type
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

	public RichTextTag Tag
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

	public bool CannotStartLineWithCharacter
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

	public bool CannotEndLineWithCharacter
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextToken(TokenType type, char token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextToken(RichTextTag tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateEmptyCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateZeroWidthSpaceCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateNonBreakingSpaceCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateWordJoinerCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateNewLine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateTab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateCharacter(char character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateTag(RichTextTag tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateCharacterCannotEndLineWith(char character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextToken CreateCharacterCannotStartLineWith(char character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<TextToken> CreateTokenArrayFromWord(string word)
	{
		throw null;
	}
}
