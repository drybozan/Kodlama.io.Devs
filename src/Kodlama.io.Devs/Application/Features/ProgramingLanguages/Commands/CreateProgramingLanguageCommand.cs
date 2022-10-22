using Application.Features.ProgramingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands
{
    public partial class CreateProgramingLanguageCommand:IRequest<CreatedProgramingLanguageDto>
    {
        public string programingLanguageName { get; set; }



        public class CreateProgramingLanguageCommandHandler :IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguageDto>
        {
           
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            //entity ile dtoları mapler
            private readonly IMapper _mapper;
            // bu entity için kurallarım
            //private readonly BrandBusinessRules _brandBusinessRules;


            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
               // _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
           
                //await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage createdProgramingLanguage = await _programingLanguageRepository.AddAsync(mappedProgramingLanguage);
                CreatedProgramingLanguageDto createdProgramingLanguageDto = _mapper.Map<CreatedProgramingLanguageDto>(createdProgramingLanguage);

                return createdProgramingLanguageDto; 

            }
        }
    }
}
