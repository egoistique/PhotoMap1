namespace NetSchool.Context;

using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;

public static class PointsContextConfiguration
{
    public static void ConfigurePoints(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Point>().ToTable("points");
        modelBuilder.Entity<Point>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Point>().Property(x => x.Latitude).IsRequired();
        modelBuilder.Entity<Point>().Property(x => x.Longitude).IsRequired();
        modelBuilder.Entity<Point>().Property(x => x.Title).HasMaxLength(250);
        modelBuilder.Entity<Point>().HasOne(x => x.PointCategory).WithMany(x => x.Points).HasForeignKey(x => x.PointCategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}
