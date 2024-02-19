namespace NetSchool.Context.Entities;

public class Point : BaseEntity
{
    public int? PointCategoryId { get; set; }
    public virtual PointCategory PointCategory { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public double Latitude { get; set; } // Широта
    public double Longitude { get; set; } // Долгота

    public virtual ICollection<Feedback> Feedbacks { get; set; }

    public virtual ICollection<ImagePath> ImagePathes { get; set; }
}
