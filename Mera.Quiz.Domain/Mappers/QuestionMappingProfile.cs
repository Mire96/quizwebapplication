using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Domain.Models;

namespace Mera.Quiz.Domain.Mappers
{
    public class QuestionMappingProfile : Profile
    {

        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionModel>();
            CreateMap<QuestionModel, Question>();
        }
    }
}
