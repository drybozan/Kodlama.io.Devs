
using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery : IRequest<TechnologyListModel>
    {
        // dataları istiyorum. bir sayfada kaç data gelsin, kaçıncı sayfayı istiyorum vs belirtmek için
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
        {
            // sorgu için 
            private readonly ITechnologyRepository _technologyRepository;

            // varlıklartımı maplemek için
            private readonly IMapper _mapper;


            public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                //index, hangi sayfadayız ; size, o sayfada kaç tane istiyorsun; include:  join için
                IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(
                    include:t=>t.Include(c=>c.ProgramingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                // veritabnın dönen entity'i modele maplemem lazım ki kullanıcıya model gitsin
                TechnologyListModel mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(technologies);

                return mappedTechnologyListModel;
            }
        }
    }
}

