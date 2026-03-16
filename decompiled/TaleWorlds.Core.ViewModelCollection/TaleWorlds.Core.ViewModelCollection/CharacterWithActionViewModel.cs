using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core.ViewModelCollection;

public class CharacterWithActionViewModel : CharacterViewModel
{
	private Action _onAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterWithActionViewModel(Action onAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteAction()
	{
		throw null;
	}
}
