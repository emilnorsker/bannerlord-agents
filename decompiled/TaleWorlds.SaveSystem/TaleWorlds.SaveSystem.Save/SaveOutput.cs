using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem.Save;

public class SaveOutput
{
	private Task<SaveResultWithMessage> _continuingTask;

	public GameData Data
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

	public SaveResult Result
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

	public SaveError[] Errors
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

	public bool Successful
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsContinuing
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SaveOutput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static SaveOutput CreateSuccessful(GameData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static SaveOutput CreateFailed(IEnumerable<SaveError> errors, SaveResult result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static SaveOutput CreateContinuing(Task<SaveResultWithMessage> continuingTask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrintStatus()
	{
		throw null;
	}
}
