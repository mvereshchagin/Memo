using Data.Repositories;
using DbRepositories.MySql;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace WinFormsApp;

internal static class ContainerManager
{
    private static readonly Lazy<Container> _container = new(Configure);

    public static Container Instance => _container.Value;

    private static Container Configure()
    {
        var container = new Container();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appconfig.json")
            .Build();

        var connectionString = config.GetConnectionString("Default");

        container.Register<IUserRepository>(() => new UserRepository(connectionString!), Lifestyle.Transient);
        container.Register<IUserManager>(() => new UserManager("auth.txt", new UserRepository(connectionString!)),
            Lifestyle.Transient);

        container.Verify();

        return container;
    }
}
