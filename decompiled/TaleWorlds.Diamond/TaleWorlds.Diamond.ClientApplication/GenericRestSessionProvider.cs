using System.Runtime.CompilerServices;
using TaleWorlds.Library.Http;

namespace TaleWorlds.Diamond.ClientApplication;

public class GenericRestSessionProvider<T> : IClientSessionProvider<T> where T : Client<T>
{
	private string _address;

	private IHttpDriver _httpDriver;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericRestSessionProvider(string address, IHttpDriver httpDriver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IClientSession CreateSession(T session)
	{
		throw null;
	}
}
