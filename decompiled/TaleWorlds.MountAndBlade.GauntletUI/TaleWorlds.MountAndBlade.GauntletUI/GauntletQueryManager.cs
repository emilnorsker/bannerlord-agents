using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.Inquiries;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class GauntletQueryManager : GlobalLayer
{
	private bool _isInitialized;

	private Queue<Tuple<Type, object, bool, bool>> _inquiryQueue;

	private bool _isLastActiveGameStatePaused;

	private GauntletLayer _gauntletLayer;

	private SingleQueryPopUpVM _singleQueryPopupVM;

	private MultiSelectionQueryPopUpVM _multiSelectionQueryPopUpVM;

	private TextQueryPopUpVM _textQueryPopUpVM;

	private static PopUpBaseVM _activeDataSource;

	private static object _activeQueryData;

	private GauntletMovieIdentifier _movie;

	private Dictionary<Type, Action<object, bool, bool>> _createQueryActions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OnIsAnyInquiryActiveQuery()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeKeyVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEarlyTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateQuery(InquiryData data, bool pauseGameActiveState, bool prioritize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateTextQuery(TextInquiryData data, bool pauseGameActiveState, bool prioritize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateMultiSelectionQuery(MultiSelectionInquiryData data, bool pauseGameActiveState, bool prioritize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QueueAndShowNewData(object newInquiryData, bool pauseGameActiveState, bool prioritize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleQueryCreated(string soundEventPath, bool pauseGameActiveState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CloseQuery()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetLayerFocus(bool isFocused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Queue<T> CombineQueues<T>(Queue<T> t1, Queue<T> t2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIfQueryDataIsEqual(object queryData1, object queryData2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletQueryManager()
	{
		throw null;
	}
}
