using Data.Entities;

namespace Data.Repositories;

public interface IUserManager
{
    void AutoSignIn();

    void SignIn(User user);

    void SignOut();

    User? CurrentUser { get; }
}
