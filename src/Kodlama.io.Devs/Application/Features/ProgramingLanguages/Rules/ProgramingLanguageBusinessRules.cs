using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        private IProgramingLanguageRepository _programingLanguageRepository;

        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            this._programingLanguageRepository = programingLanguageRepository;
        }

        // varlık, db de zaten varsa uyar
        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(p => p.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programlama dili mevcut.");
        }


        // istenilen varlık yoksa uyar
        public void ProgramingLanguageShouldExistWhenRequested(ProgramingLanguage language)
        {
            if (language == null) throw new BusinessException("İstenilen dil mevcut değil.");
        }
        // istenilen varlık yoksa uyar
        public void ProgramingLanguageShouldExistWhenUpdated(ProgramingLanguage language)
        {
            if (language == null) throw new BusinessException("Güncellemek istediğiniz dil mevcut değil.");
        }

        public void ProgramingLanguageShouldExistWhenDeleteRequested(ProgramingLanguage language)
        {
            if (language == null) throw new BusinessException("Silmek istediğiniz dil mevcut değil.");
        }


    }
}
