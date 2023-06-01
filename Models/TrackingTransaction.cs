using System.ComponentModel.DataAnnotations;

namespace Tracking.Models
{
    public class TrackingTransaction
    {
        [Key]
        public string? DivisionID { get; set; }
        public string? DivisionName { get; set; }
        public string? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? DeviceName { get; set; }
        public string? BrandName { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string? TypeOfIssue { get; set; }
        public DateTime? SolutionDateICT { get; set; }
        public DateTime? SolutionDateServiceCenter { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? SolutionDetails { get; set; }
    }
}
