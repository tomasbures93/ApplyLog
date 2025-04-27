namespace ApplyLog.ApiModels
{
    public class Stellenangebote
    {
        public string beruf { get; set; }
        public string titel { get; set; }
        public string refnr { get; set; }
        public Arbeitsort1 arbeitsort { get; set; }
        public string arbeitgeber { get; set; }
        public string aktuelleVeroeffentlichungsdatum { get; set; }
        public DateTime modifikationsTimestamp { get; set; }
        public string eintrittsdatum { get; set; }
        public string externeUrl { get; set; }
        public string kundennummerHash { get; set; }
    }
}
