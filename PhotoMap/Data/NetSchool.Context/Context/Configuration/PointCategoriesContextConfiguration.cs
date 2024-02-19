namespace NetSchool.Context;

using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;

public static class PointCategoriesContextConfiguration
{
    public static void ConfigurePointCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PointCategory>().ToTable("point_categories");
        modelBuilder.Entity<PointCategory>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<PointCategory>().Property(x => x.Title).HasMaxLength(50);
        modelBuilder.Entity<PointCategory>().HasIndex(x => x.Title).IsUnique();
    }
}