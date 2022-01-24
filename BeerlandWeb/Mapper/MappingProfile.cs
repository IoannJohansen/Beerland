﻿using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;

namespace BeerlandWeb.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductionStatistic, StatisticViewModel>().ForMember(m => m.BeerMark, memberOptions =>
              {
                   memberOptions.MapFrom(f => f.BeerMark.Name);
              });
            CreateMap<CreateStatisticViewModel, ProductionStatistic>();

        }
    }
}
