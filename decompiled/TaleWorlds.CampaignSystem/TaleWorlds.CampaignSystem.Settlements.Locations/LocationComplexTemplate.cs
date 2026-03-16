using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.CampaignSystem.Settlements.Locations;

public sealed class LocationComplexTemplate : MBObjectBase
{
	public List<Location> Locations;

	public List<KeyValuePair<string, string>> Passages;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LocationComplexTemplate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		throw null;
	}
}
