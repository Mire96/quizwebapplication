﻿using AutoMapper;
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
            CreateMap<TestScoreModel, TestScore>();

            CreateMap<TestScore, TestScoreModel>();
        }
    }
}
