using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Tags;

public class LowRegisterTag : ConversationTag
{
	public const string Id = "LowRegisterTag";

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
	public LowRegisterTag()
	{
		throw null;
	}
}
