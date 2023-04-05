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
    public partial class CreateUserForm : Form
    {
        private const string REQUIRED_FIELD_ERROR_MSG = "Обязательное поле";
        private const string USER_EXISTS_ERROR_MSG = "Пользователь уже существует";
        private const string PASSWORD_MISMATCH_ERROR_MSG = "Пароль и подтверждение не совпадают";

        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(edLogin.Text))
                errorProvider.SetError(edLogin, REQUIRED_FIELD_ERROR_MSG);

            if (String.IsNullOrEmpty(edPassword.Text))
                errorProvider.SetError(edPassword, REQUIRED_FIELD_ERROR_MSG);

            if (String.IsNullOrEmpty(edConfirmPassword.Text))
                errorProvider.SetError(edConfirmPassword, REQUIRED_FIELD_ERROR_MSG);

            if (String.IsNullOrEmpty(edName.Text))
                errorProvider.SetError(edName, REQUIRED_FIELD_ERROR_MSG);

            if (!string.Equals(edPassword.Text, edConfirmPassword.Text))
                errorProvider.SetError(edConfirmPassword, PASSWORD_MISMATCH_ERROR_MSG);

            if (errorProvider.GetError(edLogin) != String.Empty || 
                errorProvider.GetError(edPassword) != String.Empty ||
                errorProvider.GetError(edConfirmPassword) != String.Empty ||
                errorProvider.GetError(edName) != String.Empty)
            {
                return;
            }

            var userRepository = ContainerManager.Instance.GetInstance<IUserRepository>();
            var user = userRepository.GetByLogin(edLogin.Text);

            if (user != null)
            {
                lbError.Text = USER_EXISTS_ERROR_MSG;
                errorProvider.SetError(edLogin, USER_EXISTS_ERROR_MSG);
                edPassword.Text = null;

                return;
            }

            user = new Data.Entities.User()
            {
                Login = edLogin.Text,
                Password = edPassword.Text,
                Name = edName.Text
            };
            userRepository.Add(user);

            DialogResult = DialogResult.OK;
        }
    }
}
