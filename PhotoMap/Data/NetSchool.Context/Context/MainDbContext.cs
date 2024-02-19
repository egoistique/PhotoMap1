namespace NetSchool.Context;

using NetSchool.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<PointCategory> PointCategories { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<ImagePath> ImagePathes { get; set; }
    public DbSet<Point> Points { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigurePointCategories();
        modelBuilder.ConfigurePoints();
        modelBuilder.ConfigureFeedbacks();
        modelBuilder.ConfigureImagePathes();


        modelBuilder.ConfigureUsers();
    }
}
