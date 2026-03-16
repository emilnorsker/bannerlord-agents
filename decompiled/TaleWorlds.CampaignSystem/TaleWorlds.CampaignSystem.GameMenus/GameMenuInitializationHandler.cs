using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.GameMenus;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class GameMenuInitializationHandler : Attribute
{
	public string MenuId
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
	public GameMenuInitializationHandler(string menuId)
	{
		throw null;
	}
}
