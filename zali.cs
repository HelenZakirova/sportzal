using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sportzal
{
    public partial class zali : Form
    {
        public zali()
        {
            InitializeComponent();
            getinfo();
        }

        private void getinfo()
        {
            string query = "SELECT id_zala, naimenovanie FROM zali";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sportzal;User=root;Password=2375425;");
                MySqlCommand cmd = new MySqlCommand("insert into zali(id_zala, naimenovanie) value('" + textBox1.Text + "','" + textBox2.Text + "');", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка внесения данных!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sportzal;User=root;Password=2375425;");
                MySqlCommand cmd = new MySqlCommand("update zali set id_zala ='" + textBox1.Text + "', naimenovanie = '" + textBox2.Text + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getinfo("select * from zali;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getinfo(string v)
        {
            throw new NotImplementedException();
        }
    }
}
