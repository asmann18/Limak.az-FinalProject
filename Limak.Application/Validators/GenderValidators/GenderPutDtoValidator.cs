﻿using FluentValidation;
using Limak.Application.DTOs.GenderDTOs;

namespace Limak.Application.Validators.GenderValidators;

public class GenderPutDtoValidator:AbstractValidator<GenderPutDto>
{
    public GenderPutDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.Name).NotNull().MaximumLength(64).MinimumLength(2); 
    }
}
