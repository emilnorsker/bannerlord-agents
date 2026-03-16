using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Platform;
using Epic.OnlineServices.Presence;
using Epic.OnlineServices.UserInfo;
using Newtonsoft.Json;
using TaleWorlds.AchievementSystem;
using TaleWorlds.ActivitySystem;
using TaleWorlds.Diamond;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.PlayerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.PlatformService.Epic;

public class EpicPlatformServices : IPlatformServices
{
	private class IngestStatsQueueItem
	{
		public string Name
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

		public int Value
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
		public IngestStatsQueueItem()
		{
			throw null;
		}
	}

	private class EpicAuthErrorResponse
	{
		[JsonProperty("errorCode")]
		public string ErrorCode
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

		[JsonProperty("errorMessage")]
		public string ErrorMessage
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

		[JsonProperty("numericErrorCode")]
		public int NumericErrorCode
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

		[JsonProperty("error_description")]
		public string ErrorDescription
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

		[JsonProperty("error")]
		public string Error
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
		public EpicAuthErrorResponse()
		{
			throw null;
		}
	}

	private class EpicAuthResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken
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

		[JsonProperty("expires_in")]
		public int ExpiresIn
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

		[JsonProperty("expires_at")]
		public DateTime ExpiresAt
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

		[JsonProperty("token_type")]
		public string TokenType
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

		[JsonProperty("refresh_token")]
		public string RefreshToken
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

		[JsonProperty("refresh_expires")]
		public int RefreshExpires
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

		[JsonProperty("refresh_expires_at")]
		public DateTime RefreshExpiresAt
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

		[JsonProperty("account_id")]
		public string AccountId
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

		[JsonProperty("client_id")]
		public string ClientId
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

		[JsonProperty("internal_client")]
		public bool InternalClient
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

		[JsonProperty("client_service")]
		public string ClientService
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

		[JsonProperty("displayName")]
		public string DisplayName
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

		[JsonProperty("app")]
		public string App
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

		[JsonProperty("in_app_id")]
		public string InAppId
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

		[JsonProperty("device_id")]
		public string DeviceId
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

		[JsonProperty("product_id")]
		public string ProductId
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
		public EpicAuthResponse()
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetUserName_003Ed__68 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public PlayerId providedId;

		public EpicPlatformServices _003C_003E4__this;

		private TaskAwaiter<UserInfoData?> _003C_003Eu__1;

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
	private struct _003CGetUserOnlineStatus_003Ed__69 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public PlayerId providedId;

		public EpicPlatformServices _003C_003E4__this;

		private EpicAccountId _003CtargetUserId_003E5__2;

		private TaskAwaiter<UserInfoData?> _003C_003Eu__1;

		private TaskAwaiter<Info?> _003C_003Eu__2;

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
	private struct _003CIsPlayingThisGame_003Ed__70 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public EpicPlatformServices _003C_003E4__this;

		public PlayerId providedId;

		private TaskAwaiter<Info?> _003C_003Eu__1;

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

	private EpicAccountId _epicAccountId;

	private ProductUserId _localUserId;

	private string _accessToken;

	private string _epicUserName;

	private PlatformInterface _platform;

	private PlatformInitParams _initParams;

	private EpicFriendListService _epicFriendListService;

	private IFriendListService[] _friendListServices;

	private TextObject _initFailReason;

	private ulong _refreshConnectionCallbackId;

	private ConcurrentBag<IngestStatsQueueItem> _ingestStatsQueue;

	private bool _writingStats;

	private DateTime _statsLastWrittenOn;

	private const int MinStatsWriteInterval = 5;

	public string UserId
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

	private string ExchangeCode
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
	public EpicPlatformServices(PlatformInitParams initParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Initialize(IFriendListService[] additionalFriendListServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dummy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshConnection(ref AuthExpirationCallbackInfo clientData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Connect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Terminate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
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
	Task<ILoginAccessProvider> IPlatformServices.CreateLobbyClientLoginProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	PlatformInitParams IPlatformServices.GetInitParams()
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
	Task<bool> IPlatformServices.VerifyString(string content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.OnFocusGained()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IPlatformServices.GetPlatformId(PlayerId playerId, Action<object> callback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetUserName_003Ed__68))]
	internal Task<string> GetUserName(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetUserOnlineStatus_003Ed__69))]
	internal Task<bool> GetUserOnlineStatus(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CIsPlayingThisGame_003Ed__70))]
	internal Task<bool> IsPlayingThisGame(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Task<PlayerId> GetUserWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal IEnumerable<PlayerId> GetAllFriends()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void QueryDefinitions()
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
	private void ProcessIngestStatsQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PlayerId EpicAccountIdToPlayerId(EpicAccountId epicAccountId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static EpicAccountId PlayerIdToEpicAccountId(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Task<UserInfoData?> GetUserInfo(EpicAccountId targetUserId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Task<Info?> GetUserPresence(EpicAccountId targetUserId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QueryStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IFriendListService[] IPlatformServices.GetFriendListServices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShowGamepadTextInput(string descriptionText, string existingText, uint maxChars, bool isObfuscated)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IPlatformServices.UsePlatformInvitationService(PlayerId targetPlayerId)
	{
		throw null;
	}
}
