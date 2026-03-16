using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

internal abstract class MessageContractCreator
{
	public abstract MessageContract Invoke();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MessageContractCreator()
	{
		throw null;
	}
}
internal class MessageContractCreator<T> : MessageContractCreator where T : MessageContract, new()
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MessageContract Invoke()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MessageContractCreator()
	{
		throw null;
	}
}
