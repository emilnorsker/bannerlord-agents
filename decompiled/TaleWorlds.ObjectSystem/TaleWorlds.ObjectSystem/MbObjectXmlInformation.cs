using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.ObjectSystem;

public struct MbObjectXmlInformation
{
	public string Id;

	public string Name;

	public string ModuleName;

	public List<string> GameTypesIncluded;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbObjectXmlInformation(string id, string name, string moduleName, List<string> gameTypesIncluded)
	{
		throw null;
	}
}
