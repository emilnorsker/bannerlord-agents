using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace psai.Editor;

[Serializable]
public abstract class PsaiMusicEntity : ICloneable
{
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public abstract string GetClassString();

	public abstract CompatibilitySetting GetCompatibilitySetting(PsaiMusicEntity targetEntity);

	public abstract CompatibilityType GetCompatibilityType(PsaiMusicEntity targetEntity, out CompatibilityReason reason);

	public abstract PsaiMusicEntity GetParent();

	public abstract List<PsaiMusicEntity> GetChildren();

	public abstract int GetIndexPositionWithinParentEntity(PsaiProject parentProject);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual object Clone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual PsaiMusicEntity ShallowCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool PropertyDifferencesAffectCompatibilities(PsaiMusicEntity otherEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Theme GetTheme()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PsaiMusicEntity()
	{
		throw null;
	}
}
