using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

[DefaultView]
public class MissionSoundParametersView : MissionView
{
	public enum SoundParameterMissionCulture : short
	{
		None,
		Aserai,
		Battania,
		Empire,
		Khuzait,
		Sturgia,
		Vlandia,
		Nord,
		ReservedA,
		ReservedB,
		Bandit
	}

	private enum SoundParameterMissionProsperityLevel : short
	{
		None = 0,
		Low = 0,
		Mid = 1,
		High = 2
	}

	private const string CultureParameterId = "MissionCulture";

	private const string ProsperityParameterId = "MissionProsperity";

	private const string CombatParameterId = "MissionCombatMode";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeGlobalParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCultureParameter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeProsperityParameter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCombatModeParameter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionSoundParametersView()
	{
		throw null;
	}
}
