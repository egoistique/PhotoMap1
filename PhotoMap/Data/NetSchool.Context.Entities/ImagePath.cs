namespace NetSchool.Context.Entities;

public class ImagePath : BaseEntity
{
    public string Title { get; set; }
    public int PointId { get; set; }

    // Навигационное свойство к точке
    public virtual Point Point { get; set; }
}
