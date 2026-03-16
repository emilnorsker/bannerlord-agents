using System;
using System.Runtime.CompilerServices;

namespace SandBox.ViewModelCollection.Map.Cheat;

public class CheatActionItemVM : CheatItemBaseVM
{
	public readonly GameplayCheatItem Cheat;

	private readonly Action<CheatActionItemVM> _onCheatExecuted;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheatActionItemVM(GameplayCheatItem cheat, Action<CheatActionItemVM> onCheatExecuted)
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
