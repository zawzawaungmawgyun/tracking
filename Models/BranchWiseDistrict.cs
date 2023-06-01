using System.ComponentModel.DataAnnotations;

namespace Tracking.Models
{
    public class BranchWiseDistrict
    {
        [Key]
        public string? BranchCode { get; set; }
        public string? DistrictID { get; set; }
        public string? DivisionID { get; set; }
    }
}
