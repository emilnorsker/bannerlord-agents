using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine.Options;

public class NativeNumericOptionData : NativeOptionData, INumericOptionData, IOptionData
{
	private readonly float _minValue;

	private readonly float _maxValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeNumericOptionData(NativeOptions.NativeOptionsType type)
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
	private static float GetLimitValue(NativeOptions.NativeOptionsType type, bool isMin)
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
