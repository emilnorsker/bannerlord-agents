using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.Library;

namespace AIInfluence.API;

public static class OllamaClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	public static async Task<bool> TestConnection()
	{
		try
		{
			string baseUrl = GlobalSettings<ModSettings>.Instance?.OllamaApiUrl ?? "http://localhost:11434";
			string model = GlobalSettings<ModSettings>.Instance?.OllamaModel ?? "llama2";
			string modelsUrl = baseUrl + "/api/tags";
			HttpResponseMessage modelsResponse = await httpClient.GetAsync(modelsUrl);
			if (modelsResponse.IsSuccessStatusCode)
			{
				await modelsResponse.Content.ReadAsStringAsync();
				InformationManager.DisplayMessage(new InformationMessage("Ollama: Models endpoint accessible", ExtraColors.GreenAIInfluence));
				string testUrl = baseUrl + "/api/generate";
				OllamaGenerateRequest testBody = new OllamaGenerateRequest
				{
					Model = model,
					Prompt = "Hello",
					Stream = false,
					Options = new OllamaOptions
					{
						NumPredict = 10
					}
				};
				StringContent testContent = new StringContent(JsonConvert.SerializeObject((object)testBody), Encoding.UTF8, "application/json");
				HttpResponseMessage testResponse = await httpClient.PostAsync(testUrl, (HttpContent)(object)testContent);
				if (testResponse.IsSuccessStatusCode)
				{
					InformationManager.DisplayMessage(new InformationMessage("Ollama: Connection test successful", ExtraColors.GreenAIInfluence));
					return true;
				}
				InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await testResponse.Content.ReadAsStringAsync(), format: "Ollama: Test request failed: {0} - {1}", arg0: testResponse.StatusCode), ExtraColors.RedAIInfluence));
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await modelsResponse.Content.ReadAsStringAsync(), format: "Ollama: Models endpoint failed: {0} - {1}", arg0: modelsResponse.StatusCode), ExtraColors.RedAIInfluence));
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("Ollama: Connection test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}

	public static async Task<bool> TestChatConnection()
	{
		try
		{
			string baseUrl = GlobalSettings<ModSettings>.Instance?.OllamaApiUrl ?? "http://localhost:11434";
			string model = GlobalSettings<ModSettings>.Instance?.OllamaModel ?? "llama2";
			string chatUrl = baseUrl + "/api/chat";
			OllamaChatRequest chatRequestBody = new OllamaChatRequest
			{
				Model = model,
				Messages = new List<OllamaMessage>
				{
					new OllamaMessage
					{
						Role = "user",
						Content = "Hello"
					}
				},
				Stream = false,
				Options = new OllamaOptions
				{
					NumPredict = 10
				}
			};
			StringContent chatContent = new StringContent(JsonConvert.SerializeObject((object)chatRequestBody), Encoding.UTF8, "application/json");
			HttpResponseMessage chatResponse = await httpClient.PostAsync(chatUrl, (HttpContent)(object)chatContent);
			if (chatResponse.IsSuccessStatusCode)
			{
				InformationManager.DisplayMessage(new InformationMessage("Ollama: Chat endpoint test successful", ExtraColors.GreenAIInfluence));
				return true;
			}
			InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await chatResponse.Content.ReadAsStringAsync(), format: "Ollama: Chat endpoint test failed: {0} - {1}", arg0: chatResponse.StatusCode), ExtraColors.RedAIInfluence));
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("Ollama: Chat endpoint test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}
}
