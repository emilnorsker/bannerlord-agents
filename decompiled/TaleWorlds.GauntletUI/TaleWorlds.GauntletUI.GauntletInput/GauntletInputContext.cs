using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace TaleWorlds.GauntletUI.GauntletInput;

public class GauntletInputContext : IReadonlyInputContext
{
	private readonly IInputContext _inputContext;

	private bool _isMousePositionOverridden;

	private Vector2 _overrideMousePosition;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletInputContext(IInputContext inputContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsMouseActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetMousePosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetMouseMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InputKey[] GetClickKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InputKey[] GetAlternateClickKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMouseScrollDelta()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetControllerLeftStickState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vector2 GetControllerRightStickState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMousePositionOverride(Vector2 mousePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetMousePositionOverride()
	{
		throw null;
	}
}
