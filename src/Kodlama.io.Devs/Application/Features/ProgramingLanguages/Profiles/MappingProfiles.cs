using Application.Features.ProgramingLanguages.Commands;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Mapleme işlemi yapılır bu classta. kaynak hedefe dönüştürülür AutoMapper sayesinde.
        /// Veritabanı nesnem oluşturduğum model ve dtolar ile maplenir.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<ProgramingLanguage, CreatedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();
           

        }
    }
}
