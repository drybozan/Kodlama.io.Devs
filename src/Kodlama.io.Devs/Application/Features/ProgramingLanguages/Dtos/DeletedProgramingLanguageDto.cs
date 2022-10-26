using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Dtos
{
    public class DeletedProgramingLanguageDto
    {
        public string Message { get; }
        public int Id { get; set; }
        public string Name { get; set; }

        public DeletedProgramingLanguageDto()
        {
            Message = "Başarıyla silindi";
        }
    }
}

