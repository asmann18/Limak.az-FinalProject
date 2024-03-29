﻿using Limak.Application.Abstractions.Services;
using Limak.Application.DTOs.AuthDTOs;
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


    #region onlyDevelopment
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAdminToken()
    {
        return Ok(await _service.LoginAsync(new() {Email="admin@gmail.com",Password="Admin2003" }));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetMemberToken()
    {
        return Ok(await _service.LoginAsync(new() { Email = "asimanjg@code.edu.az", Password = "Admin2003" }));
    }
    #endregion



    [HttpGet("[action]")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        return Ok(await _service.GetCurrentUserAsync());
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
    public async Task<IActionResult> ForgetPassword(ForgetPasswordDto dto)
    {
        return Ok(await _service.SendForgetPasswordMail(dto));
    }


    [HttpPut("[action]")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        return Ok(await _service.ChangePasswordAsync(dto));
    }



    [HttpPut("[action]")]
    public async Task<IActionResult> ResetPassword(ResetPasswordTokenDto dto)
    {
        return Ok(await _service.ResetPasswordAsync(dto));
    }



    


    [HttpPut("[action]")]
    [Authorize]
    public async Task<IActionResult> EditUserAccountDatas(AppUserAccountDataPutDto dto)
    {
        return Ok(await _service.EditUserAccountDatas(dto));
    }



    [HttpPut("[action]")]
    [Authorize]
    public async Task<IActionResult> EditUserPersonalDatas(AppUserPersonalDataPutDto dto)
    {
        return Ok(await _service.EditUserPersonalDatas(dto));
    }




    [HttpPatch("[action]")]
    [Authorize]
    public async Task<IActionResult> ChangeEmail(ChangeEmailDto dto)
    {
        return Ok(await _service.ChangeEmailAsync(dto));
    }




    [HttpPatch("[action]")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto dto)
    {
        return Ok(await _service.ConfirmEmailAsync(dto));
    }

    [HttpPatch("[action]")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        return Ok(await _service.RefreshToken(refreshToken));
    }


    [HttpGet("[action]/{id}")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> GetUserById([FromRoute]int id)
    {
        return Ok(await _service.GetUserByIdAsync(id));
    }


    [HttpGet("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers([FromQuery]string? search)
    {
        return Ok(await _service.GetAllUsersAsync(search));
    }

    [HttpPut("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeUserRole(ChangeRoleDto dto)
    {
        return Ok(await _service.ChangeUserRoleAsync(dto));
    }



    [HttpPut("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeUserPassword(ChangePasswordByAdminDto dto)
    {
        return Ok(await _service.ChangePasswordByAdminAsync(dto));
    }


    [HttpGet("[action]")]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> FindByFincode(string fincode)
    {
        return Ok(await _service.FindByFincode(fincode));
    }
}
