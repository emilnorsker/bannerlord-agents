namespace AIInfluence.SettlementCombat;

public class VipCasualtyRecord
{
	public string VictimName { get; set; }

	public string VictimStringId { get; set; }

	public CombatSide Side { get; set; }

	public bool IsKilled { get; set; }

	public string KillerName { get; set; }

	public string KillerStringId { get; set; }

	public string KillerType { get; set; }

	public VipCasualtyRecord Clone()
	{
		return new VipCasualtyRecord
		{
			VictimName = VictimName,
			VictimStringId = VictimStringId,
			Side = Side,
			IsKilled = IsKilled,
			KillerName = KillerName,
			KillerStringId = KillerStringId,
			KillerType = KillerType
		};
	}
}
