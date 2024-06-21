using Considera.Api.Core.Models.MusiqueHub.DTO;

namespace Considera.Api.Core.Interfaces.MusiqueHub.Services;

public interface IService<in TDto> where TDto : IDto
{
    Task Add(TDto dto);
}