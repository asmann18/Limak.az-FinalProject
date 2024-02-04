﻿using FluentValidation;
using Limak.Application.DTOs.UserPositionDTOs;

namespace Limak.Application.Validators.UserPositionValidators;

public class UserPositionPutDtoValidator:AbstractValidator<UserPositionPutDto>
{
    public UserPositionPutDtoValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotNull().MaximumLength(64).MinimumLength(3);

    }
}
