using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.Diamond.AccessProvider.GDK;

public class GDKLoginAccessProvider : ILoginAccessProvider
{
	private PlatformInitParams _initParams;

	private string _gamerTag;

	private ulong _xuid;

	private PlayerId _playerId;

	private TextObject _initializationFailReason;

	private string _token;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GDKLoginAccessProvider(string gamerTag, ulong xuid, string token, PlayerId playerId, TextObject initializationFailReason)
	{
		throw null;
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
}
