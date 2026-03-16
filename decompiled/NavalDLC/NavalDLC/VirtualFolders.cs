using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC;

public class VirtualFolders
{
	[VirtualDirectory("__MODULE_NAME__NavalDLC__MODULE_NAME__\\Parameters")]
	public class Parameters
	{
		[VirtualFile("Version.xml", "<Version>\t<Singleplayer Value=\"v1.1.3.110062\"/></Version>")]
		public string Version;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Parameters()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VirtualFolders()
	{
		throw null;
	}
}
