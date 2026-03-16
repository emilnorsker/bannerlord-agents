using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Launcher.Library.UserDatas;
using TaleWorlds.TwoDimension;
using TaleWorlds.TwoDimension.Standalone;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class StandaloneUIDomain : FrameworkDomain
{
	private SingleThreadedSynchronizationContext _synchronizationContext;

	private bool _initialized;

	private bool _shouldDestroy;

	private GraphicsForm _graphicsForm;

	private GraphicsContext _graphicsContext;

	private UIContext _gauntletUIContext;

	private TwoDimensionContext _twoDimensionContext;

	private LauncherUI _launcherUI;

	private readonly ResourceDepot _resourceDepot;

	public UserDataManager UserDataManager
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

	public string AdditionalArgs
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasUnofficialModulesSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandaloneUIDomain(GraphicsForm graphicsForm, ResourceDepot resourceDepot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStartGameRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCloseRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMinimizeRequest()
	{
		throw null;
	}
}
