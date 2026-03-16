using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class MeansImplicitUseAttribute : Attribute
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
	public MeansImplicitUseAttribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
	{
		throw null;
	}
}
