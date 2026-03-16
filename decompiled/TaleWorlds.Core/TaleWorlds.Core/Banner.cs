using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.Core;

public class Banner
{
	private enum BannerIconOrientation
	{
		None = -1,
		CentralPositionedOneIcon,
		CenteredTwoMirroredIcons,
		DiagonalIcons,
		HorizontalIcons,
		VerticalIcons,
		SquarePositionedFourIcons,
		NumberOfOrientation
	}

	public const int MaxSize = 8000;

	public const int BannerFullSize = 1528;

	public const int BannerEditableAreaSize = 512;

	public const int MaxIconCount = 32;

	private const char Splitter = '.';

	public const int BackgroundDataIndex = 0;

	public const int BannerIconDataIndex = 1;

	[CachedData]
	private string _bannerCode;

	[SaveableField(1)]
	private readonly MBList<BannerData> _bannerDataList;

	[CachedData]
	private IBannerVisual _bannerVisual;

	public string BannerCode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<BannerData> BannerDataList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IBannerVisual BannerVisual
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Banner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Banner(Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Banner(Banner banner, uint color1, uint color2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Banner(string bannerKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Banner(string bannerKey, uint color1, uint color2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBannerVisual(IBannerVisual visual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerData GetBannerDataAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBannerDataListCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBannerDataListEmpty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPrimaryColorId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSecondaryColorId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIconColorId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetIconSize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPrimaryColorId(int colorId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSecondaryColorId(int colorId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIconColorId(int colorId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIconSize(int newSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangePrimaryColor(uint mainColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeBackgroundColor(uint primaryColor, uint secondaryColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeIconColors(uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateBackgroundToRight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateBackgroundToLeft()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBackgroundMeshId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIconMeshId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBackgroundMeshId(int meshId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIconMeshId(int meshId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string Serialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deserialize(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAllIcons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddIconData(BannerData iconData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddIconData(BannerData iconData, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveIconDataAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Banner CreateRandomClanBanner(int seed = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Banner CreateRandomBanner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Banner CreateRandomBannerInternal(int seed = -1, BannerIconOrientation orientation = BannerIconOrientation.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Banner CreateOneColoredEmptyBanner(int colorIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Banner CreateOneColoredBannerWithOneIcon(uint backgroundColor, uint iconColor, int iconMeshId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CentralPositionedOneIcon(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DiagonalIcons(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HorizontalIcons(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VerticalIcons(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SquarePositionedFourIcons(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CenteredTwoMirroredIcons(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetPrimaryColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetSecondaryColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFirstIconColor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetVersionNo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetBannerCodeFromBannerDataList(MBList<BannerData> bannerDataList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsValidBannerCode(string bannerCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetBannerDataFromCode(string bannerCode, out List<BannerData> bannerDataList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AutoGeneratedStaticCollectObjectsBanner(object o, List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object AutoGeneratedGetMemberValue_bannerDataList(object o)
	{
		throw null;
	}
}
