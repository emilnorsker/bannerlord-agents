using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.CharacterCreationContent;

public abstract class CharacterCreationStageBase
{
	public ICharacterCreationStageListener Listener
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected CharacterCreationStageBase()
	{
		throw null;
	}
}
