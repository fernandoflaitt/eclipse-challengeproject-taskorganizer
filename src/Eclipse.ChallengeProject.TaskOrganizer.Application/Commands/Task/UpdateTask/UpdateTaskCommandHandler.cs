using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.UpdateTask;

public class UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async System.Threading.Tasks.Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id.GetValueOrDefault());

        if (task is null) return;

        await _taskRepository.UpdateAsync(task, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
