using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class ParameterFile
{
	private int _failedAttemptsCount;

	private const int MaxFailedAttemptsCount = 100;

	public string Path
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

	public DateTime LastCheckedTime
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

	public ParameterContainer ParameterContainer
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
	public ParameterFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfNeedsToBeRefreshed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh()
	{
		throw null;
	}
}
