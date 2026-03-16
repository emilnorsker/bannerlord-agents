using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Screens;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

public class FormationIndicatorMissionView : MissionView
{
	public class Indicator
	{
		public MissionScreen missionScreen;

		public bool indicatorVisible;

		public MatrixFrame indicatorFrame;

		public bool firstTime;

		public GameEntity indicatorEntity;

		public Vec3 nextIndicatorPosition;

		public Vec3 prevIndicatorPosition;

		public float indicatorAlpha;

		private float _drawIndicatorElapsedTime;

		private const float IndicatorExpireTime = 0.5f;

		private bool _isSeenByPlayer;

		internal bool _isMovingTooFast;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Vec3? GetCurrentPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void DetermineIndicatorState(float dt, Vec3 position)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Indicator()
		{
			throw null;
		}
	}

	private Indicator[,] _indicators;

	private Mission mission;

	private bool _isEnabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity CreateBannerEntity(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetFormationTeamIndex(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationIndicatorMissionView()
	{
		throw null;
	}
}
