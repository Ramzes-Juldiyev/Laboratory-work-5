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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        MySqlConnection conn;
        public Form3()
        {
            InitializeComponent();
            string constr = "server = localhost ; user = root ; password=; database=airaport; charset=utf8";
            conn = new MySqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qq = "insert into Passenger (passportnumber,name,surname,tariff) values ('" + textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+comboBox1.SelectedValue.ToString().Replace(",", ".") + "');";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { 
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                Loadff();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Loadff();
        }
        void Loadff()
        {
            conn.Open();
            string sqlq = "select * from Tariff;";
            MySqlCommand command = new MySqlCommand(sqlq, conn);
            DataTable tb = new DataTable();
            MySqlDataAdapter ad = new MySqlDataAdapter(command);
            ad.Fill(tb);
            comboBox1.DisplayMember = "tariff";
            comboBox1.ValueMember = "cost";
            comboBox1.DataSource = tb;
            conn.Close();
            label6.Text = comboBox1.SelectedValue.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
