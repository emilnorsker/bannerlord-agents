using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Conversation;

public class ConversationAnimData
{
	[SaveableField(0)]
	public string IdleAnimStart;

	[SaveableField(1)]
	public string IdleAnimLoop;

	[SaveableField(2)]
	public int FamilyType;

	[SaveableField(3)]
	public int MountFamilyType;

	[SaveableField(4)]
	public Dictionary<string, string> Reactions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationAnimData()
	{
		throw null;
	}
}
