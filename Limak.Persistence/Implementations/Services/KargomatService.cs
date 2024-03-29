﻿using AutoMapper;
using Limak.Application.Abstractions.Repositories;
using Limak.Application.Abstractions.Services;
using Limak.Application.DTOs.KargomatDTOs;
using Limak.Application.DTOs.RepsonseDTOs;
using Limak.Domain.Entities;
using Limak.Persistence.Utilities.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace Limak.Persistence.Implementations.Services;

public class KargomatService : IKargomatService
{
    private readonly IKargomatRepository _repository;
    private readonly IMapper _mapper;

    public KargomatService(IKargomatRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResultDto> CreateAsync(KargomatPostDto dto)
    {
        
        var Kargomat = _mapper.Map<Kargomat>(dto);
        await _repository.CreateAsync(Kargomat);
        await _repository.SaveAsync();

        return new($"{Kargomat.Location}-Kargomat is successfully created");
    }

    public async Task<ResultDto> DeleteAsync(int id)
    {
        var Kargomat = await _getKargomat(id);

        _repository.SoftDelete(Kargomat);
        await _repository.SaveAsync();

        return new($"{Kargomat.Location}-Kargomat is successfully deleted");
    }


    public async Task<List<KargomatGetDto>> GetAllAsync()
    {
        var Kargomats = await _repository.GetAll(false).ToListAsync();

        if (Kargomats.Count is 0)
            throw new NotFoundException("Kargomat is not found");

        var dtos = _mapper.Map<List<KargomatGetDto>>(Kargomats);

        return dtos;
    }

    public async Task<KargomatGetDto> GetByIdAsync(int id)
    {
        var Kargomat = await _getKargomat(id);
        var dto = _mapper.Map<KargomatGetDto>(Kargomat);
        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<ResultDto> UpdateAsync(KargomatPutDto dto)
    {
        var existedKargomat = await _getKargomat(dto.Id);
    
        existedKargomat = _mapper.Map(dto, existedKargomat);

        _repository.Update(existedKargomat);
        await _repository.SaveAsync();
        return new($"{existedKargomat.Location}-Kargomat is successfully updated");
    }






    public async Task<List<KargomatGetDto>> GetTrash()
    {
        var kargomats = await _repository.GetFiltered(x => x.IsDeleted, true, "Orders").ToListAsync();
        if (kargomats.Count is 0)
            throw new NotFoundException("Trash is empty");

        var dtos = _mapper.Map<List<KargomatGetDto>>(kargomats);

        return dtos;
    }


    public async Task<ResultDto> RepairDelete(int id)
    {
        var kargomat = await _repository.GetSingleAsync(x => x.Id == id, true);
        if (kargomat is null)
            throw new NotFoundException($"{id}-DeliveryArea is not found");

        _repository.Repair(kargomat);
        await _repository.SaveAsync();

        return new($"{kargomat.Location}-Kargomat is successfully repair");
    }

    private async Task<Kargomat> _getKargomat(int id)
    {
        var Kargomat = await _repository.GetSingleAsync(x => x.Id == id,false, "Orders");
        if (Kargomat is null)
            throw new NotFoundException($"This Kargomat is not found({id})!");
        return Kargomat;
    }
}
