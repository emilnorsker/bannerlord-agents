using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.ClanFinance;

public class ClanFinanceWorkshopItemVM : ClanFinanceIncomeItemBaseVM
{
	[CompilerGenerated]
	private sealed class _003CGetManageWorkshopItems_003Ed__29 : IEnumerable<ClanCardSelectionItemInfo>, IEnumerable, IEnumerator<ClanCardSelectionItemInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ClanCardSelectionItemInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ClanFinanceWorkshopItemVM _003C_003E4__this;

		private int _003CcostOfChangingType_003E5__2;

		private TextObject _003CcannotChangeTypeReason_003E5__3;

		private List<WorkshopType>.Enumerator _003C_003E7__wrap3;

		ClanCardSelectionItemInfo IEnumerator<ClanCardSelectionItemInfo>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetManageWorkshopItems_003Ed__29(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<ClanCardSelectionItemInfo> IEnumerable<ClanCardSelectionItemInfo>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetWorkshopItemProperties_003Ed__30 : IEnumerable<ClanCardSelectionItemPropertyInfo>, IEnumerable, IEnumerator<ClanCardSelectionItemPropertyInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ClanCardSelectionItemPropertyInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private WorkshopType workshopType;

		public WorkshopType _003C_003E3__workshopType;

		public ClanFinanceWorkshopItemVM _003C_003E4__this;

		private TextObject _003CinputsText_003E5__2;

		private TextObject _003CoutputsText_003E5__3;

		ClanCardSelectionItemPropertyInfo IEnumerator<ClanCardSelectionItemPropertyInfo>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetWorkshopItemProperties_003Ed__30(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<ClanCardSelectionItemPropertyInfo> IEnumerable<ClanCardSelectionItemPropertyInfo>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private readonly TextObject _runningText;

	private readonly TextObject _haltedText;

	private readonly TextObject _noRawMaterialsText;

	private readonly TextObject _noProfitText;

	private readonly TextObject _townRebellionText;

	private readonly IWorkshopWarehouseCampaignBehavior _workshopWarehouseBehavior;

	private readonly WorkshopModel _workshopModel;

	private readonly Action<ClanCardSelectionInfo> _openCardSelectionPopup;

	private readonly Action<ClanFinanceWorkshopItemVM> _onSelectionT;

	private ExplainedNumber _inputDetails;

	private ExplainedNumber _outputDetails;

	private HintViewModel _useWarehouseAsInputHint;

	private HintViewModel _storeOutputPercentageHint;

	private HintViewModel _manageWorkshopHint;

	private BasicTooltipViewModel _inputWarehouseCountsTooltip;

	private BasicTooltipViewModel _outputWarehouseCountsTooltip;

	private string _workshopTypeId;

	private string _inputsText;

	private string _outputsText;

	private string _inputProducts;

	private string _outputProducts;

	private string _useWarehouseAsInputText;

	private string _storeOutputPercentageText;

	private string _warehouseCapacityText;

	private string _warehouseCapacityValue;

	private bool _receiveInputFromWarehouse;

	private int _warehouseInputAmount;

	private int _warehouseOutputAmount;

	private SelectorVM<WorkshopPercentageSelectorItemVM> _warehousePercentageSelector;

	public Workshop Workshop
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

	[DataSourceProperty]
	public HintViewModel UseWarehouseAsInputHint
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
	public HintViewModel StoreOutputPercentageHint
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
	public HintViewModel ManageWorkshopHint
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
	public BasicTooltipViewModel InputWarehouseCountsTooltip
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
	public BasicTooltipViewModel OutputWarehouseCountsTooltip
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

	public string WorkshopTypeId
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

	public string InputsText
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

	public string OutputsText
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

	public string InputProducts
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

	public string OutputProducts
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

	public string UseWarehouseAsInputText
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

	public string StoreOutputPercentageText
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

	public string WarehouseCapacityText
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

	public string WarehouseCapacityValue
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

	public bool ReceiveInputFromWarehouse
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

	public int WarehouseInputAmount
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

	public int WarehouseOutputAmount
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

	public SelectorVM<WorkshopPercentageSelectorItemVM> WarehousePercentageSelector
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
	public ClanFinanceWorkshopItemVM(Workshop workshop, Action<ClanFinanceWorkshopItemVM> onSelection, Action onRefresh, Action<ClanCardSelectionInfo> openCardSelectionPopup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tempOnSelection(ClanFinanceIncomeItemBaseVM temp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TooltipProperty> GetWarehouseInputOutputTooltip(bool isInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshStoragePercentages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteToggleWarehouseUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PopulateStatsList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SelectableItemPropertyVM GetCurrentCapitalProperty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (TextObject Status, bool IsWarning, BasicTooltipViewModel Hint) GetWorkshopStatus(Workshop workshop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetWorkshopTypeProductionTexts(WorkshopType workshopType, out TextObject inputsText, out TextObject outputsText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteBeginWorkshopHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteEndHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnStoreOutputInWarehousePercentageUpdated(SelectorVM<WorkshopPercentageSelectorItemVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteManageWorkshop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetManageWorkshopItems_003Ed__29))]
	private IEnumerable<ClanCardSelectionItemInfo> GetManageWorkshopItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetWorkshopItemProperties_003Ed__30))]
	private IEnumerable<ClanCardSelectionItemPropertyInfo> GetWorkshopItemProperties(WorkshopType workshopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManageWorkshopDone(List<object> selectedItems, Action closePopup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSellWorkshop()
	{
		throw null;
	}
}
