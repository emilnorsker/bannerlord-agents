namespace AIInfluence.SettlementCombat;

public class CivilianCasualtySummary
{
	public int MenKilled { get; set; }

	public int WomenKilled { get; set; }

	public int ChildrenKilled { get; set; }

	public int MenWounded { get; set; }

	public int WomenWounded { get; set; }

	public int ChildrenWounded { get; set; }

	public CivilianCasualtySummary Clone()
	{
		return new CivilianCasualtySummary
		{
			MenKilled = MenKilled,
			WomenKilled = WomenKilled,
			ChildrenKilled = ChildrenKilled,
			MenWounded = MenWounded,
			WomenWounded = WomenWounded,
			ChildrenWounded = ChildrenWounded
		};
	}
}
