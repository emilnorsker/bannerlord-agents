using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class BasicGameStarter : IGameStarter
{
	private List<GameModel> _models;

	IEnumerable<GameModel> IGameStarter.Models
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicGameStarter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetModel<T>() where T : GameModel
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddModel(GameModel gameModel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddModel<T>(MBGameModel<T> gameModel) where T : GameModel
	{
		throw null;
	}
}
