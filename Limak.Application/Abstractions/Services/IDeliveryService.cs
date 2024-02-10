﻿using Limak.Application.DTOs.DeliveryDTOs;
using Limak.Application.DTOs.RepsonseDTOs;

namespace Limak.Application.Abstractions.Services;

public interface IDeliveryService
{
    Task<ResultDto> CreateDelivery(DeliveryPostDto dto);
    Task<ResultDto> CancelDelivery(int id);
}
