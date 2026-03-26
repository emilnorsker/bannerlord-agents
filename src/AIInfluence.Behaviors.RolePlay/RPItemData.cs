using System.Collections.Generic;

namespace AIInfluence.Behaviors.RolePlay;

[JsonSerializable]
public class RPItemData
{
	public string ItemId { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string BaseItemId { get; set; }

	public string ModifierStringId { get; set; }

	public string CreatedBy { get; set; }

	public int CreatedDay { get; set; }

	public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

	public string CustomTexturePath { get; set; }

	public string Owner { get; set; }
}
