﻿using FluentValidation;
using Limak.Application.DTOs.StatusDTOs;

namespace Limak.Application.Validators.StatusValidators;

public class StatusPutDtoValidator : AbstractValidator<StatusPutDto>
{
    public StatusPutDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.Name).NotNull().MaximumLength(128).MinimumLength(2);
    }
}
