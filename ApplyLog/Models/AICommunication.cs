using ApplyLog.AIModels;
using Microsoft.Extensions.FileProviders.Composite;
using System.Resources;
using System.Text;
using System.Text.Json;

namespace ApplyLog.Models
{
    public class AICommunication
    {
        private readonly string URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=";
        private readonly string Key = "";
        private readonly HttpClient _httpClient;

        public AICommunication()
        {
            _httpClient = new HttpClient();
        }

        public async Task<AIAnswer> AskAI(AIFormViewModel model)
        {
            string FullUrl = URL + Key;
            string promt = $"Hello Gemini, Generate me a Cover Letter please. I am looking for formal form of Cover letter. " +
                $"My name is: {model.FullName}. The company I am applying is -> Company Name: {model.CompanyName}, Position I am Applying for is: {model.PositionName}. " +
                $"Now I will give you some informations like Why I Want to work there, What are my Technical Skills (like languages what I know or programs I can use), " +
                $"What are my Softskills like ( how good I am with stress and in team) and maybe some more info about me. " +
                $"Why I want to work there -> {model.WhyIwant}. Technical Skills -> {model.TechSkills}. Soft Skills -> {model.SoftSkills}. " +
                $"More informaitons about me -> {model.MoreInfo}.";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = promt }
                        }
                    }
                }
            };
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(FullUrl, content).Result;

            if(response == null)
            {
                AIAnswer empty = new AIAnswer() { Model = "NONE", Text = "Something went wrong" };
                return empty;
            }

            string responseBody = response.Content.ReadAsStringAsync().Result;

            try
            {
                var answer = JsonSerializer.Deserialize<AnswerInfo>(responseBody);            
                AIAnswer answerInfo = new AIAnswer() { Model = answer.modelVersion, Text = answer.candidates[0].content.parts[0].text.Replace("\n","<br />") };
                return answerInfo;
            }
            catch (Exception ex)
            {
                AIAnswer wrong = new AIAnswer() { Model = "NONE", Text = ex.Message };
                return wrong;
            }
        }
    }
}
