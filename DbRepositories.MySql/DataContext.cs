using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories.MySql;

public class DataContext : DbContext
{
    private readonly string _connectionString;

    public DataContext(string connectionString)
    {
        _connectionString = connectionString;
        Database.EnsureCreated();
    }

    #region Entities
    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    //public DbSet<Memo> Memos => Set<Memo>();

    //public DbSet<MemoFile> MemoFiles => Set<MemoFile>();

    //public DbSet<SavedFile> SavedFiles => Set<SavedFile>();
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = ServerVersion.AutoDetect(_connectionString);
        optionsBuilder.UseMySql(_connectionString, serverVersion);
    }
}

