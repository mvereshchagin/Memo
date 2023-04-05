using ConsoleApp;
using Data.Entities;
using Data.Repositories;
using Utils;


var console = ContainerManager.Instance.GetInstance<IConsole>();
var consoleUtils = new ConsoleUtils(console);
var userManger = ContainerManager.Instance.GetInstance<IUserManager>();
var userRepository = ContainerManager.Instance.GetInstance<IUserRepository>();

SetupUser();

void SetupUser()
{
    userManger.AutoSignIn();

    var currentUser = userManger!.CurrentUser;

    if (currentUser is not null)
        return;

    console.WriteLine("User is not authorized");
    do
    {
        var choice = consoleUtils.ReadInt(question: "Select Sign in (1), Sign up(2)");
        switch (choice)
        {
            case 1:
                if (!DoSignIn())
                    continue;
                break;
            case 2:
                if (!DoSignUp())
                    continue;
                break;
        }
    }
    while (true);
}

bool DoSignIn()
{
    var login = consoleUtils.ReadString(question: "login", allowEmpty: false);
    var password = consoleUtils.ReadString(question: "login", allowEmpty: false);
    var user = userRepository!.GetByLoginAndPassword(login!, password!);
    if (user is null)
    {
        console.WriteLine("User is not found");
        return false;
    }
    userManger.SignIn(user);
    return true;
}

bool DoSignUp()
{
    do
    {
        var name = consoleUtils.ReadString(question: "name", allowEmpty: false);
        var login = consoleUtils.ReadString(question: "login", allowEmpty: false);
        var password = consoleUtils.ReadString(question: "password", allowEmpty: false);
        var password2 = consoleUtils.ReadString(question: "confirm password", allowEmpty: false);
        if (!String.Equals(password, password2))
        {
            console.WriteLine("Password mismatch");
            continue;
        }

        var user = userRepository.GetByLogin(login!);
        if(user is not null)
        {
            console.WriteLine("A user with such login already exists");
            continue;
        }

        user = new User()
        {
            Name = name!,
            Login = login!,
            Password = password!,
        };
        userRepository.Add(user);
        userManger.SignIn(user);

        return true;
    }
    while (true);
}



