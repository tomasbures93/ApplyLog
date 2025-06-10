using ApplyLog.AIModels;
using ApplyLog.CVModels;
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

        public async Task<(AIAnswer, string)> GenerateAILetter(AILetterViewModel model)
        {
            string FullUrl = URL + Key;
            string promt = $"Hello Gemini, Generate me a Cover Letter please. I am looking for formal form of Cover letter. " +
                $"My name is: {model.FullName} , my address is {model.Address}, my email: {model.Email}, my phone {model.PhoneNumber} . " +
                $"The company I am applying is -> Company Name: {model.CompanyName} with Address {model.CompanyAddress}, Position I am Applying for is: {model.PositionName}. " +
                $"Now I will give you some informations like Why I Want to work there, What are my Technical Skills (like languages what I know or programs I can use), " +
                $"What are my Softskills like ( how good I am with stress and in team) and maybe some more info about me. " +
                $"Why I want to work there -> {model.WhyIwant}. Technical Skills -> {model.TechSkills}. Soft Skills -> {model.SoftSkills}. " +
                $"More informations about me -> {model.MoreInfo}." +
                $"Can you also fill the information already in please which I gave you ? Like my Name, my adrress, adrress and name of company ?";

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
                return (empty, "no response");
            }

            string responseBody = response.Content.ReadAsStringAsync().Result;

            try
            {
                var answer = JsonSerializer.Deserialize<AnswerInfo>(responseBody);
                if(answer.candidates != null && answer.modelVersion != null)
                {
                    string rawAnswerText = answer.candidates[0].content.parts[0].text;
                    AIAnswer answerInfo = new AIAnswer() { Model = answer.modelVersion, Text = answer.candidates[0].content.parts[0].text.Replace("\n", "<br />") };
                    return (answerInfo, rawAnswerText);
                } else
                {
                    var problem = JsonSerializer.Deserialize<AIProblem>(responseBody);
                    AIAnswer asnwerInfo = new AIAnswer() { Model = "None", Text = problem.error.message };
                    return (asnwerInfo, "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                AIAnswer wrong = new AIAnswer() { Model = "NONE", Text = ex.Message };
                return (wrong, ex.Message);
            }
        }

        public async Task<(AIAnswer,string)> GenerateCV(PersonalInfo info, List<WorkEntry> jobs, List<EducationEntry> schools, List<LanguageEntry> languages)
        {
            string FullUrl = URL + Key;
            string educationPromt = "";
            foreach (var school in schools)
            {
                educationPromt = educationPromt + "\n" + $"I have attended {school.Institut} where my main subject was {school.Subject}" +
                    $"Small description of school and subject {school.Description}, I finished / will finish with {school.Degree} Degree" +
                    $"I started {school.StartDate} and I finished / will finish {school.EndDate} \n";
            }
            string languagePromt = "";
            foreach (var language in languages)
            {
                languagePromt = languagePromt + "\n" + $"I can speak different languages" +
                    $"{language.LanguageName} niveau {language.Level}";
            }
            string jobsPromt = "";
            foreach (var job in jobs)
            {
                jobsPromt = jobsPromt + "\n" + $"I have also some work experience" +
                    $"I worked for {job.Company} on job position {job.JobPosition} from {job.StartDate} untill {job.EndDate}" +
                    $"Short job description {job.Description}";
            }
            string promt = $"Hello Gemini, Can you generate me a muster for curriculum vitae ? Something basic but also nice ?" +
                $"I am gonna give you some informations and hopefully you will be able to use it well" +
                $"First I am gonna tell you something about me. My name is {info.FirstName} {info.LastName} , My address is {info.Address}, My phone number is {info.TelNummer}." +
                $"My Hobbies are {info.Hobbys}, My personal Summary (stuff I believe and my mottos are) {info.PersonalSummary}, My soft skills are : {info.SoftSkills} , My Technical skills are {info.TechnicalSkills}" +
                $"Now lets talk about my education " + educationPromt +
                $"Lets talk about my job experiences " + jobsPromt +
                $"Lets talk about my language skills " + languagePromt + "" +
                "Please as I said try to generate me nice curriculum vitae with the data I provided";

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

            if (response == null)
            {
                AIAnswer empty = new AIAnswer() { Model = "NONE", Text = "Something went wrong" };
                return (empty, "Something went wrong");
            }

            string responseBody = response.Content.ReadAsStringAsync().Result;

            try
            {
                var answer = JsonSerializer.Deserialize<AnswerInfo>(responseBody);
                if (answer.candidates != null && answer.modelVersion != null)
                {
                    string rawAnswerText = answer.candidates[0].content.parts[0].text;
                    AIAnswer answerInfo = new AIAnswer() { Model = answer.modelVersion, Text = answer.candidates[0].content.parts[0].text.Replace("\n", "<br />") };
                    return (answerInfo, rawAnswerText);
                }
                else
                {
                    var problem = JsonSerializer.Deserialize<AIProblem>(responseBody);
                    AIAnswer asnwerInfo = new AIAnswer() { Model = "None", Text = problem.error.message };
                    return (asnwerInfo, "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                AIAnswer wrong = new AIAnswer() { Model = "NONE", Text = ex.Message };
                return (wrong, ex.Message);
            }
        }
    }
}
