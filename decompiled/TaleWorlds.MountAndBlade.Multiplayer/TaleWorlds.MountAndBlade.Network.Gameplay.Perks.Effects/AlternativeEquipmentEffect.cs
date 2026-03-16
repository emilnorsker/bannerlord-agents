using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class AlternativeEquipmentEffect : MPOnSpawnPerkEffect
{
	protected static string StringType;

	private EquipmentElement _item;

	private EquipmentIndex _index;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected AlternativeEquipmentEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(EquipmentIndex, EquipmentElement)> GetAlternativeEquipments(bool isPlayer, List<(EquipmentIndex, EquipmentElement)> alternativeEquipments, bool getAll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static AlternativeEquipmentEffect()
	{
		throw null;
	}
}
