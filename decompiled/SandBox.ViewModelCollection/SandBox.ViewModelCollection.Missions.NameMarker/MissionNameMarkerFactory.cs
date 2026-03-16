using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SandBox.ViewModelCollection.Missions.NameMarker;

public static class MissionNameMarkerFactory
{
	public interface INameMarkerProviderContext
	{
		string Id { get; }

		bool IsDefaultContext { get; }

		void AddProvider<T>() where T : MissionNameMarkerProvider, new();

		void RemoveProvider<T>() where T : MissionNameMarkerProvider, new();
	}

	private class NameMarkerProviderContext : INameMarkerProviderContext
	{
		private Action _onProvidersChanged;

		public string Id
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		public bool IsDefaultContext
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		public List<Type> ProviderTypes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NameMarkerProviderContext(bool isDefault, string id, Action onProvidersChanged)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddProvider<T>() where T : MissionNameMarkerProvider, new()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveProvider<T>() where T : MissionNameMarkerProvider, new()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddProvider(Type tProvider)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveProvider(Type tProvider)
		{
			throw null;
		}
	}

	public static readonly INameMarkerProviderContext DefaultContext;

	private static List<INameMarkerProviderContext> _registeredContexts;

	public static event Action OnProvidersChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionNameMarkerFactory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static INameMarkerProviderContext PushContext(string name, bool addDefaultProviders)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PopContext(string contextId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PopContext(INameMarkerProviderContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FireProvidersChangedEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<MissionNameMarkerProvider> CollectProviders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UpdateProviders(MissionNameMarkerProvider[] existingProviders, out List<MissionNameMarkerProvider> addedProviders, out List<MissionNameMarkerProvider> removedProviders)
	{
		throw null;
	}
}
