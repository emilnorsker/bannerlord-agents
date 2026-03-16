using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.ServiceDiscovery.Client;

public static class ServiceAddressManager
{
	[Serializable]
	private class CachedServiceAddress
	{
		public string ServiceName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public string EnvironmentId
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public ServiceResolvedAddress ResolvedAddress
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public DateTime SavedAt
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CachedServiceAddress()
		{
			throw null;
		}
	}

	private const string ParametersDirectoryName = "Parameters";

	private const string EnvironmentFileName = "Environment";

	private const string CacheDirectoryName = "Data";

	private const string CachedServiceAddressesFileName = "ServiceAddresses.dat";

	private const int ResolveAddressTaskTimeoutDurationInSeconds = 30;

	private const int ServiceAddressExpirationTimeInDays = 7;

	private const int MaxRetryCount = 5;

	private static List<CachedServiceAddress> _serviceAddressCache;

	private static string EnvironmentFilePath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ResolveAddress(string serviceDiscoveryAddress, ref string serviceAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TryGetRemoteServiceAddress(string remoteServiceDiscoveryAddress, string serviceName, string environmentId, out ServiceResolvedAddress resolvedAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TryGetRemoteServiceAddressByTag(string remoteServiceDiscoveryAddress, string environmentId, out ServiceResolvedAddress resolvedAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TryGetCachedServiceAddress(string serviceName, string environmentId, out ServiceResolvedAddress resolvedAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CacheServiceAddress(string serviceAddress, string environmentId, ServiceResolvedAddress resolvedAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LoadCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SaveCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ServiceAddressManager()
	{
		throw null;
	}
}
