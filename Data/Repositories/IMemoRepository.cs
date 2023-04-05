using Data.Entities;

namespace Data.Repositories;

public interface IMemoRepository : IDataRepository<Memo>
{
    IEnumerable<Memo> GetByDate(User user, DateTime? dateStart = null, DateTime? dateEnd = null);
}
