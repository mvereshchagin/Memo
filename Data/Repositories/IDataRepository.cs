namespace Data.Repositories;

public interface IDataRepository<T>
{
    void Add(T item);

    void Update(T item);

    void Delete(T item);

    IEnumerable<T> Get(
        string? filter = null, 
        string? orderBy = null,
        string includeProperties = "");

    T? GetById(int id);
}
