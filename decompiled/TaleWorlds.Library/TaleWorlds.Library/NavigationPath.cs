using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TaleWorlds.Library;

public class NavigationPath : ISerializable
{
	private const int PathSize = 128;

	public Vec2[] PathPoints
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

	[CachedData]
	public int Size
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

	public Vec2 this[int i]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavigationPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected NavigationPath(SerializationInfo info, StreamingContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OverridePathPointAtIndex(int index, in Vec2 newValue)
	{
		throw null;
	}
}
