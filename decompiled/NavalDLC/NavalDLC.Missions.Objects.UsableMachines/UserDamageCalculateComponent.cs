using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects.UsableMachines;

public class UserDamageCalculateComponent : UsableMissionObjectComponent
{
	private PerkObject _perkObject;

	private bool _isPrimaryBonus;

	public float DamageReductionFactor
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UserDamageCalculateComponent(PerkObject perkObject, bool isPrimaryBonus, float damageReductionFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyPerkBonusForCharacter(PerkObject perkObject, bool isPrimaryBonus, CharacterObject agentCharacterObject, ref ExplainedNumber damageResult)
	{
		throw null;
	}
}
