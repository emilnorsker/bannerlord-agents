using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.Diamond.AccessProvider.Steam;

public class SteamLoginAccessProvider : ILoginAccessProvider
{
	private string _steamUserName;

	private ulong _steamId;

	private PlatformInitParams _initParams;

	private uint _appId;

	private int AppId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILoginAccessProvider.Initialize(string preferredUserName, PlatformInitParams initParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string ILoginAccessProvider.GetUserName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	PlayerId ILoginAccessProvider.GetPlayerId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	AccessObjectResult ILoginAccessProvider.CreateAccessObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SteamLoginAccessProvider()
	{
		throw null;
	}
}
