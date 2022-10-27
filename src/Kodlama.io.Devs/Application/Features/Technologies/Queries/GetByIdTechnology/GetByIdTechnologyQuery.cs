
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IProgramingLanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetByIdTechnologyHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules, IProgramingLanguageRepository languageRepository)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
                _languageRepository = languageRepository;
            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                // requsten gelen id yi dbde sorgula varsa entity getir
                Technology? technology = await _technologyRepository.GetAsync(b => b.Id == request.Id);
               
                // iş kurallarına uygun mu istenen data ?
                _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

                // teknoloji varsa programala dilini sorgula
                ProgramingLanguage? programingLanguage = await _languageRepository.GetAsync(x=>x.Id==technology.ProgramingLanguageId);
               
                //entity 'i dto'ya maple
               TechnologyGetByIdDto technologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);
                technologyGetByIdDto.ProgramingLanguageName = programingLanguage.Name;
                return technologyGetByIdDto;
            }
        }
    }
}
