using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Tasks.GetTasksByProject;

public class GetTasksByProjectQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTasksByProjectQuery, IEnumerable<TaskDto>>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<TaskDto>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
    {
        var list = await _taskRepository.GetByProjectAsync(request.ProjectId.GetValueOrDefault(), cancellationToken);

        if (list is null) return [];

        return list.Select(item => (TaskDto)item);
    }
}
