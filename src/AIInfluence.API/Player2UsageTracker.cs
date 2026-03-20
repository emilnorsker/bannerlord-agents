using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace AIInfluence.API;

public class Player2UsageTracker
{
	public class Player2UsageData
	{
		[JsonProperty("lastResetDate")]
		public DateTime LastResetDate { get; set; } = DateTime.Today;

		[JsonProperty("totalPlaytimeSeconds")]
		public double TotalPlaytimeSeconds { get; set; } = 0.0;

		[JsonProperty("totalInteractions")]
		public int TotalInteractions { get; set; } = 0;

		[JsonProperty("unlockMessageShown")]
		public bool UnlockMessageShown { get; set; } = false;
	}

	private static Player2UsageTracker _instance;

	private static readonly double _a1 = ComputeHoursThreshold();

	private static readonly int _a2 = ComputeInteractionsThreshold();

	private static readonly string ENCRYPTION_KEY = "P2UT_" + Environment.MachineName + "_AIINF";

	private string _dataFilePath;

	private Player2UsageData _data;

	private DateTime _sessionStartTime;

	private bool _isInGame = false;

	private DateTime _lastCheckTime;

	private string _lastCanSwitchLogMessage;

	private int _updateCallCount = 0;

	private DateTime _lastSuccessfulUpdateTime = DateTime.MinValue;

	private Func<bool> _validationDelegate;

	private Func<double, int, bool> _checkRequirementsDelegate;

	public static Player2UsageTracker Instance => _instance ?? (_instance = new Player2UsageTracker());

