using System;
using System.IO;
using System.Reflection;

namespace AIInfluence.Diseases;

public class DiseaseLogger
{
	private static DiseaseLogger _instance;

	private readonly string _logFilePath;

	public static DiseaseLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DiseaseLogger();
			}
			return _instance;
		}
	}

	private DiseaseLogger()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "logs");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		_logFilePath = Path.Combine(text, "diseases.log");
	}

	public void Log(string message)
	{
		try
		{
			string contents = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
			File.AppendAllText(_logFilePath, contents);
		}
		catch (Exception)
		{
		}
	}

	public void ClearLog()
	{
		try
		{
			if (File.Exists(_logFilePath))
			{
				File.WriteAllText(_logFilePath, "");
				Log("Log cleared");
			}
		}
		catch (Exception)
		{
		}
	}
}
