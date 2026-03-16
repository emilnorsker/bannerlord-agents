using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Tags;

public abstract class ConversationTag
{
	public abstract string StringId { get; }

	public abstract bool IsApplicableTo(CharacterObject character);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ConversationTag()
	{
		throw null;
	}
}
