using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;

namespace TaleWorlds.Localization;

public class VoiceObject
{
	private readonly MBList<string> _voicePaths;

	public MBReadOnlyList<string> VoicePaths
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private VoiceObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddVoicePath(string voicePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddVoicePaths(XmlNode node, string modulePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VoiceObject Deserialize(XmlNode node, string modulePath)
	{
		throw null;
	}
}
