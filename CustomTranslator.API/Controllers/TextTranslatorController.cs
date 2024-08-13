using AzureCognitive;
using CustomTranslator.API.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace CustomTranslator.API.Controllers
{
    [Route("customtranslator/api/[controller]")]
    [ApiController]
    public class TextTranslatorController : ControllerBase
    {
        private static readonly string key = "6ce115202ae949d39a36fe506777b502";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
        private readonly TranslatorContext translatorContext;
        private readonly ILogger<TextTranslatorController> logger;  

        public TextTranslatorController(TranslatorContext translatorContext, ILogger<TextTranslatorController> logger)
        {
            this.translatorContext = translatorContext;
            this.logger = logger;   
        }

        // Add your location, also known as region. The default is global.
        // This is required if using a Cognitive Services resource and can be found in the Azure portal on the Keys and Endpoint page.
        private static readonly string location = "eastasia";

        [HttpGet(Name = "GetResult")]
        public async Task<string> Get(string text,string from,string to,bool ChinseToEnglish)
        {
            // Input and output languages are defined as parameters.
            string route = $"/translate?api-version=3.0&from={from}&to=sw&to={to}";
            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonSerializer.Serialize(body);
            string result = string.Empty;
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                result = await response.Content.ReadAsStringAsync();
            }
            logger.LogInformation("database start");
            Task.Run(async () =>
            {
                logger.LogInformation("database task start");

                var dataObj = JsonSerializer.Deserialize<List<TranslationsResponse>>(result);
                TranslatorHistory translatorHistory = new TranslatorHistory(text, dataObj?.FirstOrDefault()?.translations?.Where(x => x.to == (!ChinseToEnglish ? "zh-Hans" : "en")).FirstOrDefault()?.text, from, to, DateTime.UtcNow);
                if (!translatorContext.TranslatorHistorys.Where(x => x.From == translatorHistory.From && x.FromText == translatorHistory.FromText).Any())
                {
                    logger.LogInformation("database no recored then add");

                    translatorContext.TranslatorHistorys.Add(translatorHistory);
                    await translatorContext.SaveChangesAsync();
                }
                logger.LogInformation("database end");

            });

            return result;

        }
    }
}
