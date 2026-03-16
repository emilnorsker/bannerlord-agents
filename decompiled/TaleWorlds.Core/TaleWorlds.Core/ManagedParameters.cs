using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.Core;

public sealed class ManagedParameters : IManagedParametersInitializer
{
	private readonly float[] _managedParametersArray;

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
	public static float GetParameter(ManagedParametersEnum managedParameterType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetParameter(ManagedParametersEnum managedParameterType, float newValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(string relativeXmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ManagedParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static XmlDocument LoadXmlFile(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadFromXml(XmlNode doc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetManagedParameter(ManagedParametersEnum managedParameterEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ManagedParameters()
	{
		throw null;
	}
}
