using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public class SceneNotificationData
{
	public readonly struct SceneNotificationCharacter
	{
		public readonly BasicCharacterObject Character;

		public readonly Equipment OverriddenEquipment;

		public readonly BodyProperties OverriddenBodyProperties;

		public readonly bool UseCivilianEquipment;

		public readonly bool UseHorse;

		public readonly uint CustomColor1;

		public readonly uint CustomColor2;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SceneNotificationCharacter(BasicCharacterObject character, Equipment overriddenEquipment = null, BodyProperties overriddenBodyProperties = default(BodyProperties), bool useCivilianEquipment = false, uint customColor1 = uint.MaxValue, uint customColor2 = uint.MaxValue, bool useHorse = false)
		{
			throw null;
		}
	}

	public readonly struct SceneNotificationShip
	{
		public readonly string ShipPrefabId;

		public readonly List<ShipVisualSlotInfo> ShipUpgrades;

		public readonly float ShipHitPointRatio;

		public readonly uint SailColor1;

		public readonly uint SailColor2;

		public readonly int ShipSeed;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SceneNotificationShip(string shipPrefabId, List<ShipVisualSlotInfo> shipUpgrades, float shipHitPointRatio, uint sailColor1, uint sailColor2, int shipSeed)
		{
			throw null;
		}
	}

	public struct NotificationSceneProperties
	{
		public bool InitializePhysics;

		public bool DisableStaticShadows;

		public float? OverriddenWaterStrength;
	}

	public enum RelevantContextType
	{
		Any,
		MPLobby,
		CustomBattle,
		Mission,
		Map
	}

	public virtual string SceneID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual string SoundEventPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject TitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject AffirmativeDescriptionText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject NegativeDescriptionText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject AffirmativeHintText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject AffirmativeHintTextExtended
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject AffirmativeTitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject NegativeTitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject AffirmativeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual TextObject NegativeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual bool IsAffirmativeOptionShown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual bool IsNegativeOptionShown
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual bool PauseActiveState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual RelevantContextType RelevantContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public virtual NotificationSceneProperties SceneProperties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnAffirmativeAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnNegativeAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnCloseAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual Banner[] GetBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual SceneNotificationCharacter[] GetSceneNotificationCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual SceneNotificationShip[] GetShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SceneNotificationData()
	{
		throw null;
	}
}
