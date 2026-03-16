using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameMenus;

public class WaitMenuOption
{
	public delegate bool OnConditionDelegate(MenuCallbackArgs args);

	public delegate void OnConsequenceDelegate(MenuCallbackArgs args);

	private string _idString;

	private TextObject _text;

	private string _tooltip;

	private MethodInfo _methodOnCondition;

	public OnConditionDelegate OnCondition;

	private MethodInfo _methodOnConsequence;

	public OnConsequenceDelegate OnConsequence;

	private bool _isLeave;

	public int Priority
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

	public TextObject Text
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string IdString
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Tooltip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLeave
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal WaitMenuOption()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal WaitMenuOption(string idString, TextObject text, OnConditionDelegate condition, OnConsequenceDelegate consequence, int priority = 100, string tooltip = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetConditionsHold(Game game, MapState mapState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RunConsequence(Game game, MapState mapState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deserialize(XmlNode node, Type typeOfWaitMenusCallbacks)
	{
		throw null;
	}
}
