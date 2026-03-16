using System.Runtime.CompilerServices;

namespace SandBox.ViewModelCollection.GameOver;

public class StatItem
{
	public enum StatType
	{
		None,
		Influence,
		Issue,
		Tournament,
		Gold,
		Crime,
		Kill
	}

	public readonly string ID;

	public readonly string Value;

	public readonly StatType Type;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StatItem(string id, string value, StatType type = StatType.None)
	{
		throw null;
	}
}
