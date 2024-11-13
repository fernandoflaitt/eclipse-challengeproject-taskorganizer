using Eclipse.ChallengeProject.TaskOrganizer.Domain.Dtos;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Entities;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces;
using Eclipse.ChallengeProject.TaskOrganizer.Domain.Interfaces.Repositories;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new ProjectEntity(request.Name);

        await _projectRepository.AddAsync(project, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return project;
    }
}
