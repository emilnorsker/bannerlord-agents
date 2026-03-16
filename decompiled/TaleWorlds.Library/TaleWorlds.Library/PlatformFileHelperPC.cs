using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public class PlatformFileHelperPC : IPlatformFileHelper
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetFileContentStringAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public PlatformFileHelperPC _003C_003E4__this;

		public PlatformFilePath path;

		private FileStream _003CsourceStream_003E5__2;

		private byte[] _003Cbuffer_003E5__3;

		private TaskAwaiter<int> _003C_003Eu__1;

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

	private readonly string ApplicationName;

	private static string Error;

	private string DocumentsPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private string ProgramDataPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformFileHelperPC(string applicationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveResult SaveFile(PlatformFilePath path, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveResult SaveFileString(PlatformFilePath path, string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Task<SaveResult> SaveFileAsync(PlatformFilePath path, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Task<SaveResult> SaveFileStringAsync(PlatformFilePath path, string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveResult AppendLineToFileString(PlatformFilePath path, string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetDirectoryFullPath(PlatformDirectoryPath directoryPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFileFullPath(PlatformFilePath filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FileExists(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetFileContentStringAsync_003Ed__15))]
	public Task<string> GetFileContentStringAsync(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFileContentString(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] GetMetaDataContent(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] GetFileContent(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DeleteFile(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateDirectory(PlatformDirectoryPath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformFilePath[] GetFiles(PlatformDirectoryPath path, string searchPattern, SearchOption searchOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenameFile(PlatformFilePath filePath, string newName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetError()
	{
		throw null;
	}
}
