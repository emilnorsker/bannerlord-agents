namespace AIInfluence.SettlementCombat;

public class SideCasualtySummary
{
	public int Killed { get; set; }

	public int Wounded { get; set; }

	public SideCasualtySummary Clone()
	{
		return new SideCasualtySummary
		{
			Killed = Killed,
			Wounded = Wounded
		};
	}
}
