using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.MissionObjects;

public class ShipDoorUsePoint : UsableMissionObject
{
	private const string ShipDoorHighlightTag = "ship_door_highlight";

	private GameEntity _highlight;

	private bool _isEnabled;

	[EditableScriptComponentVariable(true, "ActionStringId")]
	private string _actionStringId;

	[EditableScriptComponentVariable(true, "DescriptionStringId")]
	private string _descriptionStringId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipDoorUsePoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsUsableByAgent(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipDoorUsePointEnabled(bool isEnabled)
	{
		throw null;
	}
}
