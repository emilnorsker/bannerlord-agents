using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.GauntletUI.Data;

public class GauntletView : WidgetComponent
{
	private BindingPath _viewModelPath;

	private Dictionary<string, List<ViewBindDataInfo>> _bindDataInfosByPath;

	private Dictionary<string, ViewBindCommandInfo> _bindCommandInfos;

	private IViewModel _viewModel;

	private IMBBindingList _bindingList;

	private MBList<GauntletView> _children;

	private List<GauntletView> _items;

	internal bool AddedToChildren
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

	public GauntletMovie GauntletMovie
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

	public ItemTemplateUsageWithData ItemTemplateUsageWithData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		internal set
		{
			throw null;
		}
	}

	public BindingPath ViewModelPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string ViewModelPathString
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GauntletView Parent
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

	public string DisplayName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteViewModelPathToStringBuilder(ref MBStringBuilder sb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeViewModelPath(BindingPath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GauntletView(GauntletMovie gauntletMovie, GauntletView parent, Widget target, int childCount = 64)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddChild(GauntletView child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveChild(GauntletView child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwapChildrenAtIndeces(GauntletView child1, GauntletView child2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshBinding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEventFired(Widget widget, string commandName, object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshBindingWithChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReleaseBinding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseBindingWithChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ClearEventHandlersWithChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearEventHandlers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BindData(string property, BindingPath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BindCommand(string command, BindingPath path, string parameterValue = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelBindingListChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChangedWithValue(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object ConvertCommandParameter(object parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPropertyChanged(string propertyName, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCommand(string command, object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<ViewBindDataInfo> GetBindDataInfosOfProperty(string propertyName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnListSorted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnListReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemAddedToList(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ClampIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GauntletView AddItemToList(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemRemovedFromList(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveItemFromList(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforeItemRemovedFromList(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PreviewRemoveItemFromList(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetData(string path, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewPropertyChanged(string propertyName, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, Color value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, uint value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnViewObjectPropertyChanged(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 value)
	{
		throw null;
	}
}
