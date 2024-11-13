using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.CreateTask;

public class CreateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTaskCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity(request.Priority, request.Detail, request.ProjectId.GetValueOrDefault(), request.UserId.GetValueOrDefault());

        await _taskRepository.AddAsync(task, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return task;
    }
}
