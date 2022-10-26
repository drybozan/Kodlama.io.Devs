using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetByIdProgLang
{
    public class GetByIdProgramingLanguageQuery:IRequest<ProgramingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageGetByIdDto>
        {
            private readonly IProgramingLanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _languageBusinessRules;

            public GetByIdProgramingLanguageHandler(IProgramingLanguageRepository languageRepository, IMapper mapper, ProgramingLanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<ProgramingLanguageGetByIdDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                // requsten gelen id yi dbde sorgula varsa entity getir
                ProgramingLanguage? language = await _languageRepository.GetAsync(b => b.Id == request.Id);

                // iş kurallarına uygun mu istenen data ?
                _languageBusinessRules.ProgramingLanguageShouldExistWhenRequested(language);

                //entity 'i dto'ya maple
                ProgramingLanguageGetByIdDto languageGetByIdDto = _mapper.Map<ProgramingLanguageGetByIdDto>(language);
                return languageGetByIdDto;
            }
        }
    }
}
