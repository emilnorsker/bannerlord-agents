using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

public abstract class VisualOrderProvider
{
	public abstract bool IsAvailable();

	public abstract MBReadOnlyList<VisualOrderSet> GetOrders();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected VisualOrderProvider()
	{
		throw null;
	}
}
