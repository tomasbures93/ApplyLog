using System.Text.Json;

namespace ApplyLog.GermanCityModels
{
    public class GermanCityCoords
    {
        private string path = Path.Combine(Directory.GetCurrentDirectory(), "germany.json");

        private List<City> cityCoordsList { get; set; }

        public GermanCityCoords() { 
            cityCoordsList = new List<City>();
            LoadCities();
        }

        public City GetCityGeo(string city)
        {
                foreach (City c in cityCoordsList)
                {
                    if(c.name.ToLower() == city.ToLower())
                    {
                        return c;
                    } 
                }
            return null;
        }

        private bool LoadCities()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string file = sr.ReadToEnd();
                    cityCoordsList = JsonSerializer.Deserialize<List<City>>(file);
                    if (cityCoordsList != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } 
            else
            {
                return false;
            }
        }
        
    }
}
