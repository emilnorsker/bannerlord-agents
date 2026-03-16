using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace NavalDLC.HotKeyCategories;

public class NavalShipControlsHotKeyCategory : GameKeyContext
{
	public const string CategoryId = "NavalShipControlsHotKeyCategory";

	public const string AccelerationAxis = "MovementAxisY";

	public const string TurnAxis = "MovementAxisX";

	public const string ToggleOarsmen = "ToggleOarsmen";

	public const string ToggleSail = "ToggleSail";

	public const string CutLoose = "CutLoose";

	public const string ChangeCamera = "ChangeCamera";

	public const string SelectShip = "SelectShip";

	public const string AttemptBoarding = "AttemptBoarding";

	public const string DelegateCommand = "DelegateCommand";

	public const string ToggleRangedWeaponOrderMode = "ToggleRangedWeaponDirectOrderMode";

	public const string ShootBallista = "ShootBallista";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalShipControlsHotKeyCategory()
	{
		throw null;
	}
}
