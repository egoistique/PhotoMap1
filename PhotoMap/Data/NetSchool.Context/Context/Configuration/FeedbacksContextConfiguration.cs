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
            .HasOne(f => f.Point)
            .WithMany(p => p.Feedbacks)
            .HasForeignKey(f => f.PointId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
