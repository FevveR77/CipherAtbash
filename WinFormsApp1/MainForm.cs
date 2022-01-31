using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        //алфавит языка
        private const string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        private void button1_Click(object sender, EventArgs e)
        {
            char [] s = TextWrite.Text.ToCharArray();
            string text = "";
            for (int i = 0; i < (s.Length); i++)
            {
                s[i] = alphabet[alphabet.Length - alphabet.IndexOf(s[i]) - 1];
                text += s[i];
            }
            TextResult.Text = text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char[] s = TextWrite.Text.ToCharArray();
            string text = "";
            for (int i = 0; i < (s.Length); i++)
            {
                s[i] = alphabet[alphabet.Length - alphabet.IndexOf(s[i]) - 1];
                text += s[i];
            }
            TextResult.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(TextResult.Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\users\\nonam\\Desktop";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Получить путь к указанному файлу
                    filePath = openFileDialog.FileName;
                    //Считывание содержимого файла в поток
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        TextResult.Text = "";
                    }   
                }
            }
            TextWrite.Text = fileContent;
        }
    }
}
