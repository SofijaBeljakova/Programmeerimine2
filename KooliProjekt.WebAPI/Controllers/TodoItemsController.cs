using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.TodoItems;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/todoitems")]
    public class TodoItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/files")]
        public async Task<IActionResult> ListFiles(int id)
        {
            var query = new ListFilesQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.HasErrors)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }

        [HttpPost("{id}/files")]
        public async Task<IActionResult> AddFile(int id, [FromForm] AddFileCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpDelete("{id}/files")]
        public async Task<IActionResult> DeleteFile(int id, [FromQuery] string fileName)
        {
            var command = new DeleteFileCommand { Id = id, FileName = fileName };
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}