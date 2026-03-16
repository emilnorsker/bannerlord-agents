using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

public class CompressionInfo
{
	[EngineStruct("Integer_compression_info", false, null)]
	public struct Integer
	{
		[CustomEngineStructMemberData("min_value")]
		private readonly int minimumValue;

		[CustomEngineStructMemberData("max_value")]
		private readonly int maximumValue;

		[CustomEngineStructMemberData("num_bits")]
		private readonly int numberOfBits;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Integer(int minimumValue, int maximumValue, bool maximumValueGiven)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Integer(int minimumValue, int numberOfBits)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumBits()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetMaximumValue()
		{
			throw null;
		}
	}

	[EngineStruct("Unsigned_integer_compression_info", false, null)]
	public struct UnsignedInteger
	{
		[CustomEngineStructMemberData("min_value")]
		private readonly uint minimumValue;

		[CustomEngineStructMemberData("max_value")]
		private readonly uint maximumValue;

		[CustomEngineStructMemberData("num_bits")]
		private readonly int numberOfBits;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public UnsignedInteger(uint minimumValue, uint maximumValue, bool maximumValueGiven)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public UnsignedInteger(uint minimumValue, int numberOfBits)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumBits()
		{
			throw null;
		}
	}

	[EngineStruct("Integer64_compression_info", false, null)]
	public struct LongInteger
	{
		[CustomEngineStructMemberData("min_value")]
		private readonly long minimumValue;

		[CustomEngineStructMemberData("max_value")]
		private readonly long maximumValue;

		[CustomEngineStructMemberData("num_bits")]
		private readonly int numberOfBits;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public LongInteger(long minimumValue, long maximumValue, bool maximumValueGiven)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public LongInteger(long minimumValue, int numberOfBits)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumBits()
		{
			throw null;
		}
	}

	[EngineStruct("Unsigned_integer64_compression_info", false, null)]
	public struct UnsignedLongInteger
	{
		[CustomEngineStructMemberData("min_value")]
		private readonly ulong minimumValue;

		[CustomEngineStructMemberData("max_value")]
		private readonly ulong maximumValue;

		[CustomEngineStructMemberData("num_bits")]
		private readonly int numberOfBits;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public UnsignedLongInteger(ulong minimumValue, ulong maximumValue, bool maximumValueGiven)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public UnsignedLongInteger(ulong minimumValue, int numberOfBits)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumBits()
		{
			throw null;
		}
	}

	[EngineStruct("Float_compression_info", false, null)]
	public struct Float
	{
		[CustomEngineStructMemberData("min_value")]
		private readonly float minimumValue;

		[CustomEngineStructMemberData("max_value")]
		private readonly float maximumValue;

		[CustomEngineStructMemberData(true)]
		private readonly float precision;

		[CustomEngineStructMemberData("num_bits")]
		private readonly int numberOfBits;

		public static Float FullPrecision
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Float(float minimumValue, float maximumValue, int numberOfBits)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Float(float minimumValue, int numberOfBits, float precision)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Float(bool isFullPrecision)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetNumBits()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetMaximumValue()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetMinimumValue()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetPrecision()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ClampValueAccordingToLimits(ref float x)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Float()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompressionInfo()
	{
		throw null;
	}
}
