using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.AchievementSystem;
using TaleWorlds.ActivitySystem;
using TaleWorlds.Diamond;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.PlayerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.PlatformService;

public class NullPlatformServices : IPlatformServices
{
	private TestFriendListService _testFriendListService;

	string IPlatformServices.ProviderName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	string IPlatformServices.UserId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	PlayerId IPlatformServices.PlayerId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	string IPlatformServices.UserDisplayName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	IReadOnlyCollection<PlayerId> IPlatformServices.BlockedUsers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IPlatformServices.IsPermanentMuteAvailable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IPlatformServices.UserLoggedIn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<PlayerId> OnUserStatusChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<AvatarData> OnAvatarUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnBlockedUserListUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<string> OnNameUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<bool, TextObject> OnSignInStateUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<string> OnTextEnteredFromPlatform
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnTextCanceledFromPlatform
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NullPlatformServices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.Initialize(IFriendListService[] additionalFriendListServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.Terminate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.IsPlayerProfileCardAvailable(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.ShowPlayerProfileCard(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.LoginUser()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<AvatarData> IPlatformServices.GetUserAvatar(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IPlatformServices.ShowOverlayForWebPage(string url)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dummy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	PlatformInitParams IPlatformServices.GetInitParams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IFriendListService[] IPlatformServices.GetFriendListServices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateFriendList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<ILoginAccessProvider> IPlatformServices.CreateLobbyClientLoginProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IAchievementService IPlatformServices.GetAchievementService()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IActivityService IPlatformServices.GetActivityService()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.CheckPrivilege(Privilege privilege, bool displayResolveUI, PrivilegeResult callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.CheckPermissionWithUser(Permission privilege, PlayerId targetPlayerId, PermissionResult callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.GetPlatformId(PlayerId playerId, Action<object> callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IPlatformServices.VerifyString(string content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.ShowRestrictedInformation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.OnFocusGained()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.RegisterPermissionChangeEvent(PlayerId targetPlayerId, Permission permission, PermissionChanged Callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.UnregisterPermissionChangeEvent(PlayerId targetPlayerId, Permission permission, PermissionChanged Callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.ShowGamepadTextInput(string descriptionText, string existingText, uint maxLine, bool isObfuscated)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.UsePlatformInvitationService(PlayerId targetPlayerId)
	{
		throw null;
	}
}
