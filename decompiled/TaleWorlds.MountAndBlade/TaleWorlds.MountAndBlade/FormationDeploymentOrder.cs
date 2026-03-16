using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public struct FormationDeploymentOrder
{
	public class DeploymentOrderComparer : IComparer<FormationDeploymentOrder>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(FormationDeploymentOrder a, FormationDeploymentOrder b)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DeploymentOrderComparer()
		{
			throw null;
		}
	}

	private static DeploymentOrderComparer _comparer;

	public int Key
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

	public int Offset
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
	private FormationDeploymentOrder(FormationClass formationClass, int offset = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FormationDeploymentOrder GetDeploymentOrder(FormationClass fClass, int offset = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static DeploymentOrderComparer GetComparer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetFormationClassPriority(FormationClass fClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FormationDeploymentOrder()
	{
		throw null;
	}
}
