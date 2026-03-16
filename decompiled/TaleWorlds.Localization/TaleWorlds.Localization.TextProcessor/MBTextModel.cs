using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization.Expressions;

namespace TaleWorlds.Localization.TextProcessor;

public class MBTextModel
{
	internal MBList<TextExpression> _rootExpressions;

	internal MBReadOnlyList<TextExpression> RootExpressions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBTextModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddRootExpression(TextExpression newExp)
	{
		throw null;
	}
}
