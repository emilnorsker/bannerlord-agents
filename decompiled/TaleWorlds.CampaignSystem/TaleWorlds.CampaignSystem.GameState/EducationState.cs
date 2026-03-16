using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameState;

public class EducationState : TaleWorlds.Core.GameState
{
	private IEducationStateHandler _handler;

	public override bool IsMenuState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Hero Child
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

	public IEducationStateHandler Handler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EducationState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EducationState(Hero child)
	{
		throw null;
	}
}
