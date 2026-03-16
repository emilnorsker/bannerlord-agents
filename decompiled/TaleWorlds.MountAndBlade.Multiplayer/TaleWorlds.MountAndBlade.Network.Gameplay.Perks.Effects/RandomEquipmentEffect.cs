using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class RandomEquipmentEffect : MPRandomOnSpawnPerkEffect
{
	protected static string StringType;

	private MBList<List<(EquipmentIndex, EquipmentElement)>> _groups;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RandomEquipmentEffect()
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
	static RandomEquipmentEffect()
	{
		throw null;
	}
}
