using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Diamond.Lobby;

public abstract class MultiplayerLocalDataContainer<T> where T : MultiplayerLocalData
{
	private enum OperationType
	{
		Add,
		Insert,
		Remove
	}

	private struct ContainerOperation
	{
		public readonly OperationType OperationType;

		public readonly T Item;

		public readonly int Index;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private ContainerOperation(OperationType type, T item, int index)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ContainerOperation CreateAsAdd(T item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ContainerOperation CreateAsRemove(T item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ContainerOperation CreateAsInsert(T item, int index)
		{
			throw null;
		}
	}

	private class ContainerOperationComparer : IComparer<ContainerOperation>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(ContainerOperation x, ContainerOperation y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ContainerOperationComparer()
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTick_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MultiplayerLocalDataContainer<T> _003C_003E4__this;

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
	private struct _003CSaveFileAux_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MultiplayerLocalDataContainer<T> _003C_003E4__this;

		private TaskAwaiter<SaveResult> _003C_003Eu__1;

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
	private struct _003CLoadFileAux_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MultiplayerLocalDataContainer<T> _003C_003E4__this;

		private PlatformFilePath _003ColdFilePath_003E5__2;

		private TaskAwaiter<string> _003C_003Eu__1;

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

	private readonly string _saveDirectoryName;

	private readonly string _saveFileName;

	private readonly List<ContainerOperation> _operationQueue;

	private readonly List<T> _dataList;

	private bool _isFileDirty;

	private bool _isCacheDirty;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerLocalDataContainer()
	{
		throw null;
	}

	protected abstract string GetSaveDirectoryName();

	protected abstract string GetSaveFileName();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntry(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InsertEntry(T item, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEntry(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<T> GetEntries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(MultiplayerLocalDataContainer<>._003CTick_003Ed__15))]
	internal Task Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleOperation(ContainerOperation operation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEntryAux(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InsertEntryAux(T item, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBeforeAddEntry(T item, out bool canAddEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveEntryAux(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBeforeRemoveEntry(T item, out bool canRemoveEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PlatformFilePath GetDataFilePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(MultiplayerLocalDataContainer<>._003CSaveFileAux_003Ed__23))]
	private Task SaveFileAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(MultiplayerLocalDataContainer<>._003CLoadFileAux_003Ed__24))]
	private Task LoadFileAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual PlatformFilePath GetCompatibilityFilePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual List<T> DeserializeInCompatibilityMode(string serializedJson)
	{
		throw null;
	}
}
