using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

public readonly struct VisualOrderExecutionParameters
{
	public readonly bool HasWorldPosition;

	public readonly WorldPosition WorldPosition;

	public readonly bool HasAgent;

	public readonly Agent Agent;

	public readonly bool HasFormation;

	public readonly Formation Formation;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualOrderExecutionParameters(Agent agent = null, Formation formation = null, WorldPosition? worldPosition = null)
	{
		throw null;
	}
}
