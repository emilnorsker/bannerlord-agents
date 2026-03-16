using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

[AttributeUsage(AttributeTargets.Field)]
public class MultiplayerOptionsProperty : Attribute
{
	public enum ReplicationOccurrence
	{
		Never,
		AtMapLoad,
		Immediately
	}

	public readonly MultiplayerOptions.OptionValueType OptionValueType;

	public readonly ReplicationOccurrence Replication;

	public readonly string Description;

	public readonly int BoundsMin;

	public readonly int BoundsMax;

	public readonly string[] ValidGameModes;

	public readonly bool HasMultipleSelections;

	public readonly Type EnumType;

	public bool HasBounds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerOptionsProperty(MultiplayerOptions.OptionValueType optionValueType, ReplicationOccurrence replicationOccurrence, string description = null, int boundsMin = 0, int boundsMax = 0, string[] validGameModes = null, bool hasMultipleSelections = false, Type enumType = null)
	{
		throw null;
	}
}
