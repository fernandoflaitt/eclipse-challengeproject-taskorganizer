using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.TaskOrganizer.DeleteTaskOrganizer;

public record DeleteTaskCommand(int? Id, int? UserId) : IRequest;
