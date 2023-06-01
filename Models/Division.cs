namespace Tracking.Models
{
    public class Division
    {
        public string? DivisionID { get; set; }
        public string? DivisionName { get; set; }
        public string? DivisionLocalName { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<District>? Districts { get; set; }
    }
}
