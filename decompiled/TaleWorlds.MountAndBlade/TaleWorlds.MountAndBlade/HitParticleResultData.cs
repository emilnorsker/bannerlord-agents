using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Hit_particle_result_data", false, null)]
public struct HitParticleResultData
{
	public int StartHitParticleIndex;

	public int ContinueHitParticleIndex;

	public int EndHitParticleIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}
}
