using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
   public class DeletedTechnologyDto
    {
        public string Message { get; }
        public int Id { get; set; }
        public string Name { get; set; }

        public DeletedTechnologyDto()
        {
            Message = "Başarıyla silindi";
        }
    }
}

