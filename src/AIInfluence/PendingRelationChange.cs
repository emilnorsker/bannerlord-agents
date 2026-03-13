using TaleWorlds.Library;

namespace AIInfluence;

[JsonSerializable]
public class PendingRelationChange
{
	public int RelationChange { get; set; }

	public string Message { get; set; }

	public Color Color { get; set; }
}
