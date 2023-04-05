using Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class LoginForm : Form
    {
        private const string REQUIRED_FIELD_ERROR_MSG = "Обязательное поле";
        private const string USER_NOT_FOUND_ERROR_MSG = "Пользователь не найден";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(edLogin.Text))
                errorProvider.SetError(edLogin, REQUIRED_FIELD_ERROR_MSG);

            if (String.IsNullOrEmpty(edPassword.Text))
                errorProvider.SetError(edPassword, REQUIRED_FIELD_ERROR_MSG);

            if (errorProvider.GetError(edLogin) != String.Empty || 
                errorProvider.GetError(edPassword) != String.Empty)
            {
                return;
            }

            var userRepository = ContainerManager.Instance.GetInstance<IUserRepository>();
            var user = userRepository.GetByLoginAndPassword(edLogin.Text, edPassword.Text);

            if (user == null)
            {
                lbError.Text = USER_NOT_FOUND_ERROR_MSG;
                errorProvider.SetError(edLogin, USER_NOT_FOUND_ERROR_MSG);
                edPassword.Text = null;

                return;
            }

            var userManager = ContainerManager.Instance.GetInstance<IUserManager>();
            userManager.SignIn(user);

            DialogResult = DialogResult.OK;
        }

        private void linkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new CreateUserForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}
