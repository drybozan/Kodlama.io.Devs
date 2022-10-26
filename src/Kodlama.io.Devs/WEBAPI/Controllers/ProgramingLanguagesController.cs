using Application.Features.ProgramingLanguages.Commands;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgLang;
using Application.Features.ProgramingLanguages.Queries.GetListPogLang;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        // sorgu atacağı için fromquery den alınır parametre
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            // queryi aldık
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };
            // bir model döndürecek, mediator ile query'i ilgili handler'a yolluyorum
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }


        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdIdProgramingLanguageQuery)
        {
            ProgramingLanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdIdProgramingLanguageQuery);
            return Ok(languageGetByIdDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            UpdatedProgramingLanguageDto result = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            DeletedProgramingLanguageDto result = await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(result);
        }
    }
}
