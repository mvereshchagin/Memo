namespace Data.Entities;

public class SavedFile : IDataItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public byte[] Content { get; set; } = null!;
}
