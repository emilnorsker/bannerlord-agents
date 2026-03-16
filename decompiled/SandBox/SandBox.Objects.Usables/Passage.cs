using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.Usables;

public class Passage : UsableMachine
{
	public Location ToLocation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Passage()
	{
		throw null;
	}
}
