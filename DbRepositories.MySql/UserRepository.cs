using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories.MySql;

public class UserRepository : DataRepository<User>, IUserRepository
{
    public UserRepository(string connectionString) : base(connectionString)
    { }

    public User? GetByLogin(string login)
    {
        using var db = new DataContext(_connectionString);
        return (from user in GetData(db)
                where user.Login == login
                select user).FirstOrDefault();
    }

    public User? GetByLoginAndPassword(string login, string password)
    {
        using var db = new DataContext(_connectionString);
        return (from user in GetData(db)
                where user.Login == login && user.Password == password
                select user).FirstOrDefault();
    }

    protected override DbSet<User> GetData(DataContext db) => db.Users;
}
