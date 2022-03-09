using AutoMapper;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Mappers
{
    public class TestScoreMappingProfile : Profile
    {
        public TestScoreMappingProfile()
        {
            CreateMap<TestModel, TestScore>()
                .ForMember(dest => dest.Score, 
                opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.UserNameFK,
                opt => opt.MapFrom(src => src.UserName.ID))
                .ForMember(dest => dest.TestNameFK,
                opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.ID, src => src.Ignore());

            CreateMap<TestScore, TestModel>();
        }
    }
}
