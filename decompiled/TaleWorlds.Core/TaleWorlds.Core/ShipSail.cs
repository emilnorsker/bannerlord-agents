using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class ShipSail
{
	public readonly MissionShipObject ShipObject;

	public readonly int Index;

	public readonly SailType Type;

	public readonly float ForceMultiplier;

	public readonly float LeftRotationLimit;

	public readonly float RightRotationLimit;

	public readonly float RotationRate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipSail(MissionShipObject shipObject, int index, SailType type, float forceMultiplier, float leftRotationLimit, float rightRotationLimit, float rotationRate)
	{
		throw null;
	}
}
