using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Launcher.Library.UserDatas;

public class UserData
{
	public GameType GameType
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

	public UserGameTypeData SingleplayerData
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

	public UserGameTypeData MultiplayerData
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

	public DLLCheckDataCollection DLLCheckData
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UserData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UserModData GetUserModData(bool isMultiplayer, string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint? GetDLLLatestSizeInBytes(string dllName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetDLLLatestIsDangerous(string dllName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetDLLLatestVerifyInformation(string dllName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDLLLatestSizeInBytes(string dllName, uint sizeInBytes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDLLLatestVerifyInformation(string dllName, string verifyInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDLLLatestIsDangerous(string dllName, bool isDangerous)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnsureDLLIsAdded(string dllName)
	{
		throw null;
	}
}
