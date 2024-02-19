using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;
using NetSchool.Context;

namespace NetSchool.Services.Points;
public class PointModel
{
    public Guid Id { get; set; }

    public Guid PointCategoryId { get; set; }
    public string PointCategoryTitle { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public double Latitude { get; set; } // Широта
    public double Longitude { get; set; }

    public IEnumerable<string> Feedbacks { get; set; }
    public IEnumerable<string> ImagePathes { get; set; }
}
public class PointModelProfile : Profile
{
    public PointModelProfile()
    {
        CreateMap<Point, PointModel>()
            .BeforeMap<PointModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PointCategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.PointCategoryTitle, opt => opt.Ignore())
            .ForMember(dest => dest.Feedbacks, opt => opt.Ignore())
            .ForMember(dest => dest.ImagePathes, opt => opt.Ignore())
            ;
    }

    public class PointModelActions : IMappingAction<Point, PointModel>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public PointModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(Point source, PointModel destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var point = db.Points.Include(x => x.PointCategory).FirstOrDefault(x => x.Id == source.Id);

            destination.Id = point.Uid;
            destination.PointCategoryId = point.PointCategory.Uid;
            destination.PointCategoryTitle = point.PointCategory.Title;
            destination.Feedbacks = point.Feedbacks?.Select(x => x.Title);
            destination.ImagePathes = point.ImagePathes?.Select(x => x.Title);
        }
    }
}

