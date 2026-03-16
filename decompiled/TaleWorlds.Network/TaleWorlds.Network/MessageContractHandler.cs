using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

internal abstract class MessageContractHandler
{
	public abstract void Invoke(MessageContract messageContract);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MessageContractHandler()
	{
		throw null;
	}
}
internal class MessageContractHandler<T> : MessageContractHandler where T : MessageContract
{
	private MessageContractHandlerDelegate<T> _method;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MessageContractHandler(MessageContractHandlerDelegate<T> method)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Invoke(MessageContract messageContract)
	{
		throw null;
	}
}
