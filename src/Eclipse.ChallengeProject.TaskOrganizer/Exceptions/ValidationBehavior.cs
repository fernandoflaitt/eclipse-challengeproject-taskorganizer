﻿using Eclipse.ChallengeProject.TaskOrganizer.Infra.CrossCutting;
using FluentValidation;
using MediatR;

namespace Eclipse.ChallengeProject.TaskOrganizer.Api.Exceptions;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0) if (failures.Count != 0) throw new AppException(failures.Select(x => x.ErrorMessage).ToList());

        return await next();
    }
}
