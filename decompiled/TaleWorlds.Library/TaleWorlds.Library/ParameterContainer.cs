using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class ParameterContainer
{
	private Dictionary<string, string> _parameters;

	public IEnumerable<KeyValuePair<string, string>> Iterator
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParameterContainer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParameter(string key, string value, bool overwriteIfExists)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParameterConcurrent(string key, string value, bool overwriteIfExists)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParametersConcurrent(IEnumerable<KeyValuePair<string, string>> parameters, bool overwriteIfExists)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameter(string key, out string outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsBool(string key, out bool outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsInt(string key, out int outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsUInt16(string key, out ushort outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsFloat(string key, out float outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsByte(string key, out byte outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsSByte(string key, out sbyte outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsVec3(string key, out Vec3 outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetParameterAsVec2(string key, out Vec2 outValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetParameter(string key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParameterContainer Clone()
	{
		throw null;
	}
}
