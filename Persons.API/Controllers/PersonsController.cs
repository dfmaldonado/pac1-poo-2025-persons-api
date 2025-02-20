using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Persons.API.Database.Entities;
using Persons.API.Dtos.Common;
using Persons.API.Dtos.Persons;
using Persons.API.Services.Interfaces;

namespace Persons.API.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<PersonDto>>>> GetList ()
        {
            var response = await _personsService.GetListAsync();

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }


        [HttpGet ("{id}")]
        public async Task<ActionResult<ResponseDto<PersonDto>>> GetOne(Guid id)
        {
            var response = await _personsService.GetOnebyIdAsync (id);

            return StatusCode(response.StatusCode, response);
        }
 
        [HttpPost]

        public async Task<ActionResult<ResponseDto<PersonActionResponseDto>>> Post([FromBody] PersonCreateDto person)
        {
            var response = await _personsService.CreateAsync(person);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<ResponseDto<PersonActionResponseDto>>> Delete(Guid id)
        {
            var reponse = await _personsService.DeleteAsync(id);
            return StatusCode(Response.StatusCode, reponse);
        }
    
    }

}


