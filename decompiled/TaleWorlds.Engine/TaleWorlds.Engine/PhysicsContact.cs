using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineStruct("rglPhysics_contact", false, null)]
public struct PhysicsContact
{
	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair0;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair1;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair2;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair3;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair4;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair5;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair6;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair7;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair8;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair9;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair10;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair11;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair12;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair13;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair14;

	[CustomEngineStructMemberData("ignoredMember", true)]
	public readonly PhysicsContactPair ContactPair15;

	public readonly IntPtr body0;

	public readonly IntPtr body1;

	public readonly int NumberOfContactPairs;

	public PhysicsContactPair this[int index]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}
}
