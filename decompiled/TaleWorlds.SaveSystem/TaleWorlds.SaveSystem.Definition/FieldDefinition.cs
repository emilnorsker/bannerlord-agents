using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.SaveSystem.Definition;

public class FieldDefinition : MemberDefinition
{
	public FieldInfo FieldInfo
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

	public SaveableFieldAttribute SaveableFieldAttribute
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

	public GetFieldValueDelegate GetFieldValueMethod
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
	public FieldDefinition(FieldInfo fieldInfo, MemberTypeId id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Type GetMemberType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override object GetValue(object target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeForAutoGeneration(GetFieldValueDelegate getFieldValueMethod)
	{
		throw null;
	}
}
