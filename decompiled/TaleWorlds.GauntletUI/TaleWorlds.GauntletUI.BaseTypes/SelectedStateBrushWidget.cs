using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.BaseTypes;

public class SelectedStateBrushWidget : BrushWidget
{
	private bool _isDirty;

	private bool _isBrushStatesRegistered;

	private string _selectedState;

	[Editor(false)]
	public string SelectedState
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
	public SelectedStateBrushWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateUpdate(float dt)
	{
		throw null;
	}
}
