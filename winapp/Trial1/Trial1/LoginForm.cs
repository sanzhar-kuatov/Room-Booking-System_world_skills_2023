using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial1
{
    public partial class LoginForm : Form
    {
        private SqlConnection sqlConnection = null;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == "" || textBox2.Text == ""))
            {
                MessageBox.Show("Fill the emplyee or username");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Type the password");
            }
            else
            {
                string query = "SELECT id FROM Users WHERE username = @username and password = @password";
                SqlDataReader readUsers = null;

                try
                {
                    SqlCommand checkUser = new SqlCommand(query, sqlConnection);
                    if (textBox1.Text != "") { checkUser.Parameters.AddWithValue("@username", textBox1.Text); }
                    else { checkUser.Parameters.AddWithValue("username", textBox2.Text); }
                    checkUser.Parameters.AddWithValue("@password", textBox3.Text);

                    readUsers = checkUser.ExecuteReader();

                    if (readUsers.Read()) {
                        int userId = readUsers.GetInt32(0);
                        this.Hide();

                        MainForm mainF = new MainForm(userId);

                        mainF.FormClosed += (s, args) => this.Close();
                        mainF.Show();
                    }
                    else { MessageBox.Show("Wrong password or login"); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (readUsers != null && !readUsers.IsClosed) { readUsers.Close(); } }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            RegisterForm regF = new RegisterForm();

            regF.FormClosed += (s, args) => this.Close();
            regF.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '*';
            }
        }
    }
}
