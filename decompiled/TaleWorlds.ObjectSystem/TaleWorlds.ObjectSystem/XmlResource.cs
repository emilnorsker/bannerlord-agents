using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace TaleWorlds.ObjectSystem;

public static class XmlResource
{
	public struct XsdElement
	{
		public string XPath;

		public bool AlwaysPreferMerge;

		public List<string> UniqueAttributes;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public XsdElement(string xPath, bool alwaysPreferMerge)
		{
			throw null;
		}
	}

	public static List<MbObjectXmlInformation> XmlInformationList;

	public static List<MbObjectXmlInformation> MbprojXmls;

	public static Dictionary<string, Dictionary<string, XsdElement>> XsdElementDictionary;

	public static XNamespace XsNamespace;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReadXsdFileAndExtractInformation(string xsdFilePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool GetAlwaysPreferMerge(XElement element)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFullXPathOfElement(XElement element, bool isXsd = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeXmlInformationList(List<MbObjectXmlInformation> xmlInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetMbprojxmls(string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetXmlListAndApply(string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static XmlResource()
	{
		throw null;
	}
}
