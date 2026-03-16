using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.Options;

namespace TaleWorlds.MountAndBlade.Options;

public class OptionCategory
{
	public readonly IEnumerable<IOptionData> BaseOptions;

	public readonly IEnumerable<OptionGroup> Groups;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OptionCategory(IEnumerable<IOptionData> baseOptions, IEnumerable<OptionGroup> groups)
	{
		throw null;
	}
}
