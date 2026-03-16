using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.GauntletUI;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class LauncherOnlineImageTextureProvider : TextureProvider
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CRefreshOnlineImage_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LauncherOnlineImageTextureProvider _003C_003E4__this;

		private string _003CguidOfRequestedURL_003E5__2;

		private WebClient _003Cclient_003E5__3;

		private string _003CpathOfTheDownloadedImage_003E5__4;

		private Task _003CdownloadTask_003E5__5;

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

	private Dictionary<string, string> _onlineImageCache;

	private const string DataFolder = "Mount and Blade II Bannerlord/Online Images/";

	private readonly string _onlineImageCacheFolderPath;

	private Texture _texture;

	private bool _requiresRetry;

	private int _retryCount;

	private const int _maxRetryCount = 10;

	private string _onlineSourceUrl;

	public string OnlineSourceUrl
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LauncherOnlineImageTextureProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CRefreshOnlineImage_003Ed__12))]
	private void RefreshOnlineImage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Texture OnGetTextureForRender(TwoDimensionContext twoDimensionContext, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateOnlineImageCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Guid ToGuid(string src)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTextureCreated(Texture texture)
	{
		throw null;
	}
}
