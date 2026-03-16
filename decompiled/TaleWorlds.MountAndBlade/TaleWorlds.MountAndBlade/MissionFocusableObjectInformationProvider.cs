using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class MissionFocusableObjectInformationProvider
{
	private List<GetFocusableObjectInteractionTextsDelegate> _getFocusableObjectTextsCallbacks;

	private List<GetFocusableObjectInteractionTextsDelegate> _getDefaultFocusableObjectTextsCallbacks;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionFocusableObjectInformationProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDefaultInteractionTexts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddInfoCallback(GetFocusableObjectInteractionTextsDelegate callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveInfoCallback(GetFocusableObjectInteractionTextsDelegate callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetInteractionTexts(Agent requesterAgent, IFocusable focusable, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSpawnedItemEntityTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetItemNameText(TextObject descriptionMessage, TextObject weaponSpecificText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetWeaponSpecificText(SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetUsableMissionObjectTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private UsableMachine GetUsableMachineFromPoint(UsableMissionObject standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDestructibleComponentTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetUsableMachineTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetHumanAgentTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanInteractWithAgent(Agent requesterAgent, Agent focusedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetMountTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetGenericAgentTexts(Agent requesterAgent, IFocusable focusableObject, bool isInteractable, out FocusableObjectInformation focusableObjectInformation)
	{
		throw null;
	}
}
