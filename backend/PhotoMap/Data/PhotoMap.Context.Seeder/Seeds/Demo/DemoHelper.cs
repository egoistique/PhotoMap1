namespace PhotoMap.Context.Seeder;

using PhotoMap.Context.Entities;

public class DemoHelper
{
    public IEnumerable<Point> GetPoints = new List<Point>
    {
        new Point()
        {
            Uid = Guid.NewGuid(),
            Title = "Исаакиевский собор",
            Description = "Хорошее место",
            Latitude = 59.9343,
            Longitude = 30.3351,
            PointCategory = new PointCategory()
            {
                Uid = Guid.NewGuid(),
                Title = "Собор",
            },
            Feedbacks = new List<Feedback>()
            {

            },
            ImagePathes = new List<ImagePath>()
            {
                
            }
        },
    };
}