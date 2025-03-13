using Entities.DTOs;
namespace Infraestructura.Repository.Interfaces;

public interface IRepository
{
    Task<IEnumerable<UserDTO>> GetUsersAsync();
}
