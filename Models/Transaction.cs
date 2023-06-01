using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
namespace Tracking.Models
{
    public class Transaction
    {
        [Key]
        public int? Id { get; set; }
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
        public DateTime? IssueDate { get; set; }
        public string ModifiedIssueDate
        {
            get
            {
                string ss = IssueDate.ToString();
                string[] separate = ss.Split(" ");
                return separate[0];
            }
        }
        public string? TypeOfIssue { get; set; }
        public DateTime? SolutionDateICT { get; set; }
        public string ModifiedSolutionDateICT
        {
            get
            {
                string ss = SolutionDateICT.ToString();
                string[] separate = ss.Split(" ");
                return separate[0];
            }
        }
        public DateTime? SolutionDateServiceCenter { get; set; }
        public string ModifiedServiceCenter
        {
            get
            {
                string ss = SolutionDateServiceCenter.ToString();
                string[] separate = ss.Split(" ");
                return separate[0];
            }
        }
        public string? ServiceProviderName { get; set; }
        public string? SolutionDetails { get; set; }
    }
}
