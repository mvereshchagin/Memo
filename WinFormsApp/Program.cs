using Data.Repositories;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var userManager = ContainerManager.Instance.GetInstance<IUserManager>();
            userManager.AutoSignIn();

            if (userManager.CurrentUser == null)
            {
                using(var form = new LoginForm())
                {
                    if (form.ShowDialog() != DialogResult.OK)
                        Application.Exit();
                }
            }


            Application.Run(new MainForm());
        }
    }
}