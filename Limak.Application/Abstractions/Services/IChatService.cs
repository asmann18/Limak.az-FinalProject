﻿using Limak.Application.DTOs.ChatDTOs;
using Limak.Application.DTOs.RepsonseDTOs;

namespace Limak.Application.Abstractions.Services;

public interface IChatService
{
    Task<ResultDto> CreateAsync();

    Task<bool> IsExistAsync(int id);
    Task<ResultDto> UpdateAsync(ChatPutDto dto);
    Task<ResultDto> SetOperatorAsync(int chatId);
    Task<ChatGetDto> GetByIdAsync(int id);
    Task<List<ChatGetDto>> GetAll();
    Task<ChatGetDto> GetOnlineChatAsync();
    Task<List<ChatGetDto>> GetWithoutAnOperatorChats();
}
