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

namespace Application.Features.ProgramingLanguages.Commands
{
    public class DeleteProgramingLanguageCommand : IRequest<DeletedProgramingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeletedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            //entity ile dtoları mapler
            private readonly IMapper _mapper;
            // bu entity için kurallarım
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                // istek içinde gelen varlığı sorgula var mı ?
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(p => p.Id == request.Id);
                //yoksa hata gönder.
                _programingLanguageBusinessRules.ProgramingLanguageShouldExistWhenDeleteRequested(programingLanguage);

                // istenilen varlığı sil
               await _programingLanguageRepository.DeleteAsync(programingLanguage);
                DeletedProgramingLanguageDto mappedDeletedProgramingLanguageDto = _mapper.Map<DeletedProgramingLanguageDto>(programingLanguage);
                return mappedDeletedProgramingLanguageDto;
            }
        }
    }
}
