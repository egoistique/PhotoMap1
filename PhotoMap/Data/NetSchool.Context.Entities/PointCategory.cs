namespace NetSchool.Context.Entities;

public class PointCategory : BaseEntity
{
    public string Title { get; set; }
    
    public virtual ICollection<Point> Points { get; set; }
}

