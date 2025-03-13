using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required DateTime Creation_date { get; set; }
    public required bool Active { get; set; }
}
