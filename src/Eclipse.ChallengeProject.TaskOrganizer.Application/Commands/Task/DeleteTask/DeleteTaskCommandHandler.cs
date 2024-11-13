using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.TaskOrganizer.DeleteTaskOrganizer;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Task.DeleteTask;

public class DeleteTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteAsync(request.Id.GetValueOrDefault(), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
