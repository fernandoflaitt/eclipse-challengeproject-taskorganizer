using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.TaskOrganizer.DeleteTaskOrganizer;
using FluentValidation;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Task.DeleteTask;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(item => item.UserId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do usuario não pode ser nulo ou zero.");

        RuleFor(item => item.Id)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id não pode ser nulo ou zero.");
    }
}
