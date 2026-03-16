using System.Runtime.CompilerServices;

namespace TaleWorlds.ServiceDiscovery.Client;

public class ServiceAddress
{
	private const string Prefix = "service://";

	private const char Suffix = '/';

	public string Service
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

	public ServiceResolvedAddress[] ResolvedAddresses
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
	public ServiceAddress(string service, ServiceResolvedAddress[] resolvedAddresses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsServiceAddress(string address)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetAddressName(string serviceAddress, out string addressName)
	{
		throw null;
	}
}
