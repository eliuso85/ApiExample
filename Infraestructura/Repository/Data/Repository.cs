using Dapper;
using Entities.DTOs;
using Infraestructura.Repository.Interfaces;
using System.Data;

namespace Infraestructura.Repository.Data;

public class Repository(IDbConnection sqlConn) : IRepository
{
    private readonly IDbConnection _sqlConn = sqlConn;

    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        return await _sqlConn.QueryAsync<UserDTO>("[dbo].sp_GetUsers ");
    }
}
