using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem.Load;

internal abstract class MemberLoadData : VariableLoadData
{
	public ObjectLoadData ObjectLoadData
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
	protected MemberLoadData(ObjectLoadData objectLoadData, IReader reader)
	{
		throw null;
	}
}
