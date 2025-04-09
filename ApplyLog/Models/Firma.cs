namespace ApplyLog.Models
{
    public class Firma
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string? Ort { get; set; }
        public virtual Kontakt? Kontakt { get; set; }
    }
}
