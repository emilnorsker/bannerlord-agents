using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Tags;

public class NonviolentProfessionTag : ConversationTag
{
	public const string Id = "NonviolentProfessionTag";

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
	public NonviolentProfessionTag()
	{
		throw null;
	}
}
