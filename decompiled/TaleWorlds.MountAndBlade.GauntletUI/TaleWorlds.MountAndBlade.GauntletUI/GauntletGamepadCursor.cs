using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class GauntletGamepadCursor : GlobalLayer
{
	private GamepadCursorViewModel _dataSource;

	private GauntletLayer _layer;

	private static GauntletGamepadCursor _current;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletGamepadCursor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetCursorPosition()
	{
		throw null;
	}
}
