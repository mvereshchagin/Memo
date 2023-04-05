using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories.MySql;

public class MemoRepository : DataRepository<Memo>, IMemoRepository
{
    public MemoRepository(string connectionString) : base(connectionString)
    {
    }

    public IEnumerable<Memo> GetByDate(User user, DateTime? dateStart = null, DateTime? dateEnd = null)
    {
        throw new NotImplementedException();
    }

    protected override DbSet<Memo> GetData(DataContext db)
    {
        throw new NotImplementedException();
        // return db.Memos;
    }
}
