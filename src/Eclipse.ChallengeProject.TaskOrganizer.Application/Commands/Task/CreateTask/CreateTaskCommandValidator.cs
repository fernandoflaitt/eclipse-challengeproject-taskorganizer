using FluentValidation;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Tasks.CreateTask;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(item => item.Detail)
        .NotEmpty().WithMessage("O detalhamento da tarefa não pode ser vazio.")
        .MaximumLength(40).WithMessage("O detalhamento da tarefa deve ter no máximo 40 caracteres.");

        RuleFor(item => item.UserId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do usuario não pode ser nulo ou zero.");

        RuleFor(item => item.ProjectId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do projeto não pode ser nulo ou zero.");
    }
}
