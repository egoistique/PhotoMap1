using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;
using NetSchool.Context;
namespace NetSchool.Services.Feedbacks;
public class FeedbackModel
{
    public Guid Id { get; set; }
    public Guid PointId { get; set; } 
    public string Title { get; set; }
    public int Rating { get; set; }
    public string FeedbackAuthor { get; set; }
}

public class FeedbackModelProfile : Profile
{
    public FeedbackModelProfile()
    {
        CreateMap<Feedback, FeedbackModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.PointId, opt => opt.MapFrom(src => src.Point.Uid)) // Маппинг на Uid точки
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
            .ForMember(dest => dest.FeedbackAuthor, opt => opt.MapFrom(src => src.FeedbackAuthor));
    }
}
