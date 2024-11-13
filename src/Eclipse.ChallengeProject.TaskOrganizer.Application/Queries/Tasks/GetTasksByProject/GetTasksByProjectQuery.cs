using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Tasks.GetTasksByProject;

public record GetTasksByProjectQuery(int? ProjectId, int? UserId) : IRequest<IEnumerable<TaskDto>>;

