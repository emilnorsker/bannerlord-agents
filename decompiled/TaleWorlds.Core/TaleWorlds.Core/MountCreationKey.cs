using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class MountCreationKey
{
	private const int NumLegColors = 4;

	public byte _leftFrontLegColorIndex
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

	public byte _rightFrontLegColorIndex
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

	public byte _leftBackLegColorIndex
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

	public byte _rightBackLegColorIndex
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

	public byte MaterialIndex
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

	public byte MeshMultiplierIndex
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MountCreationKey(byte leftFrontLegColorIndex, byte rightFrontLegColorIndex, byte leftBackLegColorIndex, byte rightBackLegColorIndex, byte materialIndex, byte meshMultiplierIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MountCreationKey FromString(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetBitsFromKey(uint numericKey, int startingBit, int numBits)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetBits(ref uint numericKey, int value, int startingBit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetRandomMountKeyString(ItemObject mountItem, int randomSeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MountCreationKey GetRandomMountKey(ItemObject mountItem, int randomSeed)
	{
		throw null;
	}
}
