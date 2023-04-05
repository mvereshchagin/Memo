using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories.MySql;

public class SavedFileRepository : DataRepository<SavedFile>, ISavedFileRepository
{
    public SavedFileRepository(string connectionString) : base(connectionString)
    {
    }

    protected override DbSet<SavedFile> GetData(DataContext db)
    {
        throw new NotImplementedException();
    }
}
