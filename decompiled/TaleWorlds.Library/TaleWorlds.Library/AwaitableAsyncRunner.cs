using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public abstract class AwaitableAsyncRunner
{
	public abstract Task RunAsync();

	public abstract void OnTick(float dt);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected AwaitableAsyncRunner()
	{
		throw null;
	}
}
