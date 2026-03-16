using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameState;

public class BannerEditorState : TaleWorlds.Core.GameState
{
	private IBannerEditorStateHandler _handler;

	private Action _onEndAction;

	public override bool IsMenuState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IBannerEditorStateHandler Handler
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
	public BannerEditorState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerEditorState(Action endAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Clan GetClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterObject GetCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}
}
