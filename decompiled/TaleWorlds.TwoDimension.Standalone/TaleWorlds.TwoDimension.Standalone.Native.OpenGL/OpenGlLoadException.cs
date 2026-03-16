using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.Standalone.Native.OpenGL;

public class OpenGlLoadException : Exception
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public OpenGlLoadException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OpenGlLoadException(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OpenGlLoadException(string message, Exception innerException)
	{
		throw null;
	}
}
