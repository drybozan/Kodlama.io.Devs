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

        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(p => p.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programlama dili mevcut.");
        }


   
        public void ProgramingLanguageShouldExistWhenRequested(ProgramingLanguage language)
        {
            if (language == null) throw new BusinessException("İstenilen dil mevcut değil.");
        }
    }
}
