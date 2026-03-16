using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct SaveResultWithMessage
{
	public readonly SaveResult SaveResult;

	public readonly string Message;

	public static SaveResultWithMessage Default
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveResultWithMessage(SaveResult result, string message)
	{
		throw null;
	}
}
