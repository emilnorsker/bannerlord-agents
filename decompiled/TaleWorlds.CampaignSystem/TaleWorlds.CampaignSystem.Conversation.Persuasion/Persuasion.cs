using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Conversation.Persuasion;

public class Persuasion
{
	public readonly float SuccessValue;

	public readonly float FailValue;

	public readonly float CriticalSuccessValue;

	public readonly float CriticalFailValue;

	private readonly float _difficultyMultiplier;

	private readonly PersuasionDifficulty _difficulty;

	private readonly List<Tuple<PersuasionOptionArgs, PersuasionOptionResult>> _chosenOptions;

	public readonly float GoalValue;

	public float DifficultyMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Progress
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
	public Persuasion(float goalValue, float successValue, float failValue, float criticalSuccessValue, float criticalFailValue, float initialProgress, PersuasionDifficulty difficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CommitProgress(PersuasionOptionArgs persuasionOptionArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionResult CheckPerkEffectOnResult(PersuasionOptionResult result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPersuasionOptionResultValue(PersuasionOptionResult result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PersuasionOptionResult GetResult(PersuasionOptionArgs optionArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<Tuple<PersuasionOptionArgs, PersuasionOptionResult>> GetChosenOptions()
	{
		throw null;
	}
}
