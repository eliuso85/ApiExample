using Aplicacion.Interfaces;
using Aplicacion.Services;
using Entities.Response;
using Microsoft.AspNetCore.Mvc;
namespace ApiExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUsersService itemService) : ControllerBase
{

    #region GET
    [HttpGet]
    [Route("GetAll")]
    public async Task<ResponseApi> GetAllUsers()
          => await itemService.GetAllUsersAsync();
    #endregion

    #region Post
    #endregion

    #region Put
    #endregion

    #region Delete
    #endregion
    
}
