using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            this._technologyRepository = technologyRepository;
        }

        // varlık, db de zaten varsa uyar
        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(p => p.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programlama diline ait teknoloji mevcut.");
        }


        // istenilen varlık yoksa uyar
        public void TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("İstenilen teknoloji mevcut değil.");
        }
        // istenilen varlık yoksa uyar
        public void TechnologyShouldExistWhenUpdated(Technology technology)
        {
            if (technology == null) throw new BusinessException("Güncellemek istediğiniz teknoloji mevcut değil.");
        }

        public void TechnologyShouldExistWhenDeleteRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Silmek istediğiniz teknoloji mevcut değil.");
        }


    }
}
