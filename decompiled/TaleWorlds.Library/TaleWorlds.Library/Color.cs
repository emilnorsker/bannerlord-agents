using System.Numerics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct Color
{
	public float Red;

	public float Green;

	public float Blue;

	public float Alpha;

	public static Color Black
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Color White
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color(float red, float green, float blue, float alpha = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector3 ToVector3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ToVec3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color operator *(Color c, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color operator *(Color c1, Color c2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color operator +(Color c1, Color c2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color operator -(Color c1, Color c2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(Color a, Color b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(Color a, Color b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color FromVector3(Vector3 vector3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color FromVector3(Vec3 vector3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Length()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint ToUnsignedInteger()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color FromUint(uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color FromHSV(float h, float s, float v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color ConvertStringToColor(string color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Color Lerp(Color start, Color end, float ratio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string UIntToColorString(uint color)
	{
		throw null;
	}
}
