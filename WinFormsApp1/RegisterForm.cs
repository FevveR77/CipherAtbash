using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            this.LoginField.AutoSize = false;
            this.LoginField.Size = new Size(this.LoginField.Size.Width, 64);
            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.PassField.Size.Width, 64);

            LoginField.Text = "Введите логин";
            LoginField.ForeColor = Color.Gray;
            PassField.Text = "Введите пар";
            PassField.ForeColor = Color.Gray;

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.ForeColor = Color.White;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.ForeColor = Color.Black;
        }
        Point lastpoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
                
        }

        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Введите логин";
                LoginField.ForeColor = Color.Gray;
            }
                
        }

        private void PassField_Enter(object sender, EventArgs e)
        {
            if (PassField.Text == "Введите пар")
            {
                PassField.Text = "";
                PassField.ForeColor = Color.Black;
            }
        }

        private void PassField_Leave(object sender, EventArgs e)
        {
            if (PassField.Text == "")
            {
                PassField.Text = "Введите пар";
                PassField.ForeColor = Color.Gray;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(LoginField.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (PassField.Text == "Введите пар")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`) VALUES (@login, @pass)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт зарегистрирован");
            else
                MessageBox.Show("Аккаунт не зарегистрирован");

            db.closeConnection();
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин уже используется, введите иной");
                return true;
            }
            else
                return false;
        }

        private void registerlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
