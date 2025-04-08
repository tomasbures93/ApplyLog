namespace ApplyLog.Models
{
    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
    public class TODO
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Describtion { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Deadline {  get; set; }
        public PriorityLevel PriorityLevel { get; set; }
    }

    
}
