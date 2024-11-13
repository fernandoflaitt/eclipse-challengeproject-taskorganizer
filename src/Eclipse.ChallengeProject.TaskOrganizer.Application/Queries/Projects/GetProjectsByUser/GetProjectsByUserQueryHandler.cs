using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Projects.GetProjectsByUser;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Projects.GetTasksByProject;

public class GetProjectsByUserQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetProjectsByUserQuery, IEnumerable<ProjectDto>>
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsByUserQuery request, CancellationToken cancellationToken)
    {
        var list = await _projectRepository.GetByUserAsync(request.UserId.GetValueOrDefault(), cancellationToken);

        if (list is null) return Enumerable.Empty<ProjectDto>();

        return list.Select(item => (ProjectDto)item);
    }
}
