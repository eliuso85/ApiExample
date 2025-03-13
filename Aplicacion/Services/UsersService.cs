using Aplicacion.Interfaces;
using Entities.Response;
using Infraestructura.Repository.Interfaces;

namespace Aplicacion.Services;

public class UsersService(IRepository _itemRepository) : IUsersService
{
    #region Buider
    private readonly ResponseApi response = new();
    #endregion
    public async Task<ResponseApi> GetAllUsersAsync()
    {
        try
        {
            response.Data = await _itemRepository.GetUsersAsync();
            response.Success = true;
            response.Mensajes.Add("Generada correctamente la lista de Usuarios");
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Mensajes.Add(ex.Message);
        }
        return response;
    }
}
