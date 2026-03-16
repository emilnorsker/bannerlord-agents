using System.Runtime.CompilerServices;
using SandBox.View.Map.Visuals;
using TaleWorlds.Engine;

namespace SandBox.View.Map.Managers;

public abstract class EntityVisualManagerBase : CampaignEntityVisualComponent
{
	private Scene _mapScene;

	public Scene MapScene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected EntityVisualManagerBase()
	{
		throw null;
	}
}
public abstract class EntityVisualManagerBase<TEntity> : EntityVisualManagerBase
{
	public abstract MapEntityVisual<TEntity> GetVisualOfEntity(TEntity entity);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static EntityVisualManagerBase<TEntity> GetEntityVisualManagerBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected EntityVisualManagerBase()
	{
		throw null;
	}
}
