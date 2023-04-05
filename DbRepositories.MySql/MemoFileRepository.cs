using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories.MySql;

public class MemoFileRepository : DataRepository<MemoFile>, IMemoFileRepository
{
    public MemoFileRepository(string connectionString) : base(connectionString)
    {
    }

    protected override DbSet<MemoFile> GetData(DataContext db)
    {
        throw new NotImplementedException();
        // return db.MemoFiles;
    }
}
