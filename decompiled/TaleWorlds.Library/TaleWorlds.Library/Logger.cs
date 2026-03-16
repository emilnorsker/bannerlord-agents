using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace TaleWorlds.Library;

public class Logger
{
	private class FileManager
	{
		private bool _isCheckingFileSize;

		private int _maxFileSize;

		private int _numFiles;

		private FileStream[] _streams;

		private int _currentStreamIndex;

		private FileStream _errorStream;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FileManager(string path, string name, int numFiles, int maxTotalSize, bool overwrite, bool logErrorsToDifferentFile)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FileStream GetFileStream()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FileStream GetErrorFileStream()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CheckForFileSize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ShutDown()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void FillEmptyStream(FileStream stream)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ResetFileStream(FileStream stream)
		{
			throw null;
		}
	}

	private Queue<HTMLDebugData> _logQueue;

	private static Encoding _logFileEncoding;

	private string _name;

	private bool _writeErrorsToDifferentFile;

	private static List<Logger> _loggers;

	private FileManager _fileManager;

	private static Thread _thread;

	private static bool _running;

	private static bool _printedOnThisCycle;

	private static bool _isOver;

	public static string LogsFolder;

	public bool LogOnlyErrors
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
	static Logger()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Logger(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Logger(string name, bool writeErrorsToDifferentFile, bool logOnlyErrors, bool doNotUseProcessId, int numFiles = 1, int totalFileSize = -1, bool overwrite = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThreadMain()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Printer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoLoggingJob()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Print(string log, HTMLDebugCategory debugInfo = HTMLDebugCategory.General)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Print(string log, HTMLDebugCategory debugInfo, bool printOnGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FinishAndCloseAll()
	{
		throw null;
	}
}
