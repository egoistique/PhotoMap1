using AutoMapper;
using PhotoMap.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMap.Services.ImagePathes;
public class ImagePathModel
{
    public Guid Id { get; set; }
    public Guid PointId { get; set; }
    public string Title { get; set; }
}
public class FeedbackModelProfile : Profile
{
    public FeedbackModelProfile()
    {
        CreateMap<ImagePath, ImagePathModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.PointId, opt => opt.MapFrom(src => src.Point.Uid)) // Маппинг на Uid точки
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}
