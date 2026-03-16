using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;

namespace TaleWorlds.Core;

public class TutorialContextChangedEvent : EventBase
{
	public TutorialContexts NewContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TutorialContextChangedEvent(TutorialContexts newContext)
	{
		throw null;
	}
}
