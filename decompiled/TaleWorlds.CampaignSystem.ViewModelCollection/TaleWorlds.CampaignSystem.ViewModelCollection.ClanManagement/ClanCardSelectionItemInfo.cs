using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;

public readonly struct ClanCardSelectionItemInfo
{
	public readonly object Identifier;

	public readonly TextObject Title;

	public readonly ImageIdentifier Image;

	public readonly CardSelectionItemSpriteType SpriteType;

	public readonly string SpriteName;

	public readonly string SpriteLabel;

	public readonly IEnumerable<ClanCardSelectionItemPropertyInfo> Properties;

	public readonly bool IsSpecialActionItem;

	public readonly TextObject SpecialActionText;

	public readonly bool IsDisabled;

	public readonly TextObject DisabledReason;

	public readonly TextObject ActionResult;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanCardSelectionItemInfo(object identifier, TextObject title, ImageIdentifier image, CardSelectionItemSpriteType spriteType, string spriteName, string spriteLabel, IEnumerable<ClanCardSelectionItemPropertyInfo> properties, bool isDisabled, TextObject disabledReason, TextObject actionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanCardSelectionItemInfo(TextObject specialActionText, bool isDisabled, TextObject disabledReason, TextObject actionResult)
	{
		throw null;
	}
}
