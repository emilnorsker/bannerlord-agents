using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem;

public class CampaignEntityComponent : IEntityComponent
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	void IEntityComponent.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IEntityComponent.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnTick(float realDt, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignEntityComponent()
	{
		throw null;
	}
}
