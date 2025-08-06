using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Trial1
{
    public partial class NewListForm : Form
    {
        private List<int> true_indexes = new List<int>();
        private SqlConnection sqlConnection = null;
        private int user_id = 0;
        private int hotel_id = 0;
        public NewListForm(int userid, int hotelid)
        {
            hotel_id = hotelid;
            user_id = userid;
            InitializeComponent();
        }

        private void NewListForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();

            string query = "SELECT name FROM Types";
            SqlDataReader reader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["name"]);
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { if(reader != null && !reader.IsClosed) {  reader.Close(); } }

            query = "SELECT name FROM Amenities";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            int val = 0;


            if (hotel_id != 0)
            {
                string query1 = "SELECT * FROM Hotels WHERE id = @hotel_id";
                SqlDataReader dataReader = null;
                
                try
                {
                    SqlCommand command = new SqlCommand(query1, sqlConnection);
                    command.Parameters.AddWithValue("@hotel_id", hotel_id);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        //Type
                        val = Convert.ToInt32(dataReader["type"]);
                        //title
                        textBox1.Text = dataReader["title"].ToString();

                        //capacity
                        textBox2.Text = dataReader["capacity"].ToString();

                        //num_beds
                        textBox3.Text = dataReader["num_beds"].ToString();

                        //num_bedrooms
                        textBox4.Text = dataReader["num_bedrooms"].ToString();

                        //num_bathrooms
                        textBox5.Text = dataReader["num_bathrooms"].ToString();

                        //apxm_address
                        textBox6.Text = dataReader["apxm_address"].ToString();

                        //exact_address
                        textBox7.Text = dataReader["exact_address"].ToString();

                        //description
                        textBox8.Text = dataReader["description"].ToString();

                        //host_rules
                        textBox9.Text = dataReader["host_rules"].ToString();

                        //reservation_time
                        string a = dataReader["reservation_time"].ToString();
                        string[] b = a.Split('-');
                        textBox10.Text = b[0];
                        textBox11.Text = b[1];
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (dataReader != null && !dataReader.IsClosed) { dataReader.Close(); } }
            }
            if (hotel_id != 0)
            { //types
                SqlDataReader dataReader = null;
                try
                {
                    string query2 = "SELECT name FROM Types WHERE id = @type_id";
                    SqlCommand cmd = new SqlCommand(query2, sqlConnection);
                    cmd.Parameters.AddWithValue("@type_id", val);
                    object var = cmd.ExecuteScalar();
                    if (var != null)
                    {
                        string value = Convert.ToString(var);
                        comboBox1.Text = value;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (dataReader != null && !dataReader.IsClosed) { dataReader.Close(); } }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            true_indexes.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["checking"] as DataGridViewCheckBoxCell;

                bool isChecked = Convert.ToBoolean(checkBoxCell.Value);

                if (isChecked)
                {
                    string query = "SELECT id FROM Amenities WHERE name = @name";
                    SqlDataReader dataReader = null;
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@name", row.Cells["name"].Value.ToString());

                        dataReader = sqlCommand.ExecuteReader();

                        if (dataReader.Read())
                        {
                            true_indexes.Add(Convert.ToInt32(dataReader["id"]));
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { if (dataReader != null && !dataReader.IsClosed) { dataReader.Close(); } }
                }
            }
            if (hotel_id == 0)
            {
                string query = "INSERT INTO Hotels(type, title, capacity, num_beds, num_bedrooms, num_bathrooms, apxm_address, exact_address, description, host_rules, reservation_time,amenities, user_created) VALUES(@type, @title, @capacity, @num_beds, @num_bedrooms, @num_bathrooms, @apxm_address, @exact_address, @description, @host_rules, @reservation_time, @amenities, @user_id)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string new_query = "SELECT id FROM Types WHERE name = @name";

                SqlDataReader reader = null;
                try
                {
                    SqlCommand sdef = new SqlCommand(@new_query, sqlConnection);
                    sdef.Parameters.AddWithValue("@name", comboBox1.Text);
                    reader = sdef.ExecuteReader();
                    if (reader.Read())
                    {
                        sqlCommand.Parameters.AddWithValue("@type", reader["id"]);
                    }
                    else { sqlCommand.Parameters.AddWithValue("@type", 4); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (reader != null && !reader.IsClosed) { reader.Close(); } }
                string value = "";

                sqlCommand.Parameters.AddWithValue("@title", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@capacity", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@num_beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@num_bedrooms", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@num_bathrooms", textBox5.Text);
                sqlCommand.Parameters.AddWithValue("@apxm_address", textBox6.Text);
                sqlCommand.Parameters.AddWithValue("@exact_address", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@description", textBox8.Text);
                sqlCommand.Parameters.AddWithValue("@host_rules", textBox9.Text);
                sqlCommand.Parameters.AddWithValue("@reservation_time", textBox10.Text + "-" + textBox11.Text);
                foreach (int var in true_indexes)
                {
                    value = value + var.ToString() + ", ";
                }
                sqlCommand.Parameters.AddWithValue("@amenities", value);
                sqlCommand.Parameters.AddWithValue("@user_id", user_id);


                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                string query = "UPDATE Hotels SET type = @type, title = @title, capacity = @capacity, num_beds = @num_beds, num_bedrooms = @num_bedrooms, num_bathrooms = @num_bathrooms, apxm_address = @apxm_address, exact_address = @exact_address, description = @description, host_rules = @host_rules, reservation_time = @reservation_time, amenities = @amenities, user_created = @user_id WHERE id = @hotel_id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string new_query = "SELECT id FROM Types WHERE name = @name";

                SqlDataReader reader = null;
                try
                {
                    SqlCommand sdef = new SqlCommand(@new_query, sqlConnection);
                    sdef.Parameters.AddWithValue("@name", comboBox1.Text);
                    reader = sdef.ExecuteReader();
                    if (reader.Read())
                    {
                        sqlCommand.Parameters.AddWithValue("@type", reader["id"]);
                    }
                    else { sqlCommand.Parameters.AddWithValue("@type", 4); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (reader != null && !reader.IsClosed) { reader.Close(); } }
                string value = "";

                sqlCommand.Parameters.AddWithValue("@title", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@capacity", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@num_beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@num_bedrooms", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@num_bathrooms", textBox5.Text);
                sqlCommand.Parameters.AddWithValue("@apxm_address", textBox6.Text);
                sqlCommand.Parameters.AddWithValue("@exact_address", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@description", textBox8.Text);
                sqlCommand.Parameters.AddWithValue("@host_rules", textBox9.Text);
                sqlCommand.Parameters.AddWithValue("@reservation_time", textBox10.Text + "-" + textBox11.Text);
                foreach (int var in true_indexes)
                {
                    value = value + var.ToString() + ", ";
                }
                sqlCommand.Parameters.AddWithValue("@amenities", value);
                sqlCommand.Parameters.AddWithValue("@user_id", user_id);
                sqlCommand.Parameters.AddWithValue("@hotel_id", hotel_id);


                sqlCommand.ExecuteNonQuery();
            }

            this.Hide();

            MainForm newF = new MainForm(user_id);

            newF.FormClosed += (s, args) => this.Close();
            newF.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            true_indexes.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["checking"] as DataGridViewCheckBoxCell;

                bool isChecked = Convert.ToBoolean(checkBoxCell.Value);

                if (isChecked)
                {
                    string query = "SELECT id FROM Amenities WHERE name = @name";
                    SqlDataReader dataReader = null;
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@name", row.Cells["name"].Value.ToString());

                        dataReader = sqlCommand.ExecuteReader();

                        if (dataReader.Read())
                        {
                            true_indexes.Add(Convert.ToInt32(dataReader["id"]));
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { if (dataReader != null && !dataReader.IsClosed) { dataReader.Close(); } }
                }
            }
            if (hotel_id == 0)
            {
                string query = "INSERT INTO Hotels(type, title, capacity, num_beds, num_bedrooms, num_bathrooms, apxm_address, exact_address, description, host_rules, reservation_time,amenities, user_created) VALUES(@type, @title, @capacity, @num_beds, @num_bedrooms, @num_bathrooms, @apxm_address, @exact_address, @description, @host_rules, @reservation_time, @amenities, @user_id)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string new_query = "SELECT id FROM Types WHERE name = @name";

                SqlDataReader reader = null;
                try
                {
                    SqlCommand sdef = new SqlCommand(@new_query, sqlConnection);
                    sdef.Parameters.AddWithValue("@name", comboBox1.Text);
                    reader = sdef.ExecuteReader();
                    if (reader.Read())
                    {
                        sqlCommand.Parameters.AddWithValue("@type", reader["id"]);
                    }
                    else { sqlCommand.Parameters.AddWithValue("@type", 4); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (reader != null && !reader.IsClosed) { reader.Close(); } }
                string value = "";

                sqlCommand.Parameters.AddWithValue("@title", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@capacity", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@num_beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@num_bedrooms", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@num_bathrooms", textBox5.Text);
                sqlCommand.Parameters.AddWithValue("@apxm_address", textBox6.Text);
                sqlCommand.Parameters.AddWithValue("@exact_address", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@description", textBox8.Text);
                sqlCommand.Parameters.AddWithValue("@host_rules", textBox9.Text);
                sqlCommand.Parameters.AddWithValue("@reservation_time", textBox10.Text + "-" + textBox11.Text);
                foreach (int var in true_indexes)
                {
                    value = value + var.ToString() + ", ";
                }
                sqlCommand.Parameters.AddWithValue("@amenities", value);
                sqlCommand.Parameters.AddWithValue("@user_id", user_id);


                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                string query = "UPDATE Hotels SET type = @type, title = @title, capacity = @capacity, num_beds = @num_beds, num_bedrooms = @num_bedrooms, num_bathrooms = @num_bathrooms, apxm_address = @apxm_address, exact_address = @exact_address, description = @description, host_rules = @host_rules, reservation_time = @reservation_time, amenities = @amenities, user_created = @user_id WHERE id = @hotel_id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string new_query = "SELECT id FROM Types WHERE name = @name";

                SqlDataReader reader = null;
                try
                {
                    SqlCommand sdef = new SqlCommand(@new_query, sqlConnection);
                    sdef.Parameters.AddWithValue("@name", comboBox1.Text);
                    reader = sdef.ExecuteReader();
                    if (reader.Read())
                    {
                        sqlCommand.Parameters.AddWithValue("@type", reader["id"]);
                    }
                    else { sqlCommand.Parameters.AddWithValue("@type", 4); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { if (reader != null && !reader.IsClosed) { reader.Close(); } }
                string value = "";

                sqlCommand.Parameters.AddWithValue("@title", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@capacity", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@num_beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@num_bedrooms", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@num_bathrooms", textBox5.Text);
                sqlCommand.Parameters.AddWithValue("@apxm_address", textBox6.Text);
                sqlCommand.Parameters.AddWithValue("@exact_address", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@description", textBox8.Text);
                sqlCommand.Parameters.AddWithValue("@host_rules", textBox9.Text);
                sqlCommand.Parameters.AddWithValue("@reservation_time", textBox10.Text + "-" + textBox11.Text);
                foreach (int var in true_indexes)
                {
                    value = value + var.ToString() + ", ";
                }
                sqlCommand.Parameters.AddWithValue("@amenities", value);
                sqlCommand.Parameters.AddWithValue("@user_id", user_id);
                sqlCommand.Parameters.AddWithValue("@hotel_id", hotel_id);


                sqlCommand.ExecuteNonQuery();
            }

            this.Hide();

            MainForm newF = new MainForm(user_id);

            newF.FormClosed += (s, args) => this.Close();
            newF.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
