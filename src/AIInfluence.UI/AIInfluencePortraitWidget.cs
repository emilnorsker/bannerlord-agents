using System;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;

namespace AIInfluence.UI;

public class AIInfluencePortraitWidget : ImageIdentifierWidget
{
	public static string PendingCharacterCode { get; set; }

	public AIInfluencePortraitWidget(UIContext context)
		: base(context)
	{
		((ImageIdentifierWidget)this).HideWhenNull = true;
	}

	protected override void OnContextActivated()
	{
		try
		{
			base.OnContextActivated();
		}
		catch (Exception)
		{
			((Widget)this).IsVisible = false;
			PendingCharacterCode = null;
			return;
		}
		string pendingCharacterCode = PendingCharacterCode;
		PendingCharacterCode = null;
		if (string.IsNullOrEmpty(pendingCharacterCode))
		{
			return;
		}
		try
		{
			((TextureWidget)this).TextureProviderName = "CharacterImageTextureProvider";
			((ImageIdentifierWidget)this).AdditionalArgs = "customSizeX=1024;customSizeY=1024";
			((ImageIdentifierWidget)this).ImageId = pendingCharacterCode;
		}
		catch (Exception)
		{
			((Widget)this).IsVisible = false;
		}
	}
}
