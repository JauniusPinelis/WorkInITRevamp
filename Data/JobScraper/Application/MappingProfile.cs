using Application.Dtos;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CvOnlineJob, JobUrl>().ReverseMap();
			CreateMap<CvBankasJob, JobUrl>().ReverseMap();
			CreateMap<CvMarketJob, JobUrl>().ReverseMap();

			CreateMap<JobUrl, JobDto>()
				.ForMember(j => j.Salary, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(i => i.SalaryMin, opt => opt.Ignore())
				.ForMember(i => i.SalaryMax, opt => opt.Ignore());


			CreateMap<CvOnlineJob, JobDto>()
				.ForMember(j => j.Salary, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(i => i.SalaryMin, opt => opt.Ignore())
				.ForMember(i => i.SalaryMax, opt => opt.Ignore())
				.ForMember(i => i.PortalName, opt => opt.MapFrom(o => "CvOnline"));
			CreateMap<CvBankasJob, JobDto>()
				.ForMember(j => j.Salary, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(i => i.SalaryMin, opt => opt.Ignore())
				.ForMember(i => i.SalaryMax, opt => opt.Ignore())
				.ForMember(i => i.PortalName, opt => opt.MapFrom(o => "CvBankas"));
			CreateMap<CvMarketJob, JobDto>()
				.ForMember(j => j.Salary, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(i => i.SalaryMin, opt => opt.Ignore())
				.ForMember(i => i.SalaryMax, opt => opt.Ignore())
				.ForMember(i => i.PortalName, opt => opt.MapFrom(o => "CvMarket"));
		}
	}
}
