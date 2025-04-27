namespace ApplyLog.ApiModels
{
    public class JobList
    {
        public Stellenangebote[] stellenangebote { get; set; }

        public int maxErgebnisse { get; set; }
        public Wooutput woOutput { get; set; }
    }
}
