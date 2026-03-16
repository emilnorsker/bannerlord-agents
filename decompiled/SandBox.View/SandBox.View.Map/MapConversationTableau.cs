using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.View.Map;

public class MapConversationTableau
{
	private struct DefaultConversationAnimationData
	{
		public static readonly DefaultConversationAnimationData Invalid;

		public ConversationAnimData AnimationData;

		public string ActionName;

		public bool AnimationDataValid;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static DefaultConversationAnimationData()
		{
			throw null;
		}
	}

	private static int _tableauIndex;

	private const float MinimumTimeRequiredToChangeIdleAction = 8f;

	private Scene _tableauScene;

	private float _animationFrequencyThreshold;

	private MatrixFrame _frame;

	private GameEntity _cameraEntity;

	private SoundEvent _conversationSoundEvent;

	private Camera _continuousRenderCamera;

	private MapConversationTableauData _data;

	private float _cameraRatio;

	private IMapConversationDataProvider _dataProvider;

	private bool _initialized;

	private Timer _changeIdleActionTimer;

	private int _tableauSizeX;

	private int _tableauSizeY;

	private uint _clothColor1;

	private uint _clothColor2;

	private List<AgentVisuals> _agentVisuals;

	private static readonly string fallbackAnimActName;

	private readonly string RainingEntityTag;

	private readonly string SnowingEntityTag;

	private float _animationGap;

	private bool _isEnabled;

	private float RenderScale;

	private const float _baseCameraRatio = 1.7777778f;

	private float _baseCameraFOV;

	private string _cachedAtmosphereName;

	private string _opponentLeaderEquipmentCache;

	public Texture Texture
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

	private TableauView View
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapConversationTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnabled(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetData(object data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize(bool clearNextFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FirstTimeInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnOpponentLeader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnOpponentBodyguardCharacter(CharacterObject character, int indexOfBodyguard, PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CharacterTableauContinuousRenderFunction(Texture sender, EventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DefaultConversationAnimationData GetDefaultAnimForCharacter(CharacterObject character, bool preferLoopAnimationIfAvailable, PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnConversationPlay(string idleActionId, string idleFaceAnimId, string reactionId, string reactionFaceAnimId, string soundPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemovePreviousAgentsSoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayConversationSoundEvent(string soundPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopConversationSoundEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetRhubarbXmlPathFromSoundPath(string soundPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MapConversationTableau()
	{
		throw null;
	}
}
