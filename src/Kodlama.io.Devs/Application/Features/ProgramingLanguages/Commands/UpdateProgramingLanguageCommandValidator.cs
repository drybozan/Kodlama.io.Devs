using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands
{
    public class UpdateProgramingLanguageCommandValidator : AbstractValidator<UpdateProgramingLanguageCommand>
    {
        //update işlemi için kullanılan validator.
        public UpdateProgramingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
