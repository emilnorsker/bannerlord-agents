using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Encyclopedia;

public abstract class EncyclopediaModelBase : Attribute
{
	public Type[] PageTargetTypes
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
	public EncyclopediaModelBase(Type[] pageTargetTypes)
	{
		throw null;
	}
}
