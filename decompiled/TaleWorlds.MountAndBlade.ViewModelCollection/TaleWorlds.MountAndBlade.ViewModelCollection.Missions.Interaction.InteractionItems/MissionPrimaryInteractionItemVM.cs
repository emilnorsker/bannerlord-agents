using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Missions.Interaction.InteractionItems;

public class MissionPrimaryInteractionItemVM : MissionGenericInteractionItemVM
{
	private string _focusTypeString;

	[DataSourceProperty]
	public string FocusTypeString
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
	public MissionPrimaryInteractionItemVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResetData()
	{
		throw null;
	}
}
