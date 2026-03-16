using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using psai.net;

namespace psai.Editor;

[Serializable]
public class Theme : PsaiMusicEntity, ICloneable
{
	internal static float PLAYCOUNT_VS_RANDOM_WEIGHTING_IF_PLAYCOUNT_PREFERRED;

	private static readonly string DEFAULT_NAME;

	private static readonly int DEFAULT_PRIORITY;

	private static readonly int DEFAULT_REST_SECONDS_MIN;

	private static readonly int DEFAULT_REST_SECONDS_MAX;

	private static readonly int DEFAULT_FADEOUT_MS;

	private static readonly int DEFAULT_THEME_DURATION_SECONDS;

	private static readonly float DEFAULT_INTENSITY_AFTER_REST;

	private static readonly int DEFAULT_THEME_DURATION_SECONDS_AFTER_REST;

	private static readonly float DEFAULT_WEIGHTING_COMPATIBILITY;

	private static readonly float DEFAULT_WEIGHTING_INTENSITY;

	private static readonly float DEFAULT_WEIGHTING_LOW_PLAYCOUNT_VS_RANDOM;

	private static readonly int DEFAULT_THEMETYPEINT;

	private List<Group> _groups;

	private HashSet<Theme> _manuallyBlockedThemes;

	private float _intensityAfterRest;

	private int _id;

	public int Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public string Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int ThemeTypeInt
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public List<int> Serialization_ManuallyBlockedThemeIds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[XmlIgnore]
	public HashSet<Theme> ManuallyBlockedTargetThemes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public float IntensityAfterRest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public int MusicPhaseSecondsAfterRest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int MusicPhaseSecondsGeneral
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int RestSecondsMin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int RestSecondsMax
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int FadeoutMs
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float WeightingSwitchGroups
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float WeightingIntensityVsVariance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float WeightingLowPlaycountVsRandom
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public List<Group> Groups
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ConvertPlaycountVsRandomWeightingToBooleanPlaycountPreferred(float weightingPlaycountVsRandom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetClassString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<PsaiMusicEntity> GetChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme(int id, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PsaiMusicEntity GetParent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AddGroup(Group groupToAdd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteGroup(Group group)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HashSet<Segment> GetSegmentsOfAllGroups()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HashSet<string> GetAudioDataRelativeFilePathsUsedByThisTheme()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CompatibilitySetting GetCompatibilitySetting(PsaiMusicEntity targetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CompatibilityType GetCompatibilityType(PsaiMusicEntity targetEntity, out CompatibilityReason reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIndexPositionWithinParentEntity(PsaiProject parentProject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool PropertyDifferencesAffectCompatibilities(PsaiMusicEntity otherEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsParentThemeForAllGroupsAndSegments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public psai.net.Theme CreatePsaiDotNetVersion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Theme getTestTheme1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Theme getTestTheme2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override object Clone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PsaiMusicEntity ShallowCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Theme()
	{
		throw null;
	}
}
