using System;
using System.Collections.ObjectModel;
using TaleWorlds.Library;

namespace AIInfluence.SettlementCombat.PhrasesDisplay.Popup;

public class CombatPhrasePopupVM : ViewModel, IDisposable
{
	private MBBindingList<CombatPhrasePopupItemVM> _targets;

	[DataSourceProperty]
	public MBBindingList<CombatPhrasePopupItemVM> Targets
	{
		get
		{
			return _targets;
		}
		set
		{
			if (value != _targets)
			{
				_targets = value;
				((ViewModel)this).OnPropertyChangedWithValue<MBBindingList<CombatPhrasePopupItemVM>>(value, "Targets");
			}
		}
	}

	public CombatPhrasePopupVM()
	{
		_targets = new MBBindingList<CombatPhrasePopupItemVM>();
	}

	public void AddItem(CombatPhrasePopupItemVM item)
	{
		((Collection<CombatPhrasePopupItemVM>)(object)_targets).Add(item);
	}

	public void RemoveItem(CombatPhrasePopupItemVM item)
	{
		((Collection<CombatPhrasePopupItemVM>)(object)_targets).Remove(item);
	}

	public void Dispose()
	{
		((Collection<CombatPhrasePopupItemVM>)(object)_targets)?.Clear();
	}
}
