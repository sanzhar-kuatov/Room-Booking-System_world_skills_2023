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
    public partial class MainForm : Form
    {
        private SqlConnection sqlConnection = null;
        private DataSet dataSet = new DataSet();
        private DataSet dataSet2 = new DataSet();
        private int user_id = 0;
        public MainForm(int userid)
        {
            user_id = userid;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT title, capacity, apxm_address AS area, (SELECT name FROM Types WHERE id = type) as type FROM Hotels", sqlConnection);
            dataAdapter.Fill(dataSet);



            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(
                "SELECT id, title, capacity, apxm_address AS area, (SELECT name FROM Types WHERE id = type) as type FROM Hotels WHERE user_created = @userid", sqlConnection);

            dataAdapter2.SelectCommand.Parameters.Clear();
            dataAdapter2.SelectCommand.Parameters.AddWithValue("@userid", user_id);

            dataAdapter2.Fill(dataSet2);

            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = dataSet2.Tables[0];


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT title, capacity, apxm_address AS area, (SELECT name FROM Types WHERE id = type) as type FROM Hotels WHERE (title LIKE @search)", sqlConnection); //OR (SELECT id FROM Types WHERE name LIKE @search) = type

            dataSet.Clear();
            dataAdapter.SelectCommand.Parameters.Clear();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            NewListForm newF = new NewListForm(user_id, 0);

            newF.FormClosed += (s, args) => this.Close();
            newF.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                int idValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);

                this.Hide();

                NewListForm newF = new NewListForm(user_id, idValue);

                newF.FormClosed += (s, args) => this.Close();
                newF.Show();

                    

            }
        }
    }
}
