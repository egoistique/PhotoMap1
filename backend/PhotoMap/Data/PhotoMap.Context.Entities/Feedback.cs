namespace PhotoMap.Context.Entities;

public class Feedback : BaseEntity
{
    public int? PointId { get; set; }
    public virtual Point Point { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }
    public string FeedbackAuthor { get; set; }

}
