using System;
using System.Diagnostics;
using System.Windows.Forms;
using MySqlConnector;

namespace myrankAdminForm
{
    public partial class shit : Form
    {
        public shit()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }
        private MySqlConnection Connector()
        {
            string strConn = "Server=localhost;Database=yourDB;Uid=your;Pwd=your;";
            MySqlConnection conn = new MySqlConnection(strConn);
            return conn;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            MySqlConnection conn = Connector();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from yourTable order by surviveTime desc;", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(Convert.ToString(rdr["userName"]), Convert.ToString(rdr["surviveTime"]).Substring(0, 8));
            }
            dataGridView1.ClearSelection();
            rdr.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Connector();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select surviveTime from yourTable where userName = '{textBox1.Text}'; ", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            dataGridView2.Rows.Clear();
            while (rdr.Read())
            {
                dataGridView2.Rows.Add(Convert.ToString(rdr["surviveTime"]).Substring(0, 8));
            }
            dataGridView2.ClearSelection();
            rdr.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
