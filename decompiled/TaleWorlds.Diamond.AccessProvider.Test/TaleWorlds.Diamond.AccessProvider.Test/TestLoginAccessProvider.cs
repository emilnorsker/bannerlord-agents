using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.Diamond.AccessProvider.Test;

public class TestLoginAccessProvider : ILoginAccessProvider
{
	private string _userName;

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
	public static ulong GetInt64HashCode(string strText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlayerId GetPlayerIdFromUserName(string userName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TestLoginAccessProvider()
	{
		throw null;
	}
}
