using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using psai.net;

namespace psai.Editor;

[Serializable]
public class Segment : PsaiMusicEntity, ICloneable
{
	private const int DEFAULT_SNIPPET_TYPES = 3;

	private const float DEFAULT_INTENSITY = 0.5f;

	private const float COMPATIBILITY_PERCENTAGE_SAME_GROUP = 1f;

	private const float COMPATIBILITY_PERCENTAGE_OTHER_GROUP = 0.5f;

	private float _intensity;

	[NonSerialized]
	private Dictionary<int, float> _compatibleSnippetsIds;

	[NonSerialized]
	private HashSet<Segment> _manuallyLinkedSnippets;

	[NonSerialized]
	private HashSet<Segment> _manuallyBlockedSnippets;

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
		set
		{
			throw null;
		}
	}

	public bool IsAutomaticBridgeSegment
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

	public float Intensity
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

	public bool IsUsableAtStart
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

	public bool IsUsableInMiddle
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

	public bool IsUsableAtEnd
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

	public AudioData AudioData
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

	public bool CalculatePostAndPrebeatLengthBasedOnBeats
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

	public int PreBeatLengthInSamples
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

	public int PostBeatLengthInSamples
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

	public float PreBeats
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

	public float PostBeats
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

	public float Bpm
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

	public int SampleRate
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

	public int TotalLengthInSamples
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int BitsPerSample
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

	public int ThemeId
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

	public List<int> Serialization_ManuallyBlockedSegmentIds
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

	public List<int> Serialization_ManuallyLinkedSegmentIds
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

	public CompatibilityType DefaultCompatibiltyAsFollower
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
	public Group Group
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
	public HashSet<Segment> ManuallyLinkedSnippets
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

	[XmlIgnore]
	public HashSet<Segment> ManuallyBlockedSnippets
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

	[XmlIgnore]
	public Dictionary<int, float> CompatibleSnippetsIds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<PsaiMusicEntity> GetChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetClassString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Segment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Segment(int id, string name, int snippetTypes, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Segment(int id, AudioData audioData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void init()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override object Clone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AddCompatibleSnippet(Segment snippet, float compatibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool PropertyDifferencesAffectCompatibilities(PsaiMusicEntity otherEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BuildCompatibleSegmentsSet(PsaiProject project)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStartMiddleEndPropertiesFromBitfield(int bitfield)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CreateSegmentSuitabilityBitfield(PsaiProject parentProject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public psai.net.Segment CreatePsaiDotNetVersion(PsaiProject parentProject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasOnlyStartSuitability()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasOnlyMiddleSuitability()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasOnlyEndSuitability()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ReadOutSegmentSuitabilityFlag(int bitfield, SegmentSuitability suitability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetSegmentSuitabilityFlag(ref int bitfield, SegmentSuitability snippetType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearSegmentSuitabilityFlag(ref int bitfield, SegmentSuitability snippetType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBridgeSnippetToAnyGroup(PsaiProject project)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsManualBridgeSnippetForAnyGroup(PsaiProject project)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsManualBridgeSegmentForSourceGroup(Group sourceGroup)
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
	public override PsaiMusicEntity GetParent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIndexPositionWithinParentEntity(PsaiProject parentProject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Segment GetExampleSnippet1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Segment GetExampleSnippet2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Segment GetExampleSnippet3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Segment GetExampleSnippet4()
	{
		throw null;
	}
}
