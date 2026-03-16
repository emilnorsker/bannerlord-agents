using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.GauntletUI;

public static class AnimationInterpolation
{
	public enum Type
	{
		Linear,
		EaseIn,
		EaseOut,
		EaseInOut
	}

	public enum Function
	{
		Sine,
		Quad,
		Cubic,
		Quart,
		Quint
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct EaseInInterpolator
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public float Ease(Function function, float t)
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct EaseOutInterpolator
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public float Ease(Function function, float t)
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct EaseInOutInterpolator
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public float Ease(Function function, float t)
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float Ease(Type type, Function function, float ratio)
	{
		throw null;
	}
}
