using System;
using System.Text;

namespace AIInfluence.NpcInteraction;

public interface INpcDialogueTool
{
	string Name { get; }
	void Apply(NpcToolCall toolCall, StringBuilder npcReply, Action<string> onPartialResponse);
}
