using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace psai.Editor;

[Serializable]
public class Group : PsaiMusicEntity, ICloneable
{
	[NonSerialized]
	private List<Segment> m_segments;

	[NonSerialized]
	private HashSet<Segment> _manualBridgeSnippetsOfTargetGroups;

	[NonSerialized]
	private HashSet<Group> _manuallyBlockedGroups;

	[NonSerialized]
	private HashSet<Group> _manuallyLinkedGroups;

	private string _description;

	public List<Segment> Segments
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

	public int Serialization_Id
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

	public List<int> Serialization_ManuallyBlockedGroupIds
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

	public List<int> Serialization_ManuallyLinkedGroupIds
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

	public List<int> Serialization_ManualBridgeSegmentIds
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
	public HashSet<Segment> ManualBridgeSnippetsOfTargetGroups
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
	public HashSet<Group> ManuallyBlockedGroups
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
	public HashSet<Group> ManuallyLinkedGroups
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
	public Theme Theme
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetClassString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Group()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Group(Theme parentTheme, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Group(Theme parentTheme)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~Group()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSegment(Segment snippet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSegment(Segment snippet, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSnippet_internal(Segment snippet, int insertIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveSegment(Segment snippet)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAtLeastOneBridgeSegmentToTargetGroup(Group targetGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsAtLeastOneManualBridgeSegmentForSourceGroup(Group sourceGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsAtLeastOneAutomaticBridgeSegment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
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
	public void SetAsParentGroupForAllSegments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PsaiMusicEntity GetParent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<PsaiMusicEntity> GetChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetIndexPositionWithinParentEntity(PsaiProject parentProject)
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
}
