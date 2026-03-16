using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public class BannerManager
{
	public const int DarkRed = 1;

	public const int Green = 120;

	public const int Blue = 119;

	public const int Purple = 4;

	public const int DarkPurple = 6;

	public const int Orange = 9;

	public const int DarkBlue = 12;

	public const int Red = 118;

	public const int Yellow = 121;

	public MBReadOnlyDictionary<int, BannerColor> ReadOnlyColorPalette;

	private Dictionary<BasicCultureObject, List<BannerColor>> _cultureColorPalette;

	private Dictionary<int, BannerColor> _colorPalette;

	private MBList<BannerIconGroup> _bannerIconGroups;

	private int _availablePatternCount;

	private int _availableIconCount;

	public static BannerManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public MBReadOnlyList<BannerIconGroup> BannerIconGroups
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int BaseBackgroundId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	private static MBReadOnlyDictionary<int, BannerColor> ColorPalette
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BannerManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetAndLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint GetColor(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetColorId(uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRandomColorId(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerIconData GetIconDataFromIconId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRandomBackgroundId(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRandomBannerIconId(MBFastRandom random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetBackgroundMeshName(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetIconSourceTextureName(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBaseBackgroundId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCultureColors(BasicCultureObject culture, List<BannerColor> color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadBannerIcons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadBannerIcons(string xmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadBannerIconsFromXml(XmlDocument doc)
	{
		throw null;
	}
}
