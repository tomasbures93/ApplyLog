namespace ApplyLog.Models
{
    public enum Result
    {
        Pending,
        NextRound,
        No,
        Yes
    }
    public class Bewerbung
    {
        public int id { get; set; }
        public Firma firma { get; set; }
        public string jobort { get; set; }
        public string position { get; set; }
        public DateTime whenapplied { get; set; }
        public int? gehalt { get; set; }
        public bool homeoffice { get; set; }
        public string applicationlink { get; set; }
        public Result result { get; set; }
    }
}
