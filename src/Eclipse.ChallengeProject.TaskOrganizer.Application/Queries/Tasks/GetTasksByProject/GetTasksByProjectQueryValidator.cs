using FluentValidation;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Tasks.GetTasksByProject;

public class GetTasksByProjectQueryValidator : AbstractValidator<GetTasksByProjectQuery>
{
    public GetTasksByProjectQueryValidator()
    {
        RuleFor(item => item.UserId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do usuario não pode ser nulo ou zero.");

        RuleFor(item => item.ProjectId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do projeto não pode ser nulo ou zero.");
    }
}