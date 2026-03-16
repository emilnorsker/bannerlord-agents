using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Chat;

public class ChatLogItemWidget : Widget
{
	public struct ChatMultiLineElement
	{
		public string Line;

		public int IdentModifier;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ChatMultiLineElement(string line, int identModifier)
		{
			throw null;
		}
	}

	private int _defaultMarginLeftPerIndent;

	private string _detailOpeningTag;

	private string _detailClosingTag;

	private Action<Widget> _fullyInsideAction;

	private ChatLogWidget _chatLogWidget;

	private string _chatLine;

	private RichTextWidget _oneLineTextWidget;

	private ChatCollapsableListPanel _collapsableWidget;

	[Editor(false)]
	public RichTextWidget OneLineTextWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public ChatCollapsableListPanel CollapsableWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public string ChatLine
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[Editor(false)]
	public ChatLogWidget ChatLogWidget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChatLogItemWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateWidgetFullyInside(Widget widget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PostMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<ChatMultiLineElement> GetFormattedLinesFromMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddLinesFromXMLRecur(XmlNode currentNode, ref List<ChatMultiLineElement> lineList, int currentIndentModifier)
	{
		throw null;
	}
}
