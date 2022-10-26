using Application.Features.ProgramingLanguages.Commands;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
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
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        // sorgu atacağı için fromquery den alınır parametre
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            // queryi aldık
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };
            // bir model döndürecek, mediator ile query'i ilgili handler'a yolluyorum
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }
    }
}
