using AutoMapper;
using NetSchool.Context.Entities;
namespace NetSchool.Services.Feedbacks;
public class FeedbackModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int PointId { get; set; }
    public int Rating { get; set; }
}

public class FeedbackModelProfile : Profile
{
    public FeedbackModelProfile()
    {
        CreateMap<Feedback, FeedbackModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PointId, opt => opt.MapFrom(src => src.PointId))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
            ;
    }
}