using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class MBGameModel<T> : GameModel where T : GameModel
{
	protected T BaseModel
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
	public void Initialize(T baseModel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MBGameModel()
	{
		throw null;
	}
}
