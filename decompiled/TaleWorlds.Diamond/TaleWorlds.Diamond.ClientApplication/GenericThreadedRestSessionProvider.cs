using System.Runtime.CompilerServices;
using TaleWorlds.Library.Http;

namespace TaleWorlds.Diamond.ClientApplication;

public class GenericThreadedRestSessionProvider<T> : IClientSessionProvider<T> where T : Client<T>
{
	public const int DefaultThreadSleepTime = 100;

	private string _address;

	private IHttpDriver _httpDriver;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericThreadedRestSessionProvider(string address, IHttpDriver httpDriver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IClientSession CreateSession(T client)
	{
		throw null;
	}
}
