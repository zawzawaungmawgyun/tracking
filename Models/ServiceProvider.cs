using System.ComponentModel.DataAnnotations;

namespace Tracking.Models
{
    public class ServiceProvider
    {
        [Key]
        public string? Name { get; set; }
        public string? ContactNumber { get; set;}
        public string? Address { get; set; }

    }
}
