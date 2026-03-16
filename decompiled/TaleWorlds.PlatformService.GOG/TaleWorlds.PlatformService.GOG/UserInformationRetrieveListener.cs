using System.Runtime.CompilerServices;
using Galaxy.Api;

namespace TaleWorlds.PlatformService.GOG;

public class UserInformationRetrieveListener : IUserInformationRetrieveListener
{
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
	public override void OnUserInformationRetrieveFailure(GalaxyID userID, FailureReason failureReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUserInformationRetrieveSuccess(GalaxyID userID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UserInformationRetrieveListener()
	{
		throw null;
	}
}
