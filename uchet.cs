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
    public partial class uchet : Form
    {
        public uchet()
        {
            InitializeComponent();
            getinfo();
        }

        private void getinfo()
        {
            string query = "SELECT id_klient, id_abon, month, oplata FROM uchet";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sportzal;User=root;Password=2375425;");
                MySqlCommand cmd = new MySqlCommand("insert into uchet(id_klient, id_abon, month, oplata) value('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "');", conn);
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
                MySqlCommand cmd = new MySqlCommand("update uchet set id_klient ='" + textBox1.Text + "', id_abon = '" + textBox2.Text + "', month = '" + textBox3.Text + "', oplata = '" + textBox4.Text + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getinfo("select * from uchet;");
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
