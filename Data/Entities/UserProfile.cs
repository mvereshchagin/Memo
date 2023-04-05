using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UserProfile : IDataItem
{
    public int Id { get; set; }


    public int? UserId { get; set; }
    public User? User { get; set; } = null!;

    [StringLength(32)]
    public string? Phone { get; set; }

    [StringLength(32)]
    public string? Email { get; set; }

    public Gender Gender { get; set; }
}
