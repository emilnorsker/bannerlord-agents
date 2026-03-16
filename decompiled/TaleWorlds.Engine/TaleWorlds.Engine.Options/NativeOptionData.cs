using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine.Options;

public abstract class NativeOptionData : IOptionData
{
	public readonly NativeOptions.NativeOptionsType Type;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected NativeOptionData(NativeOptions.NativeOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetDefaultValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Commit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetValue(bool forceRefresh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetValue(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetOptionType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (string, bool) GetIsDisabledAndReasonID()
	{
		throw null;
	}
}
