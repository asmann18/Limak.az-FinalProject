﻿using Limak.Application.DTOs.RepsonseDTOs;
using Limak.Application.DTOs.TariffDTOs;

namespace Limak.Application.Abstractions.Services;

public interface ITariffService
{
    Task<List<TariffGetDto>> GetAllAsync();
    Task<TariffGetDto> GetByIdAsync(int id);
    Task<ResultDto> CreateAsync(TariffPostDto dto);
    Task<ResultDto> UpdateAsync(TariffPutDto dto);
    Task<bool> IsExistAsync(int id);
    Task<ResultDto> DeleteAsync(int id);
    Task<TariffGetDto> GetTariffByWeight(decimal weight,int countryId);
    Task<List<TariffGetDto>> GetTrash();
    Task<ResultDto> RepairDelete(int id);
}
