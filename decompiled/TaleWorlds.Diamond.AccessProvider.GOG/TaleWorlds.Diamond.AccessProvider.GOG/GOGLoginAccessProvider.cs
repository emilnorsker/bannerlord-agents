using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.Diamond.AccessProvider.GOG;

public class GOGLoginAccessProvider : ILoginAccessProvider
{
	private string _gogUserName;

	private ulong _gogId;

	private ulong _oldId;

	private PlatformInitParams _initParams;

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
	public GOGLoginAccessProvider()
	{
		throw null;
	}
}
