namespace NetSchool.Context;

using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;

public static class ImagePathesContextConfiguration
{
    public static void ConfigureImagePathes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImagePath>().ToTable("image_pathes");
        modelBuilder.Entity<ImagePath>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<ImagePath>().Property(x => x.Title).HasMaxLength(250);
        modelBuilder.Entity<ImagePath>()
            .HasOne(f => f.Point)
            .WithMany(p => p.ImagePathes)
            .HasForeignKey(f => f.PointId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
