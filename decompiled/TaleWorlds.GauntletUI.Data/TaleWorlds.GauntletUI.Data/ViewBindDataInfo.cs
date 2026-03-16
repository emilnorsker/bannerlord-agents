using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.GauntletUI.Data;

internal readonly struct ViewBindDataInfo
{
	internal readonly bool IsValid;

	internal readonly GauntletView Owner;

	internal readonly string Property;

	internal readonly BindingPath Path;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ViewBindDataInfo(GauntletView view, string property, BindingPath path)
	{
		throw null;
	}
}
