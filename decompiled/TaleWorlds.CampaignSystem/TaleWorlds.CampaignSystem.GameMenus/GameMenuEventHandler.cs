using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.GameMenus;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class GameMenuEventHandler : Attribute
{
	public enum EventType
	{
		OnCondition,
		OnConsequence
	}

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

	public string MenuOptionId
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

	public EventType Type
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
	public GameMenuEventHandler(string menuId, string menuOptionId, EventType type)
	{
		throw null;
	}
}
