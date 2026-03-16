using System.Runtime.CompilerServices;
using Galaxy.Api;

namespace TaleWorlds.PlatformService.GOG;

public class AuthenticationListener : GlobalAuthListener
{
	private GOGPlatformServices _gogPlatformServices;

	public bool GotResult
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
	public AuthenticationListener(GOGPlatformServices gogPlatformServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAuthSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAuthFailure(FailureReason failureReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAuthLost()
	{
		throw null;
	}
}
