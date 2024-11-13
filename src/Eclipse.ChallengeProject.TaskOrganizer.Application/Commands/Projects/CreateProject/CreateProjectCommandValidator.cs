using FluentValidation;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Commands.Projects.CreateProject;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(item => item.Name)
            .NotEmpty().WithMessage("O nome do projeto não pode ser vazio.")
            .MaximumLength(40).WithMessage("O projeto deve ter no máximo 40 caracteres.");

        RuleFor(item => item.UserId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do usuario não pode ser nulo ou zero.");
    }
}
