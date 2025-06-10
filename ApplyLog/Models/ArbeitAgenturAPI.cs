using System.Text.Json;
using ApplyLog.ApiModels;

namespace ApplyLog.Models
{
    public class ArbeitAgenturAPI
    {
        // Arbeitsagentur Jobsuche API Docs -> https://jobsuche.api.bund.dev/

        private static readonly HttpClient client = new HttpClient();

        private static string APIUrl = "https://rest.arbeitsagentur.de/jobboerse/jobsuche-service/pc/v4/jobs";

        private static int Size = 10;

        public async Task<(List<Stellenangebote>, int)> Jobs(string JobTitel, string JobLocation, int Radius, int page)
        {
            List<Stellenangebote> List = new List<Stellenangebote>();
            int maxPages = 0;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-API-Key", "jobboerse-jobsuche");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("ApplyLog");

            string query = $"?was={JobTitel}&wo={JobLocation}&umkreis={Radius}&size={Size}&page={page}";
            try
            {
                HttpResponseMessage message = await client.GetAsync(APIUrl + query);
                message.EnsureSuccessStatusCode();

                string responseBody = await message.Content.ReadAsStringAsync();

                JobList angebot = JsonSerializer.Deserialize<JobList>(responseBody);
                maxPages = (int)Math.Ceiling((double)angebot.maxErgebnisse / Size);
                List = angebot.stellenangebote.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }

            return (List, maxPages);
        }
    }
}
