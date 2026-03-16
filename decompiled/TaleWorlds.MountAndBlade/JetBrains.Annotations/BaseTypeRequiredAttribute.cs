using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
[BaseTypeRequired(typeof(Attribute))]
public sealed class BaseTypeRequiredAttribute : Attribute
{
	public Type[] BaseTypes
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
	public BaseTypeRequiredAttribute(Type baseType)
	{
		throw null;
	}
}
