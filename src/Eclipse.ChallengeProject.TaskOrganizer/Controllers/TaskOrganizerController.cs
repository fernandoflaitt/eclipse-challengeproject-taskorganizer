using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.TaskOrganizer.DeleteTaskOrganizer;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.CreateTask;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.UpdateTask;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Tasks.GetTasksByProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eclipse.ChallengeProject.TaskOrganizer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskOrganizerController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("project/{projectId}user/{userId}")]
    public async Task<ActionResult<int>> Create([FromQuery] int? projectId, [FromQuery] int? userId, [FromBody] CreateTaskCommand command)
    {
        command.SetUserId(userId);
        command.SetProjectId(userId);

        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}/user/{userId}")]
    public async Task<ActionResult> Update([FromQuery] int? id, [FromQuery] int? userId, [FromBody] UpdateTaskCommand command)
    {
        command.SetId(id);
        command.SetUserId(userId);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}/user/{userId}")]
    public async Task<ActionResult> Delete([FromQuery] int? id, [FromQuery] int? userId)
    {
        await _mediator.Send(new DeleteTaskCommand(id, userId));
        return NoContent();
    }

    [HttpGet("project/{projectId}/user/{userId}")]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetByProject([FromQuery] int? projectId, [FromQuery] int? userId)
    {
        return Ok(await _mediator.Send(new GetTasksByProjectQuery(projectId, userId)));
    }
}
