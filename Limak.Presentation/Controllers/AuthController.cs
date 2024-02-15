﻿using Limak.Application.Abstractions.Services;
using Limak.Application.DTOs.AuthDTOs;
using Limak.Application.DTOs.StripeDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Limak.Presentation.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    public AuthController(IAuthService service)
    {
        _service = service;
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        return Ok(await _service.RegisterAsync(dto));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        return Ok(await _service.LoginAsync(dto));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRoles()
    {
        return Ok(await _service.CreateRolesAsync());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        return Ok(await _service.RefreshToken(refreshToken));
    }


    [HttpPost("[action]")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        return Ok(await _service.ChangePasswordAsync(dto));
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto dto)
    {
        return Ok(await _service.ConfirmEmailAsync(dto));
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> ForgetPassword(ForgetPasswordDto dto)
    {
        return Ok(await _service.SendForgetPasswordMail(dto));
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> ResetPassword(ResetPasswordTokenDto dto)
    {
        return Ok(await _service.ResetPasswordAsync(dto));
    }



}
