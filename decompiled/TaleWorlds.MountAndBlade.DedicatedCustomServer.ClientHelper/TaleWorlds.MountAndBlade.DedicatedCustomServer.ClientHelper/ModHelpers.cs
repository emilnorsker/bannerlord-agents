using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaleWorlds.MountAndBlade.DedicatedCustomServer.ClientHelper;

internal static class ModHelpers
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDownloadToTempFile_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public HttpClient httpClient;

		public string url;

		public CancellationToken cancellationToken;

		public IProgress<ProgressUpdate> progress;

		private string _003CtempFilePath_003E5__2;

		private FileStream _003CtempFileStream_003E5__3;

		private HttpResponseMessage _003Cresponse_003E5__4;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private long? _003CcontentLength_003E5__5;

		private TaskAwaiter<string> _003C_003Eu__2;

		private Stream _003CdownloadStream_003E5__6;

		private TaskAwaiter<Stream> _003C_003Eu__3;

		private TaskAwaiter _003C_003Eu__4;

		private byte[] _003Cbuffer_003E5__7;

		private long _003CtotalBytesRead_003E5__8;

		private int _003CbytesRead_003E5__9;

		private TaskAwaiter<int> _003C_003Eu__5;

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

	public static string RootPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSceneObjRootPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DoesSceneFolderAlreadyExist(string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetTempFilePath(string anyIdentifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ReadSceneNameOfDirectory(string sceneDirectoryPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string WriteBufferToTempFile(byte[] buffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FileStream GetTempFileStream()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ExtractZipToTempDirectory(string sourceZipFilePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CDownloadToTempFile_003Ed__9))]
	public static Task<string> DownloadToTempFile(HttpClient httpClient, string url, IProgress<ProgressUpdate> progress = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		throw null;
	}
}
