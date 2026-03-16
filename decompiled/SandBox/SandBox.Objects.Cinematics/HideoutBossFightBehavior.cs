using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.Objects.Cinematics;

public class HideoutBossFightBehavior : ScriptComponentBehavior
{
	private readonly struct HideoutBossFightPreviewEntityInfo
	{
		public readonly GameEntity BaseEntity;

		public readonly GameEntity InitialEntity;

		public readonly GameEntity TargetEntity;

		public static HideoutBossFightPreviewEntityInfo Invalid
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool IsValid
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public HideoutBossFightPreviewEntityInfo(GameEntity baseEntity, GameEntity initialEntity, GameEntity targetEntity)
		{
			throw null;
		}
	}

	private enum HideoutSeedPerturbOffset
	{
		Player,
		Boss,
		Ally,
		Bandit
	}

	[CompilerGenerated]
	private sealed class _003CComputeSpawnWorldFrames_003Ed__51 : IEnumerable<MatrixFrame>, IEnumerable, IEnumerator<MatrixFrame>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MatrixFrame _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private float localBaseAngle;

		public float _003C_003E3__localBaseAngle;

		private float localOffsetAngle;

		public float _003C_003E3__localOffsetAngle;

		public HideoutBossFightBehavior _003C_003E4__this;

		private float localPerturbAmount;

		public float _003C_003E3__localPerturbAmount;

		private float localRadius;

		public float _003C_003E3__localRadius;

		private Vec3 localOffset;

		public Vec3 _003C_003E3__localOffset;

		private int spawnCount;

		public int _003C_003E3__spawnCount;

		private float[] _003ClocalPlacementAngles_003E5__2;

		private int _003CangleIndex_003E5__3;

		private int _003Ci_003E5__4;

		MatrixFrame IEnumerator<MatrixFrame>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CComputeSpawnWorldFrames_003Ed__51(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<MatrixFrame> IEnumerable<MatrixFrame>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private const int PreviewPerturbSeed = 0;

	private const float PreviewPerturbAmount = 0.25f;

	private const int PreviewTroopCount = 10;

	private const float PreviewPlacementAngle = MathF.PI / 20f;

	private const string InitialFrameTag = "initial_frame";

	private const string TargetFrameTag = "target_frame";

	private const string BossPreviewPrefab = "hideout_boss_fight_preview_boss";

	private const string PlayerPreviewPrefab = "hideout_boss_fight_preview_player";

	private const string AllyPreviewPrefab = "hideout_boss_fight_preview_ally";

	private const string BanditPreviewPrefab = "hideout_boss_fight_preview_bandit";

	private const string PreviewCameraPrefab = "hideout_boss_fight_camera_preview";

	public const float MaxCameraHeight = 5f;

	public const float MaxCameraWidth = 10f;

	public float InnerRadius;

	public float OuterRadius;

	public float WalkDistance;

	public bool ShowPreview;

	private int _perturbSeed;

	private Random _perturbRng;

	private MatrixFrame _previousEntityFrame;

	private GameEntity _previewEntities;

	private List<HideoutBossFightPreviewEntityInfo> _previewAllies;

	private List<HideoutBossFightPreviewEntityInfo> _previewBandits;

	private HideoutBossFightPreviewEntityInfo _previewBoss;

	private HideoutBossFightPreviewEntityInfo _previewPlayer;

	private GameEntity _previewCamera;

	public int PerturbSeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPlayerFrames(out MatrixFrame initialFrame, out MatrixFrame targetFrame, float perturbAmount = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBossFrames(out MatrixFrame initialFrame, out MatrixFrame targetFrame, float perturbAmount = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllyFrames(out List<MatrixFrame> initialFrames, out List<MatrixFrame> targetFrames, int agentCount = 10, float agentOffsetAngle = MathF.PI / 20f, float perturbAmount = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBanditFrames(out List<MatrixFrame> initialFrames, out List<MatrixFrame> targetFrames, int agentCount = 10, float agentOffsetAngle = MathF.PI / 20f, float perturbAmount = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAlliesInitialFrame(out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBanditsInitialFrame(out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsWorldPointInsideCameraVolume(in Vec3 worldPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ClampWorldPointToCameraVolume(in Vec3 worldPoint, out Vec3 clampedPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePreview()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GeneratePreview()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemovePreview()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TogglePreviewVisibility(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReadPrefabEntity(GameEntity entity, out GameEntity initialEntity, out GameEntity targetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindRadialPlacementFrame(float angle, float radius, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SnapOnClosestCollider(ref MatrixFrame frameWs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReSeedPerturbRng(int seedOffset = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeSpawnWorldFrame(float localAngle, float localRadius, in Vec3 localOffset, out MatrixFrame worldFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CComputeSpawnWorldFrames_003Ed__51))]
	private IEnumerable<MatrixFrame> ComputeSpawnWorldFrames(int spawnCount, float localRadius, Vec3 localOffset, float localBaseAngle, float localOffsetAngle, float localPerturbAmount = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputePerturbedSpawnOffset(float perturbAmount, out Vec3 perturbVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsLocalPointInsideCameraVolume(in Vec3 localPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HideoutBossFightBehavior()
	{
		throw null;
	}
}
