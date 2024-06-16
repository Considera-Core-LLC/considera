namespace ConsideraDevApi.Core.Models.MusiqueHub.DTO;

public interface IDto<T, TDto>
{
    public T MapTo(TDto objDto);
    public TDto MapFrom(T obj);
}