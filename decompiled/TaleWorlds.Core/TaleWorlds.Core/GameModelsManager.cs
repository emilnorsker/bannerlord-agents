using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public abstract class GameModelsManager
{
	private readonly MBList<GameModel> _gameModels;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GameModelsManager(IEnumerable<GameModel> inputComponents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected T GetGameModel<T>() where T : GameModel
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<GameModel> GetGameModels()
	{
		throw null;
	}
}
