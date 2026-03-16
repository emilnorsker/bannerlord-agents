using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.Options;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

public class OptionGroupVM : ViewModel
{
	private readonly TextObject _groupName;

	private const string ControllerIdentificationModifier = "_controller";

	private string _name;

	private MBBindingList<GenericOptionDataVM> _options;

	[DataSourceProperty]
	public string Name
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
	public MBBindingList<GenericOptionDataVM> Options
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
	public OptionGroupVM(TextObject groupName, OptionsVM optionsBase, IEnumerable<IOptionData> optionsList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal List<IOptionData> GetManagedOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Cancel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeDependentConfigs(Action<IOptionData, float> updateDependentConfigs)
	{
		throw null;
	}
}
