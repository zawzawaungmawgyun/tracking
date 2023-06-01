using System.ComponentModel.DataAnnotations;

namespace Tracking.Models
{
    public class Branch
    {
        [Key]
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
