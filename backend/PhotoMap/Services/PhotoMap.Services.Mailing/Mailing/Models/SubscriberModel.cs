using AutoMapper;
using PhotoMap.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMap.Services.Mailing;
public class SubscriberModel
{
    public string Email { get; set; }
}
public class SubscriberModelProfile : Profile
{
    public SubscriberModelProfile()
    {
        CreateMap<Subscriber, SubscriberModel>()
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
            ;
    }
}
