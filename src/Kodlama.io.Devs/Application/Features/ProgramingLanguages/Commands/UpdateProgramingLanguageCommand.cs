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
    public class UpdateProgramingLanguageCommand : IRequest<UpdatedProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdatedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            //entity ile dtoları mapler
            private readonly IMapper _mapper;
            // bu entity için kurallarım
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;


            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<UpdatedProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                // istek içinde gelen varlığı sorgula var mı ?
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(p => p.Id == request.Id);
                //yoksa hata gönder.
                _programingLanguageBusinessRules.ProgramingLanguageShouldExistWhenUpdated(programingLanguage);
                //varsa güncelle
                programingLanguage.Name = request.Name;

               //db ye kaydet güncel halini
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(programingLanguage);
                // dto ile maple
                UpdatedProgramingLanguageDto updatedProgramingLanguageDto = _mapper.Map<UpdatedProgramingLanguageDto>(updatedProgramingLanguage);

                return updatedProgramingLanguageDto;
            }
        }
    }
}
