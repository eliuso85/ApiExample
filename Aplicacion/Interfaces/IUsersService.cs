namespace Aplicacion.Interfaces;

using Entities.Response;

public interface IUsersService
{
    Task<ResponseApi> GetAllUsersAsync();
}
