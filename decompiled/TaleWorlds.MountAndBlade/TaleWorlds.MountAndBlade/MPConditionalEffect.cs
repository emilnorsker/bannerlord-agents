using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MPConditionalEffect
{
	public class ConditionalEffectContainer : List<MPConditionalEffect>
	{
		private class ConditionState
		{
			public bool IsSatisfied
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
			public ConditionState()
			{
				throw null;
			}
		}

		private Dictionary<MPConditionalEffect, ConditionalWeakTable<Agent, ConditionState>> _states;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConditionalEffectContainer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConditionalEffectContainer(IEnumerable<MPConditionalEffect> conditionalEffects)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool GetState(MPConditionalEffect conditionalEffect, Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetState(MPConditionalEffect conditionalEffect, Agent agent, bool state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ResetStates()
		{
			throw null;
		}
	}

	public MBReadOnlyList<MPPerkCondition> Conditions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MPPerkEffectBase> Effects
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public MPPerkCondition.PerkEventFlags EventFlags
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsTickRequired
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPConditionalEffect(List<string> gameModes, XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Check(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Check(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEvent(bool isWarmup, MissionPeer peer, ConditionalEffectContainer container)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEvent(bool isWarmup, Agent agent, ConditionalEffectContainer container)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(bool isWarmup, MissionPeer peer, int tickCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAgentState(bool isWarmup, ConditionalEffectContainer container, Agent agent, bool state)
	{
		throw null;
	}
}
