using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class SerialTask : ITask
{
	public delegate void DelegateDefinition();

	private DelegateDefinition _instance;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SerialTask(DelegateDefinition function)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITask.Invoke()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ITask.Wait()
	{
		throw null;
	}
}
