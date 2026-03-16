using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem;

public struct ExplainedNumber
{
	private class StatExplainer
	{
		public enum OperationType
		{
			Base,
			Add,
			Multiply,
			LimitMin,
			LimitMax
		}

		public readonly struct ExplanationLine
		{
			public readonly float Number;

			public readonly string Name;

			public readonly OperationType OperationType;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public ExplanationLine(string name, float number, OperationType operationType)
			{
				throw null;
			}
		}

		public List<ExplanationLine> Lines
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

		public ExplanationLine? BaseLine
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

		public ExplanationLine? LimitMinLine
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

		public ExplanationLine? LimitMaxLine
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
		public List<(string name, float number)> GetLines(float baseNumber, float unclampedResultNumber, TextObject overrideBaseLineText = null, TextObject overrideMaximumLineText = null, TextObject overrideMinimumLineText = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddLine(string name, float number, OperationType opType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StatExplainer()
		{
			throw null;
		}
	}

	private static readonly TextObject LimitMinText;

	private static readonly TextObject LimitMaxText;

	private static readonly TextObject BaseText;

	private float? _limitMinValue;

	private float? _limitMaxValue;

	private StatExplainer _explainer;

	public float ResultNumber
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int RoundedResultNumber
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float BaseNumber
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

	public bool IncludeDescriptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LimitMinValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LimitMaxValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float SumOfFactors
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

	private float _unclampedResultNumber
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ExplainedNumber(float baseNumber = 0f, bool includeDescriptions = false, TextObject baseText = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetExplanations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<(string name, float number)> GetLines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFromExplainedNumber(ExplainedNumber explainedNumber, TextObject baseText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SubtractFromExplainedNumber(ExplainedNumber explainedNumber, TextObject baseText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(float value, TextObject description = null, TextObject variable = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFactor(float value, TextObject description = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LimitMin(float minValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LimitMax(float maxValue, TextObject description = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clamp(float minValue, float maxValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ExplainedNumber()
	{
		throw null;
	}
}
