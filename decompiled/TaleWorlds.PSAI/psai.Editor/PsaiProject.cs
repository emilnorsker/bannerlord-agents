using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using psai.net;

namespace psai.Editor;

public class PsaiProject : ICloneable
{
	public static readonly string SERIALIZATION_PROTOCOL_VERSION;

	private ProjectProperties _projectProperties;

	private List<Theme> _themes;

	private static XmlSerializer _serializer;

	public string InitialExportDirectory
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

	public string SerializedByProtocolVersion
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

	public ProjectProperties Properties
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

	public List<Theme> Themes
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
	public void Init()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PsaiProject LoadProjectFromStream(StreamReader reader, string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PsaiProject LoadProjectFromXmlFile(string filename)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveAsXmlFile(string filename)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Report(bool reportGroups, bool reportSegments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ConvertProjectFile_From_Legacy_To_0_9_12(string pathToProjectFile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReconstructReferencesAfterXmlDeserialization()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MergeProjects(PsaiProject project)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReconstructIds(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DebugCheckProjectIntegrity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Soundtrack BuildPsaiDotNetSoundtrackFromProject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareForXmlSerialization()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HashSet<Segment> GetSegmentsOfAllThemes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme GetThemeById(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Segment GetSnippetById(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Group GetGroupBySerializationId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPsaiMusicEntity(PsaiMusicEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPsaiMusicEntity(PsaiMusicEntity entity, int targetIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteMusicEntity(PsaiMusicEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHighestSegmentId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNextFreeSnippetId(int idToStartSearchFrom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HashSet<Group> GetGroupsOfAllThemes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfSnippetIsManualBridgeSnippetForSourceGroup(Segment snippet, Group sourceGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfThereIsAtLeastOneBridgeSnippetFromSourceGroupToTargetGroup(Group sourceGroup, Group targetGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfSnippetIsManualBridgeSnippetToAnyGroup(Segment snippet, bool getGroups, out List<Group> groups)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoUpdateAllParentThemeIdsAndGroupsOfChildPsaiEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNextFreeThemeId(int idToStartSearchFrom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfThemeIdIsInUse(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Segment> GetSnippetsById(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Clone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiProject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PsaiProject()
	{
		throw null;
	}
}
