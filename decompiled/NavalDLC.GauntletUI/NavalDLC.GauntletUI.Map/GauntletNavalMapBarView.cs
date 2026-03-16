using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Map;
using SandBox.View.Map;
using TaleWorlds.MountAndBlade.View;

namespace NavalDLC.GauntletUI.Map;

[OverrideView(typeof(MapBarView))]
public class GauntletNavalMapBarView : GauntletMapBarView
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletNavalMapBarView()
	{
		throw null;
	}
}
