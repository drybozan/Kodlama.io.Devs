
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

namespace Application.Features.Technologies.Commands
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramingLanguageId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            //entity ile dtoları mapler
            private readonly IMapper _mapper;
            // bu entity için kurallarım
            private readonly TechnologyBusinessRules _technologyBusinessRules;


            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                // istek içinde gelen varlığı sorgula var mı ?
                Technology? technologyLanguage = await _technologyRepository.GetAsync(p => p.Id == request.Id);
                //yoksa hata gönder.
                _technologyBusinessRules.TechnologyShouldExistWhenUpdated(technologyLanguage);
                //varsa güncelle
                technologyLanguage.Name = request.Name;
                technologyLanguage.ProgramingLanguageId = request.ProgramingLanguageId;

                //db ye kaydet güncel halini
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(technologyLanguage);
                // dto ile maple
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);

                return updatedTechnologyDto;
            }
        }
    }
}
