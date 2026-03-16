using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Missions.Multiplayer;

public readonly struct MultiplayerBattleColors
{
	public readonly struct MultiplayerCultureColorInfo
	{
		public readonly BasicCultureObject Culture;

		public readonly Color Color1;

		public readonly uint Color1Uint;

		public readonly Color Color2;

		public readonly uint Color2Uint;

		public readonly Color ClothingColor1;

		public readonly uint ClothingColor1Uint;

		public readonly Color ClothingColor2;

		public readonly uint ClothingColor2Uint;

		public readonly Color BannerBackgroundColor;

		public readonly uint BannerBackgroundColorUint;

		public readonly Color BannerForegroundColor;

		public readonly uint BannerForegroundColorUint;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MultiplayerCultureColorInfo(BasicCultureObject culture, bool swapColors)
		{
			throw null;
		}
	}

	public readonly MultiplayerCultureColorInfo AttackerColors;

	public readonly MultiplayerCultureColorInfo DefenderColors;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerBattleColors(MultiplayerCultureColorInfo attackerColors, MultiplayerCultureColorInfo defenderColors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MultiplayerBattleColors CreateWith(BasicCultureObject attackerCulture, BasicCultureObject defenderCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerCultureColorInfo GetPeerColors(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MultiplayerBattleColors GetCultureColors(BasicCultureObject attackerCulture, BasicCultureObject defenderCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static BasicCultureObject GetFallbackCulture()
	{
		throw null;
	}
}
