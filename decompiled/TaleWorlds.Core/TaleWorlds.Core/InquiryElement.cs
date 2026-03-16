using System.Runtime.CompilerServices;
using TaleWorlds.Core.ImageIdentifiers;

namespace TaleWorlds.Core;

public class InquiryElement
{
	public readonly string Title;

	public readonly ImageIdentifier ImageIdentifier;

	public readonly object Identifier;

	public readonly bool IsEnabled;

	public readonly string Hint;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InquiryElement(object identifier, string title, ImageIdentifier imageIdentifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InquiryElement(object identifier, string title, ImageIdentifier imageIdentifier, bool isEnabled, string hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasSameContentWith(object other)
	{
		throw null;
	}
}
