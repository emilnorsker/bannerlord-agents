using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.Library;

namespace AIInfluence.API;

public static class DeepSeekClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	[Obfuscation(Exclude = true)]
	public const string URL_CHAT_COMPLETIONS = "https://api.deepseek.com/chat/completions";

	public static async Task<bool> TestConnection()
	{
		try
		{
			if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.DeepSeekApiKey))
			{
				InformationManager.DisplayMessage(new InformationMessage("DeepSeek: API Key is not set", ExtraColors.RedAIInfluence));
				return false;
			}
			DeepSeekChatRequest requestBody = new DeepSeekChatRequest
			{
				Model = GlobalSettings<ModSettings>.Instance.DeepSeekModel,
				Messages = new List<DeepSeekMessage>
				{
					new DeepSeekMessage
					{
						Role = "user",
						Content = "Hello"
					}
				}
			};
			string json = JsonConvert.SerializeObject((object)requestBody);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.DeepSeekApiKey);
			HttpResponseMessage response = await httpClient.PostAsync("https://api.deepseek.com/chat/completions", (HttpContent)(object)content);
			if (response.IsSuccessStatusCode)
			{
				InformationManager.DisplayMessage(new InformationMessage("DeepSeek: Connection test successful", ExtraColors.GreenAIInfluence));
				return true;
			}
			InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "DeepSeek: Test request failed: {0} - {1}", arg0: response.StatusCode), ExtraColors.RedAIInfluence));
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("DeepSeek: Connection test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}
}
