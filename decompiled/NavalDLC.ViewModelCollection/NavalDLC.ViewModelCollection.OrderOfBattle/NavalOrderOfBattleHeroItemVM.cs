using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.OrderOfBattle;

public class NavalOrderOfBattleHeroItemVM : ViewModel
{
	public readonly IAgentOriginBase AgentOrigin;

	private readonly Action<NavalOrderOfBattleHeroItemVM, bool> _onSelected;

	private List<TooltipProperty> _cachedTooltipProperties;

	private readonly TextObject _perkDefinitionText;

	private readonly TextObject _captainPerksText;

	private readonly TextObject _infantryInfluenceText;

	private readonly TextObject _rangedInfluenceText;

	private readonly TextObject _noPerksText;

	private readonly PerkObjectComparer _perkComparer;

	private bool _isDisabled;

	private bool _isSelected;

	private bool _isMainHero;

	private CharacterImageIdentifierVM _imageIdentifier;

	private BasicTooltipViewModel _tooltip;

	[DataSourceProperty]
	public bool IsDisabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsMainHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public CharacterImageIdentifierVM ImageIdentifier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public BasicTooltipViewModel Tooltip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalOrderOfBattleHeroItemVM(IAgentOriginBase agentOrigin, Action<NavalOrderOfBattleHeroItemVM, bool> onSelected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSelect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteToggleSelect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteDeselect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TooltipProperty> GetTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetCanBeUnassignedOrMoved()
	{
		throw null;
	}
}
