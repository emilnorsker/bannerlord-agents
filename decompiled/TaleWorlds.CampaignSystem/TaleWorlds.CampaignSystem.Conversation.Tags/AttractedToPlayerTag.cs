using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Tags;

public class AttractedToPlayerTag : ConversationTag
{
	public const string Id = "AttractedToPlayerTag";

	private const int MinimumFlirtPercentageForComment = 70;

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
	public AttractedToPlayerTag()
	{
		throw null;
	}
}
