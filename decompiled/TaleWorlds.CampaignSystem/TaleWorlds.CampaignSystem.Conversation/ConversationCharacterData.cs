using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.Conversation;

public struct ConversationCharacterData : ISerializableObject
{
	public CharacterObject Character;

	public PartyBase Party;

	public bool NoHorse;

	public bool NoWeapon;

	public bool NoBodyguards;

	public bool SpawnedAfterFight;

	public bool IsCivilianEquipmentRequiredForLeader;

	public bool IsCivilianEquipmentRequiredForBodyGuardCharacters;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationCharacterData(CharacterObject character, PartyBase party = null, bool noHorse = false, bool noWeapon = false, bool spawnAfterFight = false, bool isCivilianEquipmentRequiredForLeader = false, bool isCivilianEquipmentRequiredForBodyGuardCharacters = false, bool noBodyguards = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ISerializableObject.DeserializeFrom(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ISerializableObject.SerializeTo(IWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PartyBase FindParty(int index)
	{
		throw null;
	}
}
