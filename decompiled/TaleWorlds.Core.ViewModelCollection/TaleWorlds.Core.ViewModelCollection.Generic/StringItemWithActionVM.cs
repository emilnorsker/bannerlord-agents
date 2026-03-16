using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core.ViewModelCollection.Generic;

public class StringItemWithActionVM : ViewModel
{
	public object Identifier;

	protected Action<object> _onExecute;

	private string _actionText;

	[DataSourceProperty]
	public string ActionText
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
	public StringItemWithActionVM(Action<object> onExecute, string item, object identifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteAction()
	{
		throw null;
	}
}
