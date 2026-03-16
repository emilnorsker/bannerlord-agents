using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem.Definition;

public abstract class MemberDefinition
{
	public MemberTypeId Id
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

	public MemberInfo MemberInfo
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
	protected MemberDefinition(MemberInfo memberInfo, MemberTypeId id)
	{
		throw null;
	}

	public abstract Type GetMemberType();

	public abstract object GetValue(object target);
}
