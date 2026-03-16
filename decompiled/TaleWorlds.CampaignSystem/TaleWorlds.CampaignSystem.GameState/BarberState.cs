using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameState;

public class BarberState : TaleWorlds.Core.GameState
{
	public BasicCharacterObject Character;

	public override bool IsMenuState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IFaceGeneratorCustomFilter Filter
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
	public BarberState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BarberState(BasicCharacterObject character, IFaceGeneratorCustomFilter filter)
	{
		throw null;
	}
}
