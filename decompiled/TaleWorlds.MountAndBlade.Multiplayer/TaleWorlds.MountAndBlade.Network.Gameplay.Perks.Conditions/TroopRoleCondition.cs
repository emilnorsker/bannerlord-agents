using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Conditions;

public class TroopRoleCondition : MPPerkCondition
{
	private enum Role
	{
		Sergeant,
		Troop,
		BannerBearer
	}

	protected static string StringType;

	private Role _role;

	public override PerkEventFlags EventFlags
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TroopRoleCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Check(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Check(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAgentSergeant(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAgentBannerBearer(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TroopRoleCondition()
	{
		throw null;
	}
}
