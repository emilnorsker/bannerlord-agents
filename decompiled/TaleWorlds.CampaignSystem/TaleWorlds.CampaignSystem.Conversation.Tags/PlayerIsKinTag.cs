using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Tags;

public class PlayerIsKinTag : ConversationTag
{
	public const string Id = "PlayerIsKinTag";

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
	public PlayerIsKinTag()
	{
		throw null;
	}
}
