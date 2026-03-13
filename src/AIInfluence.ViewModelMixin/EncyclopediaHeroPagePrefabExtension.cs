using System.Xml;
using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;

namespace AIInfluence.ViewModelMixin;

[PrefabExtension("EncyclopediaHeroPage", "descendant::RichTextWidget[@Text='@InformationText']")]
internal sealed class EncyclopediaHeroPagePrefabExtension : PrefabExtensionInsertPatch
{
	private readonly XmlDocument _document;

	public override InsertType Type => (InsertType)4;

	public EncyclopediaHeroPagePrefabExtension()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		_document = new XmlDocument();
		_document.LoadXml("<EncyclopediaHeroPageInject />");
	}

	[PrefabExtensionXmlDocument(false)]
	public XmlDocument GetPrefabExtension()
	{
		return _document;
	}
}
