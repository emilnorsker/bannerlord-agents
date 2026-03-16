using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Tags;

public class WaryTag : ConversationTag
{
	public const string Id = "WaryTag";

	public override string StringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsApplicableTo(CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WaryTag()
	{
		throw null;
	}
}
