using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class VirtualFolders
{
	[VirtualDirectory("..")]
	public class Win64_Shipping_Client
	{
		[VirtualDirectory("..")]
		public class bin
		{
			[VirtualDirectory("Parameters")]
			public class Parameters
			{
				[VirtualDirectory("ClientProfiles")]
				public class ClientProfiles
				{
					[VirtualDirectory("Azure.Discovery")]
					public class AzureDiscovery
					{
						[VirtualFile("LobbyClient.xml", "<Configuration>\t<SessionProvider Type=\"ThreadedRest\" />\t<Clients>\t\t<Client Type=\"LobbyClient\" />\t</Clients>\t<Parameters>\t\t<Parameter Name=\"LobbyClient.ServiceDiscovery.Address\" Value=\"https://bannerlord-service-discovery.bannerlord-services-3.net/\" />\t\t<Parameter Name=\"LobbyClient.Address\" Value=\"service://bannerlord.lobby/\" />\t</Parameters></Configuration>")]
						public string LobbyClient;

						[MethodImpl(MethodImplOptions.NoInlining)]
						public AzureDiscovery()
						{
							throw null;
						}
					}

					[MethodImpl(MethodImplOptions.NoInlining)]
					public ClientProfiles()
					{
						throw null;
					}
				}

				[VirtualFile("Environment", "qmCQNuPrXgaznVfoX5i8N7FP3RaIO2p3gBofZp0KSHtaJPdw1AEpfhxbOc6D0BuDylPvybDqZIdjPNHMNwdjVR3bHs.oK67g2CZhZySkIaXbs9.gDnXnsW2zDvVWnb6NNXy2VLgSSnxy84WGmC1zPY3_vsGnB4c_5dhUgtNZHL0-")]
				public string Environment;

				[VirtualFile("Version.xml", "<Version>\t<Singleplayer Value=\"v1.3.15.110062\"/></Version>")]
				public string Version;

				[VirtualFile("ClientProfile.xml", "<ClientProfile Value=\"Azure.Discovery\"/>")]
				public string ClientProfile;

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Parameters()
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public bin()
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Win64_Shipping_Client()
		{
			throw null;
		}
	}

	private static readonly bool _useVirtualFolders;

	public static Dictionary<string, string> PlatformDLCPaths;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFileContent(string filePath, Type type = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetVirtualFileContent(string filePath, Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Type GetNestedDirectory(string name, Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VirtualFolders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VirtualFolders()
	{
		throw null;
	}
}
