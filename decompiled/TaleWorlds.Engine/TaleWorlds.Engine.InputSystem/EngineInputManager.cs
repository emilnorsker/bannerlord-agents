using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace TaleWorlds.Engine.InputSystem;

public class EngineInputManager : IInputManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMousePositionX()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMousePositionY()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMouseScrollValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsMouseActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsControllerConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IInputManager.PressKey(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IInputManager.ClearKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	int IInputManager.GetVirtualKeyCode(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IInputManager.SetClipboardText(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string IInputManager.GetClipboardText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMouseMoveX()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMouseMoveY()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetNormalizedMouseMoveX()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetNormalizedMouseMoveY()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetGyroX()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetGyroY()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetGyroZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMouseSensitivity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IInputManager.GetMouseDeltaZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IInputManager.UpdateKeyData(byte[] keyData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec2 IInputManager.GetKeyState(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsKeyPressed(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsKeyDown(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsKeyDownImmediate(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsKeyReleased(InputKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec2 IInputManager.GetResolution()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec2 IInputManager.GetDesktopResolution()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IInputManager.SetCursorPosition(int x, int y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IInputManager.SetCursorFriction(float frictionValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	InputKey[] IInputManager.GetClickKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRumbleEffect(float[] lowFrequencyLevels, float[] lowFrequencyDurations, int numLowFrequencyElements, float[] highFrequencyLevels, float[] highFrequencyDurations, int numHighFrequencyElements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTriggerFeedback(byte leftTriggerPosition, byte leftTriggerStrength, byte rightTriggerPosition, byte rightTriggerStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTriggerWeaponEffect(byte leftStartPosition, byte leftEnd_position, byte leftStrength, byte rightStartPosition, byte rightEndPosition, byte rightStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTriggerVibration(float[] leftTriggerAmplitudes, float[] leftTriggerFrequencies, float[] leftTriggerDurations, int numLeftTriggerElements, float[] rightTriggerAmplitudes, float[] rightTriggerFrequencies, float[] rightTriggerDurations, int numRightTriggerElements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightbarColor(float red, float green, float blue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Input.ControllerTypes IInputManager.GetControllerType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IInputManager.IsAnyTouchActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EngineInputManager()
	{
		throw null;
	}
}
