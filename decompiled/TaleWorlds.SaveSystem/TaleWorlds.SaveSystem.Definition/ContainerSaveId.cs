using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem.Definition;

public class ContainerSaveId : SaveId
{
	private readonly string _stringId;

	public ContainerType ContainerType
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

	public SaveId KeyId
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

	public SaveId ValueId
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
	public ContainerSaveId(ContainerType containerType, SaveId elementId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ContainerSaveId(ContainerType containerType, SaveId keyId, SaveId valueId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string CalculateStringId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetStringId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WriteTo(IWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ContainerSaveId ReadFrom(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSizeInBytes()
	{
		throw null;
	}
}
