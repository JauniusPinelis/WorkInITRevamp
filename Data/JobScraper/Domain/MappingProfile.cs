using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CvOnlineJob, JobUrl>().ReverseMap();
            CreateMap<CvBankasJob, JobUrl>().ReverseMap();
            CreateMap<CvMarketJob, JobUrl>().ReverseMap();
        }
    }
}
