using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories.MySql;

public abstract class DataRepository<T> : IDataRepository<T> where T : class, IDataItem
{
    protected readonly string _connectionString;

    public DataRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected abstract DbSet<T> GetData(DataContext db);

    public void Add(T item)
    {
        using var db = new DataContext(_connectionString);
        GetData(db).Add(item);
        db.SaveChanges();
    }

    public void Delete(T item)
    {
        using var db = new DataContext(_connectionString);
        GetData(db).Remove(item);
        db.SaveChanges();
    }

    public IEnumerable<T> Get(string? filter = null, string? orderBy = null, string includeProperties = "")
    {
        using var db = new DataContext(_connectionString);
        return GetData(db).ToList();
    }

    public T? GetById(int id)
    {
        using var db = new DataContext(_connectionString);
        return (from item in GetData(db)
                where item.Id == id
                select item).FirstOrDefault();
    }

    public void Update(T item)
    {
        using var db = new DataContext(_connectionString);
        GetData(db).Update(item);
        db.SaveChanges();
    }
}
