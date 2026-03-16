using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public readonly struct CampaignSaveMetaDataArgs
{
	public readonly string[] ModuleNames;

	public readonly KeyValuePair<string, string>[] OtherData;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignSaveMetaDataArgs(string[] moduleName, params KeyValuePair<string, string>[] otherArgs)
	{
		throw null;
	}
}
