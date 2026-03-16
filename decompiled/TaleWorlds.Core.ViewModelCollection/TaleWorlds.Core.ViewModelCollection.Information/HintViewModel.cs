using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.Core.ViewModelCollection.Information;

public class HintViewModel : ViewModel
{
	public TextObject HintText;

	private readonly string _uniqueName;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HintViewModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HintViewModel(TextObject hintText, string uniqueName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteBeginHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteEndHint()
	{
		throw null;
	}
}
