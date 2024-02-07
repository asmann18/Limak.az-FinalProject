﻿using Limak.Application.Abstractions.Services;
using Limak.Application.DTOs.OrderDTOs;
using Limak.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Limak.Presentation.Controllers;

[Route("orders")]
[ApiController]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> GetAllAdminAsync()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost("[action]")]
    [Authorize(Roles ="Member")]
    public async Task<IActionResult> PayOrders([FromForm]List<int> orderIds)
    {
        return Ok(await _service.PayOrders(orderIds));    
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync( OrderPostDto dto)
    {

        return Ok(await _service.CreateAsync(dto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {

        return Ok(await _service.DeleteAsync(id));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] OrderPutDto dto)
    {

        return Ok(await _service.UpdateAsync(dto));
    }
}