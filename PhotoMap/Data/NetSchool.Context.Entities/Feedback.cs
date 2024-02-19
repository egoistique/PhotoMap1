namespace NetSchool.Context.Entities;

public class Feedback : BaseEntity
{
    public string Title { get; set; }
    public int PointId { get; set; }
    public int Rating { get; set; }

    // Навигационное свойство к точке
    public virtual Point Point { get; set; }
}
