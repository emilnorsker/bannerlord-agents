using System;
using System.Runtime.CompilerServices;

namespace SandBox.View.Conversation;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class ConversationViewEventHandler : Attribute
{
	public enum EventType
	{
		OnCondition,
		OnConsequence
	}

	public string Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public EventType Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationViewEventHandler(string id, EventType type)
	{
		throw null;
	}
}
