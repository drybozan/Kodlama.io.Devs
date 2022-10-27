using Application.Features.ProgramingLanguages.Commands;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.Technologies.Commands;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Mapleme işlemi yapılır bu classta. kaynak hedefe dönüştürülür AutoMapper sayesinde.
        /// Veritabanı nesnem oluşturduğum model ve dtolar ile maplenir.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>()
               .ForMember(t => t.ProgramingLanguageName, opt => opt.MapFrom(t => t.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<Technology, TechnologyGetByIdDto>().ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();


        }
    }
}
