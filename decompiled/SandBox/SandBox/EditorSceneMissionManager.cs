using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox;

public class EditorSceneMissionManager : MBGameManager
{
	private string _missionName;

	private string _sceneName;

	private string _levels;

	private bool _forReplay;

	private string _replayFileName;

	private bool _isRecord;

	private float _startTime;

	private float _endTime;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EditorSceneMissionManager(string missionName, string sceneName, string levels, bool forReplay, string replayFileName, bool isRecord, float startTime, float endTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void DoLoadingForGameManager(GameManagerLoadingSteps gameManagerLoadingSteps, out GameManagerLoadingSteps nextStep)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterCampaignStart(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnLoadFinished()
	{
		throw null;
	}
}
