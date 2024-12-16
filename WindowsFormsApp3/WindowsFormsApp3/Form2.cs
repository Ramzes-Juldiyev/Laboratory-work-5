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
namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        MySqlConnection conn;
        public Form2()
        {
            InitializeComponent();
            string constr = "server = localhost ; user = root ; password=; database=airaport; charset=utf8";
            conn = new MySqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qq = "insert into Tariff (tariff,cost) values ('" + comboBox1.SelectedItem + "','" + numericUpDown1.Value.ToString().Replace(",", ".") + "'); ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ok");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally { 
                conn.Close();
                comboBox1.SelectedIndex = 0;
                numericUpDown1.Value = 1;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Domestic");
            comboBox1.Items.Add("International");
            comboBox1.Items.Add("Regional");
            comboBox1.SelectedIndex = 0;
            conn.Close();
        }
    }
}
