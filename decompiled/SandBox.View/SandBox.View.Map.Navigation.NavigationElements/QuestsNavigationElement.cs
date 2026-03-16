using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Localization;

namespace SandBox.View.Map.Navigation.NavigationElements;

public class QuestsNavigationElement : MapNavigationElementBase
{
	public override string StringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsLockingNavigation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool HasAlert
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestsNavigationElement(MapNavigationHandler handler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override NavigationPermissionItem GetPermission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextObject GetTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextObject GetAlertTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OpenView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OpenView(params object[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GoToLink()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareToOpenQuestsScreen(Action openQuestsAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenQuestsAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenQuestsAction(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenQuestsAction(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenQuestsAction(JournalLogEntry log)
	{
		throw null;
	}
}
