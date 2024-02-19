using AutoMapper;
using NetSchool.Context.Entities;

namespace NetSchool.Services.PointCategories;
public class PointCategoryModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

public class PointCategoryModelProfile : Profile
{
    public PointCategoryModelProfile()
    {
        CreateMap<PointCategory, PointCategoryModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            ;
    }
}
