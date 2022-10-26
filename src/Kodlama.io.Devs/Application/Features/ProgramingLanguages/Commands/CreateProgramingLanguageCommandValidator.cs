using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands
{
    // AbstractValidator, FluentValidationun aracıdır.
    // hangi command için validation kullanılacağı belirtmek gerek
    public class CreateProgramingLanguageCommandValidator : AbstractValidator<CreateProgramingLanguageCommand>
    {
        // add işlemi için kullanılan validator.
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
