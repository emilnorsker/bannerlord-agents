using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public class BannerIconGroup
{
	public MBReadOnlyDictionary<int, BannerIconData> AllIcons;

	public MBReadOnlyDictionary<int, string> AllBackgrounds;

	public MBReadOnlyDictionary<int, BannerIconData> AvailableIcons;

	private Dictionary<int, BannerIconData> _allIcons;

	private Dictionary<int, string> _allBackgrounds;

	private Dictionary<int, BannerIconData> _availableIcons;

	public TextObject Name
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

	public bool IsPattern
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

	public int Id
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal BannerIconGroup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deserialize(XmlNode xmlNode, MBList<BannerIconGroup> previouslyAddedGroups)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Merge(BannerIconGroup otherGroup)
	{
		throw null;
	}
}
