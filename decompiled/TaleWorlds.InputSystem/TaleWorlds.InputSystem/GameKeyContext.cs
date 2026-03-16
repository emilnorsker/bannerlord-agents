using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.InputSystem;

public abstract class GameKeyContext
{
	public enum GameKeyContextType
	{
		Default,
		AuxiliaryNotSerialized,
		AuxiliarySerialized,
		AuxiliarySerializedAndShownInOptions
	}

	private readonly Dictionary<string, HotKey> _registeredHotKeys;

	private readonly MBList<GameKey> _registeredGameKeys;

	private readonly Dictionary<string, GameAxisKey> _registeredAxisKeys;

	private static bool _isRDownSwappedWithRRight;

	public string GameKeyCategoryId
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

	public GameKeyContextType Type
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

	public MBReadOnlyList<GameKey> RegisteredGameKeys
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Dictionary<string, HotKey>.ValueCollection RegisteredHotKeys
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Dictionary<string, GameAxisKey>.ValueCollection RegisteredGameAxisKeys
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameKeyContext(string id, int gameKeysCount, GameKeyContextType type = GameKeyContextType.Default)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal void RegisterHotKey(HotKey gameKey, bool addIfMissing = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal void RegisterGameKey(GameKey gameKey, bool addIfMissing = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal void RegisterGameAxisKey(GameAxisKey gameKey, bool addIfMissing = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SetIsRDownSwappedWithRRight(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HotKey GetHotKey(string hotKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameKey GetGameKey(int gameKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameKey GetGameKey(string gameKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GameAxisKey GetGameAxisKey(string axisKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetHotKeyId(string hotKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetHotKeyId(int gameKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GameKeyContext()
	{
		throw null;
	}
}
