namespace Tracking.Models
{
    public class District
    {
        public string? DistrictID { get; set; }
        public string? DivisionID { get; set; }
        public virtual Division? Division { get; set; }
        public string? DistrictName { get; set; }
        public string? DistrictNameLocal { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
