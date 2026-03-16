using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace TaleWorlds.MountAndBlade;

public sealed class MapHotKeyCategory : GameKeyContext
{
	public const string CategoryId = "MapHotKeyCategory";

	public const int QuickSave = 54;

	public const int PartyMoveUp = 50;

	public const int PartyMoveLeft = 53;

	public const int PartyMoveDown = 51;

	public const int PartyMoveRight = 52;

	public const int MapMoveUp = 46;

	public const int MapMoveDown = 47;

	public const int MapMoveLeft = 49;

	public const int MapMoveRight = 48;

	public const string MovementAxisX = "MapMovementAxisX";

	public const string MovementAxisY = "MapMovementAxisY";

	public const int MapFastMove = 55;

	public const int MapZoomIn = 56;

	public const int MapZoomOut = 57;

	public const int MapRotateLeft = 58;

	public const int MapRotateRight = 59;

	public const int MapCameraFollowMode = 64;

	public const int MapToggleFastForward = 65;

	public const int MapTrackSettlement = 66;

	public const int MapGoToEncylopedia = 67;

	public const string MapClick = "MapClick";

	public const string MapFollowModifier = "MapFollowModifier";

	public const string MapChangeCursorMode = "MapChangeCursorMode";

	public const int MapTimeStop = 60;

	public const int MapTimeNormal = 61;

	public const int MapTimeFastForward = 62;

	public const int MapTimeTogglePause = 63;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapHotKeyCategory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterHotKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterGameKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterGameAxisKeys()
	{
		throw null;
	}
}
