namespace Data.Entities;

public class Memo : IDataItem
{
    public int Id { get; set; }

    public DateTime DateCreate { get; set; }

    public string? Content { get; set; } = null!;

    public string Title { get; set; } = null!;
  
    public DateTime? DateTime { get; set; }

    public Importance Importance { get; set; }

    public List<MemoFile> Files { get; set; } = new();
}
