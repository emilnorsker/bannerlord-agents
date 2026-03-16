using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public static class SkinVoiceManager
{
	public enum CombatVoiceNetworkPredictionType
	{
		Prediction,
		OwnerPrediction,
		NoPrediction
	}

	public struct SkinVoiceType
	{
		public string TypeID
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

		public int Index
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
		public SkinVoiceType(string typeID)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TextObject GetName()
		{
			throw null;
		}
	}

	public static class VoiceType
	{
		public static readonly SkinVoiceType Grunt;

		public static readonly SkinVoiceType Jump;

		public static readonly SkinVoiceType Yell;

		public static readonly SkinVoiceType Pain;

		public static readonly SkinVoiceType Death;

		public static readonly SkinVoiceType Stun;

		public static readonly SkinVoiceType Fear;

		public static readonly SkinVoiceType Climb;

		public static readonly SkinVoiceType Focus;

		public static readonly SkinVoiceType Debacle;

		public static readonly SkinVoiceType Victory;

		public static readonly SkinVoiceType HorseStop;

		public static readonly SkinVoiceType HorseRally;

		public static readonly SkinVoiceType Drown;

		public static readonly SkinVoiceType Infantry;

		public static readonly SkinVoiceType Cavalry;

		public static readonly SkinVoiceType Archers;

		public static readonly SkinVoiceType HorseArchers;

		public static readonly SkinVoiceType Everyone;

		public static readonly SkinVoiceType MixedFormation;

		public static readonly SkinVoiceType Move;

		public static readonly SkinVoiceType Follow;

		public static readonly SkinVoiceType Charge;

		public static readonly SkinVoiceType Advance;

		public static readonly SkinVoiceType FallBack;

		public static readonly SkinVoiceType Stop;

		public static readonly SkinVoiceType Retreat;

		public static readonly SkinVoiceType Mount;

		public static readonly SkinVoiceType Dismount;

		public static readonly SkinVoiceType FireAtWill;

		public static readonly SkinVoiceType HoldFire;

		public static readonly SkinVoiceType PickSpears;

		public static readonly SkinVoiceType PickDefault;

		public static readonly SkinVoiceType FaceEnemy;

		public static readonly SkinVoiceType FaceDirection;

		public static readonly SkinVoiceType UseSiegeWeapon;

		public static readonly SkinVoiceType UseLadders;

		public static readonly SkinVoiceType AttackGate;

		public static readonly SkinVoiceType CommandDelegate;

		public static readonly SkinVoiceType CommandUndelegate;

		public static readonly SkinVoiceType BoardAtWill;

		public static readonly SkinVoiceType AvoidBoarding;

		public static readonly SkinVoiceType FormLine;

		public static readonly SkinVoiceType FormShieldWall;

		public static readonly SkinVoiceType FormLoose;

		public static readonly SkinVoiceType FormCircle;

		public static readonly SkinVoiceType FormSquare;

		public static readonly SkinVoiceType FormSkein;

		public static readonly SkinVoiceType FormColumn;

		public static readonly SkinVoiceType FormScatter;

		public static readonly SkinVoiceType[] MpBarks;

		public static readonly SkinVoiceType MpDefend;

		public static readonly SkinVoiceType MpAttack;

		public static readonly SkinVoiceType MpHelp;

		public static readonly SkinVoiceType MpSpot;

		public static readonly SkinVoiceType MpThanks;

		public static readonly SkinVoiceType MpSorry;

		public static readonly SkinVoiceType MpAffirmative;

		public static readonly SkinVoiceType MpNegative;

		public static readonly SkinVoiceType MpRegroup;

		public static readonly SkinVoiceType Idle;

		public static readonly SkinVoiceType Neigh;

		public static readonly SkinVoiceType Collide;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static VoiceType()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetVoiceDefinitionCountWithMonsterSoundAndCollisionInfoClassName(string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetVoiceDefinitionListWithMonsterSoundAndCollisionInfoClassName(string className, int[] definitionIndices)
	{
		throw null;
	}
}
