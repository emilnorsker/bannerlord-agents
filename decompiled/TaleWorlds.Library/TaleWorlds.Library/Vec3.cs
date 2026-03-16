using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace TaleWorlds.Library;

[Serializable]
public struct Vec3
{
	public struct StackArray8Vec3
	{
		private Vec3 _element0;

		private Vec3 _element1;

		private Vec3 _element2;

		private Vec3 _element3;

		private Vec3 _element4;

		private Vec3 _element5;

		private Vec3 _element6;

		private Vec3 _element7;

		public const int Length = 8;

		public Vec3 this[int index]
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
	}

	[XmlAttribute]
	public float x;

	[XmlAttribute]
	public float y;

	[XmlAttribute]
	public float z;

	[XmlAttribute]
	public float w;

	public static readonly Vec3 Side;

	public static readonly Vec3 Forward;

	public static readonly Vec3 Up;

	public static readonly Vec3 One;

	public static readonly Vec3 Zero;

	public static readonly Vec3 Invalid;

	public float X
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Y
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Z
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float this[int i]
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

	public float Length
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LengthSquared
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsValidXYZW
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUnit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsNonZero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 AsVec2
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

	public uint ToARGB
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RotationZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RotationX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3(float x = 0f, float y = 0f, float z = 0f, float w = -1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3(Vec3 c, float w = -1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3(Vec2 xy, float z = 0f, float w = -1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3(Vector3 vector3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Abs(Vec3 vec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static explicit operator Vector3(Vec3 vec3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float DotProduct(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Lerp(Vec3 v1, Vec3 v2, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Slerp(Vec3 start, Vec3 end, float percent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Vec3Max(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Vec3Min(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 CrossProduct(Vec3 va, Vec3 vb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 ElementWiseProduct(Vec3 va, Vec3 vb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 ElementWiseDivision(Vec3 va, Vec3 vb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator -(Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator +(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator -(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator *(Vec3 v, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator *(float f, Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator *(Vec3 v, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 operator /(Vec3 v, float f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 NormalizedCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Normalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClampMagnitude(float min, float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ClampedCopy(float min, float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ClampedCopy(float min, float max, out bool valueClamped)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void NormalizeWithoutChangingZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 CrossProductWithUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 CrossProductWithUpAsLeftParameter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool NearlyEquals(in Vec3 v, float epsilon = 1E-05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutX(float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutY(float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateAboutZ(float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 RotateAboutAnArbitraryVector(Vec3 vec, float a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 Reflect(Vec3 normal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ProjectOnUnitVector(Vec3 ov)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DistanceSquared(Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float Distance(Vec3 v)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 RotateVectorToXYPlane()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AngleBetweenTwoVectors(Vec3 v1, Vec3 v2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ToString(string format)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 Parse(string input)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Vec3()
	{
		throw null;
	}
}
