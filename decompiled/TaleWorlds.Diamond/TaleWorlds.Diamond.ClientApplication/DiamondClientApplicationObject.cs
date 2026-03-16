using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Diamond.ClientApplication;

public abstract class DiamondClientApplicationObject
{
	private DiamondClientApplication _application;

	public DiamondClientApplication Application
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ApplicationVersion ApplicationVersion
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DiamondClientApplicationObject(DiamondClientApplication application)
	{
		throw null;
	}
}
