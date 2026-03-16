using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization.Expressions;

namespace TaleWorlds.Localization.TextProcessor;

internal class MBTextParser
{
	[ThreadStatic]
	private static MBTextParser _instance;

	private Stack<TextExpression> _symbolSequence;

	private TextExpression _lookaheadFirst;

	private TextExpression _lookaheadSecond;

	private TextExpression _lookaheadThird;

	private MBTextModel _queryModel;

	internal TextExpression LookAheadFirst
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal TextExpression LookAheadSecond
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal TextExpression LookAheadThird
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextExpression GetSimpleToken(TokenType tokenType, string strValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadSequenceStack(List<MBTextToken> tokens)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PushToken(TextExpression token)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateLookAheads()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DiscardToken()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DiscardToken(TokenType tokenType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Statements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRootExpression(TokenType tokenType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetRootExpressionsImp(List<TextExpression> expList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextExpression GetRootExpressions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RunRootGrammarRulesExceptCollapse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CollapseStatements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckSimpleStatement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckFieldStatement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckConditionalStatement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckSelectionStatement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoExpressionRules()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeFunction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeMarkerOccuranceExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeArrayAccessExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeNegativeAritmeticExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeParenthesisExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsArithmeticExpression(TokenType t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeInnerAritmeticExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeOuterAritmeticExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ArithmeticOperation ConsumeAritmeticOperation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ConsumeComparisonExpression()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsComparisonOperator(TokenType tokenType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BooleanOperation GetBooleanOp(TokenType tokenType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ComparisonOperation GetComparisonOp(TokenType tokenType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBTextModel ParseInternal(List<MBTextToken> tokens)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MBTextModel Parse(List<MBTextToken> tokens)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBTextParser()
	{
		throw null;
	}
}
