using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace AIInfluence;

/// <summary>
/// POC slice 6: build exact TaleWorlds/BLGM console lines from structured parts.
/// </summary>
public static class GameMasterCommandSerializer
{
	public static string SerializeLine(string commandToken, IReadOnlyList<string> positionalArgs)
	{
		if (string.IsNullOrWhiteSpace(commandToken))
		{
			throw new ArgumentException("commandToken is required", "commandToken");
		}
		StringBuilder stringBuilder = new StringBuilder(commandToken.Trim());
		if (positionalArgs != null)
		{
			foreach (string positionalArg in positionalArgs)
			{
				stringBuilder.Append(' ');
				stringBuilder.Append(FormatPositionalArg(positionalArg));
			}
		}
		return stringBuilder.ToString();
	}

	private static string FormatPositionalArg(string arg)
	{
		if (arg == null)
		{
			return "";
		}
		if (arg.IndexOf(' ') >= 0 || arg.IndexOf('\t') >= 0)
		{
			return "'" + arg.Replace("'", "''") + "'";
		}
		return arg;
	}

	/// <summary>
	/// Slice 7: parse compact JSON from OpenRouter: { "gm_command": "gm.query.kingdom", "args": [] }.
	/// </summary>
	public static bool TryParseOpenRouterJson(string raw, out string line, out string errorMessage)
	{
		line = null;
		errorMessage = null;
		if (string.IsNullOrWhiteSpace(raw))
		{
			errorMessage = "empty response";
			return false;
		}
		string text = raw.Trim();
		text = Regex.Replace(text, "^```(?:json)?\\s*", "", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "\\s*```\\s*$", "", RegexOptions.IgnoreCase);
		text = text.Trim();
		try
		{
			JObject val = JObject.Parse(text);
			string text2 = val["gm_command"]?.ToObject<string>();
			if (string.IsNullOrWhiteSpace(text2))
			{
				errorMessage = "missing gm_command";
				return false;
			}
			if (!text2.TrimStart().StartsWith("gm.", StringComparison.OrdinalIgnoreCase))
			{
				errorMessage = "gm_command must start with gm.";
				return false;
			}
			List<string> list = new List<string>();
			if (val["args"] is JArray { } array)
			{
				foreach (JToken item in array)
				{
					if (item != null && item.Type != JTokenType.Null)
					{
						list.Add(item.ToObject<string>() ?? "");
					}
				}
			}
			line = SerializeLine(text2.Trim(), list);
			return true;
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
			return false;
		}
	}
}
