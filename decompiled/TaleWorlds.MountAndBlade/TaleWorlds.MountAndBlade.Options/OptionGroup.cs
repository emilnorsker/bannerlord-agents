using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.Options;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Options;

public class OptionGroup
{
	public readonly TextObject GroupName;

	public readonly IEnumerable<IOptionData> Options;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OptionGroup(TextObject groupName, IEnumerable<IOptionData> options)
	{
		throw null;
	}
}
