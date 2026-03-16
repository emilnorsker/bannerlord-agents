using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Engine;
using TaleWorlds.Library;

internal class BurningSystem
{
	private class AdvancedSpreadNode
	{
		internal BurningNode Node;

		internal BurningNode NextNode;

		internal BurningNode PrevNode;

		internal float[] CurrentFlame;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdvancedSpreadNode()
		{
			throw null;
		}
	}

	private GameEntity _fireRoot;

	private MBList<BurningNode> _burningNodes;

	private int _lastBurningIndex;

	private int _currentAdvancedSpreadFlameIndex;

	private Dictionary<BurningNode, AdvancedSpreadNode> _advancedNodes;

	private float _averageFireProgress;

	public bool AdvancedSpread
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

	public float AverageFireProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float SpreadRate
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

	public RopeSegment BurnedRope
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

	public PulleySystem BurnedPulley
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

	public MBReadOnlyList<BurningNode> BurningNodes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BurningSystem(GameEntity fireRoot, float spreadRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BurningSystem(GameEntity fireRoot, float spreadRate, PulleySystem pulley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BurningSystem(GameEntity fireRoot, float spreadRate, RopeSegment rope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoAdvancedSpread(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoSimpleSpread(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpreadRate(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNewNode(BurningNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAdvancedNode(BurningNode node, BurningNode prevNode, BurningNode nextNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFlameProgressOfAdvancedNode(BurningNode node, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFlameProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FireStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FlamesReachedEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Remove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBurningAnimationDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExternalFlameMultiplier(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckWater()
	{
		throw null;
	}
}
