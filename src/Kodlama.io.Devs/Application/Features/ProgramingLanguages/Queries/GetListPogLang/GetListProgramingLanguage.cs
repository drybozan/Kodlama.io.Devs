using Application.Features.ProgramingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetListPogLang
{
    public class GetListProgramingLanguageQuery:IRequest<ProgramingLanguageListModel>
    {
        // dataları istiyorum. bir sayfada kaç data gelsin, kaçıncı sayfayı istiyorum vs belirtmek için
        public PageRequest PageRequest { get; set; }

        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            // sorgu için 
            private readonly IProgramingLanguageRepository _programingLanguageRepository;

            // varlıklartımı maplemek için
            private readonly IMapper _mapper;


            public GetListProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                //index, hangi sayfadayız ; size, o sayfada kaç tane istiyorsun
                IPaginate<ProgramingLanguage> languages = await _programingLanguageRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                // veritabnın dönen entity'i modele maplemem lazım ki kullanıcıya model gitsin
                ProgramingLanguageListModel mappedProgramingLanguageListModel = _mapper.Map<ProgramingLanguageListModel>(languages);

                return mappedProgramingLanguageListModel;
            }
        }
    }
}
