using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Projects.CreateProject;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Projects.GetProjectsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eclipse.ChallengeProject.TaskOrganizer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController(IMediator mediator) : ControllerBase
{
    [HttpPost("user/{userId}")]
    public async Task<ActionResult<int>> Create([FromQuery] int? userId, [FromBody] CreateProjectCommand command)
    {
        command.SetUserId(userId);

        return Ok(await mediator.Send(command));
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetByUser([FromQuery] int? userId)
    {
        return Ok(await mediator.Send(new GetProjectsByUserQuery(userId)));
    }
}
