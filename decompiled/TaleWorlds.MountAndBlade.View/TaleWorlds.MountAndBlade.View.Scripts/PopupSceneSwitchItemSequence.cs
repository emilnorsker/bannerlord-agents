using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class PopupSceneSwitchItemSequence : PopupSceneSequence
{
	public enum BodyPartIndex
	{
		None,
		Weapon0,
		Weapon1,
		Weapon2,
		Weapon3,
		ExtraWeaponSlot,
		Head,
		Body,
		Leg,
		Gloves,
		Cape,
		Horse,
		HorseHarness
	}

	public string InitialItem;

	public string PositiveItem;

	public string NegativeItem;

	public BodyPartIndex InitialBodyPart;

	public BodyPartIndex PositiveBodyPart;

	public BodyPartIndex NegativeBodyPart;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPositiveState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnNegativeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EquipmentIndex StringToEquipmentIndex(BodyPartIndex part)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachItem(string itemName, BodyPartIndex bodyPart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PopupSceneSwitchItemSequence()
	{
		throw null;
	}
}
