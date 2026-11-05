using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using KooliProjekt.Application.Features.TodoLists;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveTodoListCommand command)
        {
            command.Id = 0; 
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveTodoListCommand command)
        {
            command.Id = id; 
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTodoListCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

       
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListTodoListsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }



    }
}