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
    public partial class RegisterForm : Form
    {
        private SqlConnection sqlConnection = null;
        private bool date_picked = false;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Type username!");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Type full name!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Type num of family mebers!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Type password!");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Retype password!");
            }
            else if (!date_picked)
            {
                MessageBox.Show("Choose you date of birth!");
            }
            else if(!(checkBox1.Checked || checkBox2.Checked))
            {
                MessageBox.Show("Your gender!");
            }
            else if (!checkBox3.Checked)
            {
                MessageBox.Show("Agree to terms and conditions");
            }
            else if(!(textBox4.Text == textBox5.Text))
            {
                MessageBox.Show("Passwords are different!");
            }
            else
            {
                string query = "INSERT INTO Users(username, full_name, gender, num_fam_members, birthday, password) VALUES (@username, @full_name, @gender, @num_fam_members, @birthday, @password)";
                SqlCommand newUser = new SqlCommand(query, sqlConnection);
                newUser.Parameters.AddWithValue("@username", textBox1.Text);
                newUser.Parameters.AddWithValue("@full_name", textBox2.Text);
                newUser.Parameters.AddWithValue("@num_fam_members", textBox3.Text);
                newUser.Parameters.AddWithValue("@password", textBox4.Text);
                newUser.Parameters.AddWithValue("@birthday", dateTimePicker1.Value.Date);
                if (checkBox1.Checked) { newUser.Parameters.AddWithValue("gender", 1); }
                else { newUser.Parameters.AddWithValue("@gender", 2); }
                newUser.ExecuteNonQuery();
                MessageBox.Show("Login Succesfull!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date_picked=true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm logF = new LoginForm();

            logF.FormClosed += (s, args) => this.Close();
            logF.Show();
        }
    }
}
