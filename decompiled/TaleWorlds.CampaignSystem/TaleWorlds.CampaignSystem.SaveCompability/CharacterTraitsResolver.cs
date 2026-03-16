using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem.Definition;
using TaleWorlds.SaveSystem.Resolvers;

namespace TaleWorlds.CampaignSystem.SaveCompability;

public class CharacterTraitsResolver : IConflictResolver
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsApplicable(ApplicationVersion version)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MemberTypeId GetFieldMemberWithId(MemberTypeId memberTypeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Type GetNewType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MemberTypeId GetPropertyMemberWithId(MemberTypeId memberTypeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterTraitsResolver()
	{
		throw null;
	}
}
