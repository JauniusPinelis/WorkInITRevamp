using Application.Dtos;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Company, Logo>()
				.ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.ImageData))
				.ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.ImageExtension));
		}
	}
}
