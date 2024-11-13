using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Projects.GetProjectsByUser;

public record GetProjectsByUserQuery(int? UserId) : IRequest<IEnumerable<ProjectDto>>;
