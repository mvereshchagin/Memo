using Data.Entities;
using Data.Repositories;

namespace DbRepositories.MySql;

public class UserManager : IUserManager
{
    private readonly string _fileName;
    private User? _currentUser;
    private readonly IUserRepository _userRepository;

    public UserManager(string fileName, IUserRepository userRepository)
    {
        _fileName = fileName;
        _userRepository = userRepository;
    }

    public User? CurrentUser => _currentUser;

    public void AutoSignIn()
    {
        try
        {
            var strId = File.ReadAllText(_fileName);
            int id = Int32.Parse(strId);
            var user = _userRepository.GetById(id);
            _currentUser = user;
        }
        catch
        {

        }
    }

    public void SignIn(User user)
    {
        try
        {
            File.WriteAllText(_fileName, user.Id.ToString());
            _currentUser = user;
        }
        catch
        {

        }
    }

    public void SignOut()
    {
        try
        {
            File.WriteAllText(_fileName, "");
            _currentUser = null;
        }
        catch
        {

        }
    }
}
