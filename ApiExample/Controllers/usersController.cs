using Aplicacion.Interfaces;
using Aplicacion.Services;
using Entities.Response;
using Microsoft.AspNetCore.Mvc;
namespace ApiExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class usersController : ControllerBase
{
    private readonly IUsersService _itemService;

    public usersController(IUsersService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ResponseApi> GetAllUsers()
        => await _itemService.GetAllUsersAsync();

}
