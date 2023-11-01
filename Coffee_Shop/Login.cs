using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        int loginAttempts = 0;
        string correctEmail = "admin@gmail.com";
        string correctPassword = "admin";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email and Password cannot be empty.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (email == correctEmail && password == correctPassword)
            {
                MessageBox.Show("Welcome to Coffee Shop", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HomePage coffeeShop = new HomePage();
                coffeeShop.Show();
                this.Hide();
            }
            else
            {
                if(email == correctEmail)
                {
                    MessageBox.Show("Wrong Password.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(password == correctPassword)
                {
                    MessageBox.Show("Wrong Email.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("User doesn't Exist.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                loginAttempts++;

                if(loginAttempts >= 3)
                {
                    MessageBox.Show("You have reached the maximum login attempts.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnLogin.Enabled = false;
                    txtEmail.Enabled = false;
                    txtPassword.Enabled = false;
                }

                txtEmail.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}
