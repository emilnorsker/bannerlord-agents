using System.Runtime.CompilerServices;
using TaleWorlds.Engine.Options;

namespace TaleWorlds.MountAndBlade.Options.ManagedOptions;

public class ManagedNumericOptionData : ManagedOptionData, INumericOptionData, IOptionData
{
	private readonly float _minValue;

	private readonly float _maxValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedNumericOptionData(TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMinValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMaxValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetLimitValue(TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType type, bool isMin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsDiscrete()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDiscreteIncrementInterval()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetShouldUpdateContinuously()
	{
		throw null;
	}
}
