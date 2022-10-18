using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    // Entitiye özel repolar burda tanımlanır. Tüm metotlar IAsyncRepository ve IRepository içinde tanımlı gövdeleri ise EfRepositoryBase içinde tanımlı
    public interface IProgramingLanguageRepository: IAsyncRepository<ProgramingLanguage>, IRepository<ProgramingLanguage>
    {
    }
}
