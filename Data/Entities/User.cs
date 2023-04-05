using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class User : IDataItem
{
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string Login { get; set; } = null!;

    [StringLength(128)]
    public string Password { get; set; } = null!;

    public UserProfile? UserProfile { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
