using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;

namespace NavalDLC.HotKeyCategories;

public class NavalCheatsHotKeyCategory : GameKeyContext
{
	public const string CategoryId = "NavalCheatsHotKeyCategory";

	public const string DebugSailingMoveToRight = "DebugSailingMoveToRight";

	public const string DebugSailingMoveToLeft = "DebugSailingMoveToLeft";

	public const string DebugRammingCollision = "DebugRammingCollision";

	public const string DebugDealSiegeEngineDamage = "DebugDealSiegeEngineDamage";

	public const string DebugSetWindDirection = "DebugSetWindDirection";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalCheatsHotKeyCategory()
	{
		throw null;
	}
}
