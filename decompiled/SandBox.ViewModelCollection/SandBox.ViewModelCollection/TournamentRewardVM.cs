using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection;

public class TournamentRewardVM : ViewModel
{
	private string _text;

	private ItemImageIdentifierVM _imageIdentifier;

	private bool _gotImageIdentifier;

	[DataSourceProperty]
	public string Text
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

	[DataSourceProperty]
	public bool GotImageIdentifier
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

	[DataSourceProperty]
	public ItemImageIdentifierVM ImageIdentifier
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
	public TournamentRewardVM(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TournamentRewardVM(string text, ItemImageIdentifierVM imageIdentifierVM)
	{
		throw null;
	}
}
