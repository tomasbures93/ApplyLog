namespace ApplyLog.ApiModels
{
    public class Arbeitsort1
    {
        public string plz { get; set; }
        public string ort { get; set; }
        public string region { get; set; }
        public string land { get; set; }
        public Koordinaten1 koordinaten { get; set; }
        public string entfernung { get; set; }
        public string strasse { get; set; }
        public string ortsteil { get; set; }
    }
}
