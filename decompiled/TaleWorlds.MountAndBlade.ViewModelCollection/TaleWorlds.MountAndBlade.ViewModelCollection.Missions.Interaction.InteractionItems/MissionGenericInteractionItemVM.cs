using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Missions.Interaction.InteractionItems;

public class MissionGenericInteractionItemVM : MissionInteractionItemBaseVM
{
	private TextObject _messageTextObj;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGenericInteractionItemVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetData(TextObject message, bool isDisabled = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnSetData(TextObject message, bool isDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnResetData()
	{
		throw null;
	}
}
