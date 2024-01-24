using Application.Person.Commands;
using Application.Person.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatorCleanSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("saveUser")]
        public async Task<IActionResult> SaveUser([FromBody] CreatePerson person)
        {
            var result = await _mediator.Send(person);
            return Ok(result);
        }
        [HttpGet]
        [Route("getByID/{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var person = await _mediator.Send(new GetPersonByID { Id = id });
            return Ok(person);
        }
    }
}
