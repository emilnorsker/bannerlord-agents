using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Galaxy.Api;
using TaleWorlds.AchievementSystem;
using TaleWorlds.ActivitySystem;
using TaleWorlds.Diamond;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.PlayerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.PlatformService.GOG;

public class GOGPlatformServices : IPlatformServices
{
	private readonly struct AchievementData
	{
		public readonly string AchievementName;

		public readonly IReadOnlyList<(string StatName, int Threshold)> RequiredStats;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AchievementData(string achievementName, IReadOnlyList<(string StatName, int Threshold)> requiredStats)
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DPlatformService_002DIPlatformServices_002DGetUserAvatar_003Ed__62 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AvatarData> _003C_003Et__builder;

		public PlayerId providedId;

		public GOGPlatformServices _003C_003E4__this;

		private GalaxyID _003CgalaxyID_003E5__2;

		private UserInformationRetrieveListener _003Clistener_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetUserName_003Ed__75 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public PlayerId providedId;

		private GalaxyID _003CgogId_003E5__2;

		private IFriends _003Cfriends_003E5__3;

		private UserInformationRetrieveListener _003CinformationRetriever_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private const string ClientID = "53550366963454221";

	private const string ClientSecret = "c17786edab4b6b3915ab55cfc5bb5a9a0a80b9a2d55d22c0767c9c18477efdb9";

	private PlatformInitParams _initParams;

	private GOGFriendListService _gogFriendListService;

	private IFriendListService[] _friendListServices;

	private bool _initialized;

	private DateTime? _statsLastInvalidated;

	private DateTime _statsLastStored;

	private UserStatsAndAchievementsRetrieveListener _achievementRetrieveListener;

	private StatsAndAchievementsStoreListener _statsAndAchievementsStoreListener;

	private List<AchievementData> _achievementDatas;

	private Dictionary<PlayerId, AvatarData> _avatarCache;

	private static GOGPlatformServices Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

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

	bool IPlatformServices.UserLoggedIn
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
	public GOGPlatformServices(PlatformInitParams initParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.LoginUser()
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
	Task<bool> IPlatformServices.VerifyString(string content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.GetPlatformId(PlayerId playerId, Action<object> callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.Initialize(IFriendListService[] additionalFriendListServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.Terminate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvalidateStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckStoreStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dummy()
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
	internal void ClearAvatarCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DPlatformService_002DIPlatformServices_002DGetUserAvatar_003Ed__62))]
	Task<AvatarData> IPlatformServices.GetUserAvatar(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	PlatformInitParams IPlatformServices.GetInitParams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Task<PlayerId> GetUserWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IPlatformServices.ShowOverlayForWebPage(string url)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<ILoginAccessProvider> IPlatformServices.CreateLobbyClientLoginProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IFriendListService[] IPlatformServices.GetFriendListServices()
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
	bool IPlatformServices.RegisterPermissionChangeEvent(PlayerId targetPlayerId, Permission permission, PermissionChanged callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.UnregisterPermissionChangeEvent(PlayerId targetPlayerId, Permission permission, PermissionChanged callback)
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
	private void LoadAchievementDataFromXml(string xmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetUserName_003Ed__75))]
	internal Task<string> GetUserName(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool SetStat(string name, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Task<int> GetStat(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Task<int[]> GetStats(string[] names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RequestUserStatsAndAchievements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GOGAchievement GetGOGAchievement(string name, GalaxyID galaxyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckStatsAndUnlockAchievements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckStatsAndUnlockAchievement(in AchievementData achievementData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.UsePlatformInvitationService(PlayerId targetPlayerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitListeners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUserStatsAndAchievementsStored(bool success, FailureReason? failureReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUserStatsAndAchievementsRetrieved(GalaxyID userID, bool success, FailureReason? failureReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.ShowGamepadTextInput(string descriptionText, string existingText, uint maxLine, bool isObfuscated)
	{
		throw null;
	}
}
