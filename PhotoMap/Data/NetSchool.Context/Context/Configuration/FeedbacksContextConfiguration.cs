namespace NetSchool.Context;

using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;

public static class FeedbacksContextConfiguration
{
    public static void ConfigureFeedbacks(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>().ToTable("feedbacks");
        modelBuilder.Entity<Feedback>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Feedback>().Property(x => x.Title).HasMaxLength(2500);
        modelBuilder.Entity<Feedback>()
            .HasOne(x => x.Point)
            .WithMany(x => x.Feedbacks)
            .HasForeignKey(x => x.PointId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
