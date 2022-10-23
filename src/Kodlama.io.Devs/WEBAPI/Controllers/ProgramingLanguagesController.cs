using Application.Features.ProgramingLanguages.Commands;
using Application.Features.ProgramingLanguages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
    }
}
