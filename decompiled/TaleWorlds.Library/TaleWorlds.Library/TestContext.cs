using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public class TestContext
{
	private AsyncRunner _asyncRunner;

	private AwaitableAsyncRunner _awaitableAsyncRunner;

	private Thread _asyncThread;

	private Task _asyncTask;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RunTestAux(string commandLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ConstructorInfo GetAsyncRunnerConstructor(string asyncRunner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Assembly[] GetAsyncRunnerAssemblies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickTest(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TestContext()
	{
		throw null;
	}
}
