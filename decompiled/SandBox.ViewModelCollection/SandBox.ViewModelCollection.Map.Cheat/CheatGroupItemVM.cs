using System;
using System.Runtime.CompilerServices;

namespace SandBox.ViewModelCollection.Map.Cheat;

public class CheatGroupItemVM : CheatItemBaseVM
{
	public readonly GameplayCheatGroup CheatGroup;

	private readonly Action<CheatGroupItemVM> _onSelectCheatGroup;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheatGroupItemVM(GameplayCheatGroup cheatGroup, Action<CheatGroupItemVM> onSelectCheatGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteAction()
	{
		throw null;
	}
}
