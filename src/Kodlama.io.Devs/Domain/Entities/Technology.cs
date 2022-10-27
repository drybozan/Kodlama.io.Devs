using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology:Entity
    {
       public string Name { get; set; }
       public int ProgramingLanguageId { get; set; }
        //1-n
       public virtual ProgramingLanguage? ProgramingLanguage { get; set; }


        public Technology()
        {
        }

        public Technology(int id, int programingLanguageId, string name) :this()
        {
            Id = id;
            Name = name;
            ProgramingLanguageId = programingLanguageId;
            
        }

        
    }
}
