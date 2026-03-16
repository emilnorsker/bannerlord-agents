using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem;

public sealed class ManagedParameters : IManagedParametersInitializer
{
	private readonly bool[] _managedParametersArray;

	public static ManagedParameters Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(string relativeXmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadFromXml(XmlNode doc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetManagedParameter(ManagedParametersEnum _managedParametersEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetManagedParameter(ManagedParametersEnum _managedParametersEnum, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ManagedParameters()
	{
		throw null;
	}
}
