using FluentValidation;

namespace Eclipse.ChallengeProject.TaskOrganizer.Domain.Queries.Projects.GetProjectsByUser;

public class GetProjectsByUserQueryValidator : AbstractValidator<GetProjectsByUserQuery>
{
    public GetProjectsByUserQueryValidator()
    {
        RuleFor(item => item.UserId)
            .Must(value => value.HasValue && value.Value != 0)
            .WithMessage("O Id do usuario não pode ser nulo ou zero.");
    }
}
