using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SandBox.ViewModelCollection.GameOver;

public class StatCategory
{
	public readonly IEnumerable<StatItem> Items;

	public readonly string ID;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StatCategory(string id, IEnumerable<StatItem> items)
	{
		throw null;
	}
}
