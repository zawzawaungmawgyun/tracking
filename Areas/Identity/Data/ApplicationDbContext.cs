using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tracking.Areas.Identity.Data;
using Tracking.Models;

namespace Tracking.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LoginUser> LoginUser { get; set; } = null!;
    public DbSet<Division> Division { get; set; } = null!;
    public DbSet<District> District { get; set; } = null!;
    public DbSet<Branch> Branch { get; set; } = null!;
    public DbSet<BranchWiseDistrict> BranchWiseDistrict { get; set; } = null!;
    public DbSet<Models.ServiceProvider> ServiceProvider { get; set; } = null!;
    public DbSet<TrackingTransaction> TrackingTransaction { get; set; } = null!;
    public DbSet<Transaction> Transaction { get; set; } = null!;
    public DbSet<Device> Device { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
