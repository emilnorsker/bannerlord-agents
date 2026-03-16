using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public class RichTextException : Exception
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal RichTextException(string message)
	{
		throw null;
	}
}
