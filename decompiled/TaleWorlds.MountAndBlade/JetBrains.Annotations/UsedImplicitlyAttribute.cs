using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public sealed class UsedImplicitlyAttribute : Attribute
{
	[UsedImplicitly]
	public ImplicitUseKindFlags UseKindFlags
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

	[UsedImplicitly]
	public ImplicitUseTargetFlags TargetFlags
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
	[UsedImplicitly]
	public UsedImplicitlyAttribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags)
	{
		throw null;
	}
}
