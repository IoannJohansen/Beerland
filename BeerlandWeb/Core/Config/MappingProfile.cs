using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;

namespace BeerlandWeb.Config;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductionUnit, StatisticViewModel>().ForMember(m => m.BeerMark,
            memberOptions => { memberOptions.MapFrom(f => f.BeerMark.Name); });
        CreateMap<CreateStatisticViewModel, ProductionUnit>();
        CreateMap<ProductionUnit, ProductionUnitViewModel>()
            .ForMember(m => m.BeerMark, opt => opt.MapFrom(f => f.BeerMark.Name));
    }
}