namespace Data.Entities;

public class MemoFile : IDataItem
{
    public int Id { get; set; }

    public int MemoId { get; set; }

    public Memo Memo { get; set; }

    public int FileId { get; set; }
}
