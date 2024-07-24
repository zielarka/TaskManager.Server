using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Infrastructure.CQRS.Commands.ToDoTask;
using TaskManager.Infrastructure.CQRS.Queries.ToDoTask;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : BaseApiController
    {
        [HttpPost("GetTask")]
        public async Task<ActionResult> GetTask(GetTodoTaskByIdQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost("GetTasks")]
        public async Task<ActionResult> GetTasks(GetAllToDoTaskQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTodoTaskCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTodoTaskCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromBody] DeleteTodoTaskCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
