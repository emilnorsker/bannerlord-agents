using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace TaleWorlds.MountAndBlade;

public sealed class GenericGameKeyContext : GameKeyContext
{
	public const string CategoryId = "Generic";

	public const int Up = 0;

	public const int Down = 1;

	public const int Right = 3;

	public const int Left = 2;

	public const string MovementAxisX = "MovementAxisX";

	public const string MovementAxisY = "MovementAxisY";

	public const string CameraAxisX = "CameraAxisX";

	public const string CameraAxisY = "CameraAxisY";

	public const int Leave = 4;

	public const int ShowIndicators = 5;

	public static GenericGameKeyContext Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericGameKeyContext()
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
