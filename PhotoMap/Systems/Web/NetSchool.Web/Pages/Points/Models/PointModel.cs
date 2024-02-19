namespace NetSchool.Web.Pages.Points.Models;

public class PointModel
{
    public Guid Id { get; set; }

    public Guid PointCategoryId { get; set; }
    public string PointCategoryTitle { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public double Latitude { get; set; } 
    public double Longitude { get; set; }

    public IEnumerable<string> Feedbacks { get; set; }
    public IEnumerable<string> ImagePathes { get; set; }
}
