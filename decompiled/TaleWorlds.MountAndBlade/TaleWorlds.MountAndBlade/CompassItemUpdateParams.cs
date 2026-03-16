using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct CompassItemUpdateParams
{
	public readonly object Item;

	public readonly TargetIconType TargetType;

	public readonly Vec3 WorldPosition;

	public readonly uint Color;

	public readonly uint Color2;

	public readonly Banner Banner;

	public readonly bool IsAttacker;

	public readonly bool IsAlly;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompassItemUpdateParams(object item, TargetIconType targetType, Vec3 worldPosition, uint color, uint color2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompassItemUpdateParams(object item, TargetIconType targetType, Vec3 worldPosition, Banner banner, bool isAttacker, bool isAlly)
	{
		throw null;
	}
}