	private Player2UsageTracker()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_dataFilePath = Path.Combine(fullName, "save_data", ".p2usage");
		_validationDelegate = ValidateSecurityContext;
		_checkRequirementsDelegate = EvaluateUnlockCriteria;
		LoadData();
		_lastCheckTime = DateTime.Now;
	}

	private static double ComputeHoursThreshold()
	{
		return 2.0;
	}

	private static int ComputeInteractionsThreshold()
	{
		int num = 10;
		int num2 = 3;
		return num * num2;
	}

	public void OnGameStart()
	{
	}

	public void SaveProgress()
	{
	}

	public void OnGameEnd()
	{
	}

	public void Update()
	{
	}

	public void RegisterInteraction()
	{
	}

	public bool IsUnlockSatisfied()
	{
		return true;
	}

	private (double hours, int interactions) GetCurrentStatsInternal()
	{
		double num = _data.TotalPlaytimeSeconds / 3600.0;
		if (_isInGame)
		{
			DateTime now = DateTime.Now;
			double totalSeconds = (now - _sessionStartTime).TotalSeconds;
			num += totalSeconds / 3600.0;
		}
		return (hours: num, interactions: _data.TotalInteractions);
	}

	private bool EvaluateUnlockCriteria(double hours, int interactions)
	{
		if (!ValidateSecurityContext())
		{
			return false;
		}
		bool flag = VerifyHoursRequirement(hours);
		bool flag2 = VerifyInteractionsRequirement(interactions);
		return flag && flag2;
	}

	private bool VerifyHoursRequirement(double hours)
	{
		double num = ComputeHoursThreshold();
		return hours >= num;
	}

	private bool VerifyInteractionsRequirement(int interactions)
	{
		int num = ComputeInteractionsThreshold();
		return interactions >= num;
	}

	private bool ValidateSecurityContext()
	{
		return PerformSecurityChecks();
	}

	private void LogSwitchStatus(bool canSwitch, double hours, int interactions)
	{
		string text = $"[P2_TRACKER] IsUnlockSatisfied: {canSwitch} (Hours: {hours:F2}/{_a1}, Interactions: {interactions}/{_a2})";
		if (!(text != _lastCanSwitchLogMessage))
		{
			return;
		}
		_lastCanSwitchLogMessage = text;
		try
		{
			if (AIInfluenceBehavior.Instance == null)
			{
			}
		}
		catch
		{
		}
	}

	private bool CheckTrackerAvailability()
	{
		return _data != null && _isInGame;
	}

	private bool ValidateSwitchIntegrity()
	{
		return PerformSecurityChecks();
	}

	public (double hoursPlayed, int interactions) GetCurrentStats()
	{
		double num = _data.TotalPlaytimeSeconds;
		if (_isInGame)
		{
			DateTime now = DateTime.Now;
			double totalSeconds = (now - _sessionStartTime).TotalSeconds;
			num += totalSeconds;
		}
		double item = num / 3600.0;
		return (hoursPlayed: item, interactions: _data.TotalInteractions);
	}

	public bool TryNotifyProviderChange(string _)
	{
		return true;
	}

	private bool ProcessSwitchGate(string _)
	{
		MethodInfo method = typeof(Player2UsageTracker).GetMethod("IsUnlockSatisfied", BindingFlags.Instance | BindingFlags.Public);
		if (method != null)
		{
			if (!(bool)method.Invoke(this, null))
			{
				ShowRestrictionMessage();
				return false;
			}
		}
		else if (!IsUnlockSatisfied())
		{
			ShowRestrictionMessage();
			return false;
		}
		return true;
	}

	public void OnDailyResetHook()
	{
	}

	private void UpdatePlaytime()
	{
		if (!_isInGame)
		{
			return;
		}
		try
		{
			DateTime now = DateTime.Now;
			if (!ValidateTimeIntegrity(now))
			{
				_sessionStartTime = now;
				return;
			}
			double totalSeconds = (now - _sessionStartTime).TotalSeconds;
			if (totalSeconds < 0.0 || totalSeconds > 3600.0)
			{
				try
				{
					if (AIInfluenceBehavior.Instance != null)
					{
						AIInfluenceBehavior.Instance.LogMessage($"[P2_TRACKER] Suspicious elapsed time detected: {totalSeconds} seconds. Resetting session start time.");
					}
				}
				catch
				{
				}
				_sessionStartTime = now;
				return;
			}
			_data.TotalPlaytimeSeconds += totalSeconds;
			_sessionStartTime = now;
			SaveData();
			if (IsUnlockSatisfied() && !_data.UnlockMessageShown)
			{
				ShowUnlockMessage();
				_data.UnlockMessageShown = true;
				SaveData();
			}
		}
		catch (Exception ex)
		{
			try
			{
				if (AIInfluenceBehavior.Instance != null)
				{
					AIInfluenceBehavior.Instance.LogMessage("[P2_TRACKER] UpdatePlaytime() error: " + ex.Message);
				}
			}
			catch
			{
			}
		}
	}

	private static string UnescapeFormatting(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		text = text.Replace("\\n", "\n");
		text = text.Replace("\\t", "\t");
		text = text.Replace("\\r", "\r");
		return text;
	}

	private void CheckDateReset()
	{
		DateTime today = DateTime.Today;
		if (!(_data.LastResetDate.Date < today))
		{
			return;
		}
		try
		{
			if (AIInfluenceBehavior.Instance != null)
			{
				(double, int) currentStats = GetCurrentStats();
				AIInfluenceBehavior.Instance.LogMessage($"[P2_TRACKER] Daily reset triggered. Old stats: {currentStats.Item1:F1}/2 h, {currentStats.Item2}/30 interactions. Resetting regardless of completion status.");
			}
		}
		catch
		{
		}
		_data.LastResetDate = today;
		_data.TotalPlaytimeSeconds = 0.0;
		_data.TotalInteractions = 0;
		_data.UnlockMessageShown = false;
		if (_isInGame)
		{
			_sessionStartTime = DateTime.Now;
		}
		SaveData();
		if (_isInGame)
		{
			OnDailyResetHook();
		}
		try
		{
			if (AIInfluenceBehavior.Instance != null)
			{
				AIInfluenceBehavior.Instance.LogMessage("[P2_TRACKER] Daily reset completed. Stats reset to 0/2 h, 0/30 interactions.");
			}
		}
		catch
		{
		}
	}

	public void ShowRestrictionMessagePublic()
	{
	}

	private void ShowRestrictionMessage()
	{
		ShowRestrictionMessagePublic();
	}

	private void ShowUnlockMessage()
	{
	}

	private void ShowDateResetMessage()
	{
	}

	private static bool IsDebuggerPresent()
	{
		try
		{
			if (Debugger.IsAttached)
			{
				return true;
			}
			string environmentVariable = Environment.GetEnvironmentVariable("COR_ENABLE_PROFILING");
			if (!string.IsNullOrEmpty(environmentVariable) && environmentVariable == "1")
			{
				return true;
			}
			return false;
		}
		catch
		{
			return true;
		}
	}

	private bool ValidateIntegrity()
	{
		try
		{
			MethodInfo method = typeof(Player2UsageTracker).GetMethod("IsUnlockSatisfied", BindingFlags.Instance | BindingFlags.Public);
			MethodInfo method2 = typeof(Player2UsageTracker).GetMethod("EvaluateUnlockCriteria", BindingFlags.Instance | BindingFlags.NonPublic);
			MethodInfo method3 = typeof(Player2UsageTracker).GetMethod("ValidateSecurityContext", BindingFlags.Instance | BindingFlags.NonPublic);
			if (method == null || method2 == null || method3 == null)
			{
				return false;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 0)
			{
				return false;
			}
			ParameterInfo[] parameters2 = method2.GetParameters();
			if (parameters2.Length != 2)
			{
				return false;
			}
			if (!ValidateMethodHash(method))
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private bool ValidateMethodHash(MethodInfo method)
	{
		try
		{
			MethodBody methodBody = method.GetMethodBody();
			if (methodBody == null)
			{
				return false;
			}
			byte[] iLAsByteArray = methodBody.GetILAsByteArray();
			if (iLAsByteArray == null || iLAsByteArray.Length == 0)
			{
				return false;
			}
			int num = 0;
			if (iLAsByteArray.Length != 0)
			{
				num ^= iLAsByteArray[0];
				if (iLAsByteArray.Length > 1)
				{
					num ^= iLAsByteArray[^1];
				}
				num ^= iLAsByteArray.Length;
			}
			return num != 0;
		}
		catch
		{
			return false;
		}
	}

	private void ProtectFromReflection()
	{
		try
		{
			StackTrace stackTrace = new StackTrace();
			for (int i = 0; i < Math.Min(10, stackTrace.FrameCount); i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				if (frame == null)
				{
					continue;
				}
				MethodBase method = frame.GetMethod();
				if (method == null)
				{
					continue;
				}
				string text = method.Name.ToLower();
				string text2 = method.DeclaringType?.Name.ToLower() ?? "";
				if (text2.Contains("reflection") || text2.Contains("emit") || text.Contains("invoke") || text.Contains("getfield") || text.Contains("setfield") || text.Contains("getproperty"))
				{
					Type? declaringType = method.DeclaringType;
					bool? obj;
					if ((object)declaringType == null)
					{
						obj = null;
					}
					else
					{
						string? text3 = declaringType.Namespace;
						obj = ((text3 != null) ? new bool?(!text3.StartsWith("AIInfluence")) : ((bool?)null));
					}
					if (obj ?? true)
					{
						Thread.Sleep(100);
					}
				}
			}
		}
		catch
		{
		}
	}

	private bool PerformSecurityChecks()
	{
		if (IsDebuggerPresent())
		{
			Thread.Sleep(new Random().Next(50, 200));
		}
		if (!ValidateIntegrity())
		{
			return false;
		}
		if (_validationDelegate == null || _checkRequirementsDelegate == null)
		{
			return false;
		}
		if (!ValidateDelegatesIntegrity())
		{
			return false;
		}
		ProtectFromReflection();
		return true;
	}

	private bool ValidateDelegatesIntegrity()
	{
		try
		{
			MethodInfo method = _validationDelegate.Method;
			if (method.Name != "ValidateSecurityContext")
			{
				return false;
			}
			MethodInfo method2 = _checkRequirementsDelegate.Method;
			if (method2.Name != "EvaluateUnlockCriteria")
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static string ComputeEncryptionKey()
	{
		try
		{
			string text = "P2UT_";
			string machineName = Environment.MachineName;
			string text2 = "_AIINF";
			StringBuilder stringBuilder = new StringBuilder(text.Length + machineName.Length + text2.Length);
			stringBuilder.Append(text);
			char[] array = machineName.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i]);
			}
			stringBuilder.Append(text2);
			return stringBuilder.ToString();
		}
		catch
		{
			return "P2UT_DEFAULT_AIINF";
		}
	}

	private bool ValidateTimeIntegrity(DateTime time)
	{
		try
		{
			DateTime now = DateTime.Now;
			double num = Math.Abs((now - time).TotalHours);
			if (num > 24.0)
			{
				_sessionStartTime = now;
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private byte[] SecureDeriveKey(string password)
	{
		try
		{
			using SHA256 sHA = SHA256.Create();
			byte[] array = sHA.ComputeHash(Encoding.UTF8.GetBytes(password));
			byte[] array2 = sHA.ComputeHash(array);
			byte[] array3 = new byte[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array3[i] = (byte)(array[i] ^ array2[i]);
			}
			return sHA.ComputeHash(array3);
		}
		catch
		{
			return DeriveKey(password);
		}
	}

	private void LoadData()
	{
		try
		{
			string directoryName = Path.GetDirectoryName(_dataFilePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (File.Exists(_dataFilePath))
			{
				string cipherText = File.ReadAllText(_dataFilePath);
				string text = Decrypt(cipherText);
				_data = JsonConvert.DeserializeObject<Player2UsageData>(text);
			}
			else
			{
				_data = new Player2UsageData();
				SaveData();
			}
			CheckDateReset();
		}
		catch (Exception)
		{
			_data = new Player2UsageData();
			SaveData();
		}
	}

	private void SaveData()
	{
		try
		{
			string directoryName = Path.GetDirectoryName(_dataFilePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			string plainText = JsonConvert.SerializeObject((object)_data);
			string contents = Encrypt(plainText);
			File.WriteAllText(_dataFilePath, contents);
		}
		catch (Exception)
		{
		}
	}

	private string Encrypt(string plainText)
	{
		string password = ComputeEncryptionKey();
		byte[] key = SecureDeriveKey(password);
		byte[] array = new byte[16];
		using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
		{
			rNGCryptoServiceProvider.GetBytes(array);
		}
		using Aes aes = Aes.Create();
		aes.Key = key;
		aes.IV = array;
		using ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
		using MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
		{
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(plainText);
		}
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	private string Decrypt(string cipherText)
	{
		string password = ComputeEncryptionKey();
		byte[] key = SecureDeriveKey(password);
		byte[] array = Convert.FromBase64String(cipherText);
		byte[] array2 = new byte[16];
		Array.Copy(array, 0, array2, 0, array2.Length);
		using Aes aes = Aes.Create();
		aes.Key = key;
		aes.IV = array2;
		using ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
		using MemoryStream stream = new MemoryStream(array, array2.Length, array.Length - array2.Length);
		using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		using StreamReader streamReader = new StreamReader(stream2);
		return streamReader.ReadToEnd();
	}

	private byte[] DeriveKey(string password)
	{
		using SHA256 sHA = SHA256.Create();
		return sHA.ComputeHash(Encoding.UTF8.GetBytes(password));
	}
}
