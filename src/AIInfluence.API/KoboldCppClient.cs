using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.Library;

namespace AIInfluence.API;

public static class KoboldCppClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	public static async Task<bool> TestConnection()
	{
		try
		{
			string baseUrl = GlobalSettings<ModSettings>.Instance?.KoboldCppApiUrl ?? "http://localhost:5001";
			string infoUrl = baseUrl + "/api/v1/model";
			HttpResponseMessage infoResponse = await httpClient.GetAsync(infoUrl);
			if (infoResponse.IsSuccessStatusCode)
			{
				await infoResponse.Content.ReadAsStringAsync();
				InformationManager.DisplayMessage(new InformationMessage("KoboldCpp: Model info accessible", ExtraColors.GreenAIInfluence));
				string testUrl = baseUrl + "/api/v1/generate";
				KoboldCppGenerateRequest testBody = new KoboldCppGenerateRequest
				{
					Prompt = "Hello",
					MaxLength = 10,
					Temperature = 0.7,
					Stream = false
				};
				StringContent testContent = new StringContent(JsonConvert.SerializeObject((object)testBody), Encoding.UTF8, "application/json");
				HttpResponseMessage testResponse = await httpClient.PostAsync(testUrl, (HttpContent)(object)testContent);
				if (testResponse.IsSuccessStatusCode)
				{
					InformationManager.DisplayMessage(new InformationMessage("KoboldCpp: Connection test successful", ExtraColors.GreenAIInfluence));
					return true;
				}
				InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await testResponse.Content.ReadAsStringAsync(), format: "KoboldCpp: Test request failed: {0} - {1}", arg0: testResponse.StatusCode), ExtraColors.RedAIInfluence));
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await infoResponse.Content.ReadAsStringAsync(), format: "KoboldCpp: Model info endpoint failed: {0} - {1}", arg0: infoResponse.StatusCode), ExtraColors.RedAIInfluence));
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("KoboldCpp: Connection test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}

	public static async Task<bool> TestDetailedConnection()
	{
		try
		{
			string baseUrl = GlobalSettings<ModSettings>.Instance?.KoboldCppApiUrl ?? "http://localhost:5001";
			string testUrl = baseUrl + "/api/v1/generate";
			KoboldCppGenerateRequest testBody = new KoboldCppGenerateRequest
			{
				Prompt = "Hello",
				MaxLength = 10,
				Temperature = 0.7,
				TopP = 0.9,
				Stream = false,
				StopSequence = new string[3] { "Human:", "Assistant:", "\n\n" }
			};
			StringContent testContent = new StringContent(JsonConvert.SerializeObject((object)testBody), Encoding.UTF8, "application/json");
			HttpResponseMessage testResponse = await httpClient.PostAsync(testUrl, (HttpContent)(object)testContent);
			if (testResponse.IsSuccessStatusCode)
			{
				dynamic koboldResponse = JsonConvert.DeserializeObject<object>(await testResponse.Content.ReadAsStringAsync());
				if (koboldResponse?.results != null && koboldResponse.results.Count > 0)
				{
					InformationManager.DisplayMessage(new InformationMessage("KoboldCpp: Detailed connection test successful", ExtraColors.GreenAIInfluence));
					return true;
				}
				InformationManager.DisplayMessage(new InformationMessage("KoboldCpp: Detailed test failed: No results in response", ExtraColors.RedAIInfluence));
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await testResponse.Content.ReadAsStringAsync(), format: "KoboldCpp: Detailed test failed: {0} - {1}", arg0: testResponse.StatusCode), ExtraColors.RedAIInfluence));
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("KoboldCpp: Detailed connection test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}
}
