using Data.Repositories;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void miChangeUser_Click(object sender, EventArgs e)
        {
            using var form = new LoginForm();
            form.ShowDialog(this);
        }

        private void miLogOut_Click(object sender, EventArgs e)
        {
            var userManager = ContainerManager.Instance.GetInstance<IUserManager>();
            userManager.SignOut();
        }
    }
}