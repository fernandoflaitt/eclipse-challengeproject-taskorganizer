using Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.UpdateTask;
using FluentValidation;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Task.UpdateTask;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(item => item.Detail)
        .NotEmpty().WithMessage("O detalhamento da tarefa não pode ser vazio.")
        .MaximumLength(40).WithMessage("O detalhamento da tarefa deve ter no máximo 40 caracteres.");

        RuleFor(item => item.UserId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do usuario não pode ser nulo ou zero.");

        RuleFor(item => item.Id)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id não pode ser nulo ou zero.");
    }
}
