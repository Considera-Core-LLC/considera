using System.ComponentModel.DataAnnotations;

namespace ConsideraDevApi.Core.Interfaces;

public interface IEntity
{
    public Guid Id { get; set; }
}