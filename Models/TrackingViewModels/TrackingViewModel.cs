namespace Tracking.Models.TrackingViewModels
{
    public class TrackingViewModel
    {
        public IEnumerable<Division>? Divisions { get; set; }
        public IEnumerable<District>? Districts { get; set; }    
        public IEnumerable<Branch>? Branches { get; set; }
        public IEnumerable<LoginUser>? LoginUsers { get; set; }
        public IEnumerable<ServiceProvider>? ServiceProviders { get; set; }
        public string? DeviceName { get; set; }
        public string? BrandName { get; set; }
        public string? SerialNumber   { get; set;}
        public DateOnly IssueDate { get; set; }
        public string? TypeOfIssue { get; set;}
        public DateOnly SolutionDateICT { get; set; }
        public DateOnly SolutionDateServiceCenter { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? SolutionDetails { get; set; }

    }
}
