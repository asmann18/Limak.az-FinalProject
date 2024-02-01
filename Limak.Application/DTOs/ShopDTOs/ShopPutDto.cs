﻿using Microsoft.AspNetCore.Http;

namespace Limak.Application.DTOs.ShopDTOs;

public record ShopPutDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ImagePath { get; init; }
    public IFormFile? Image { get; init; }
}
