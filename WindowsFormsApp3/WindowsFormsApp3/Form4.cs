using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
            string constr = "server = localhost ; user = root ; password=; database=airaport; charset=utf8";
            conn = new MySqlConnection(constr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qq = "select sum(tariff) from Passenger where passportnumber = '"+textBox1.Text+"';";
            try
            {
                string smm;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataReader read = cmd.ExecuteReader();
                read.Read();
                smm = read.GetString("sum(tariff)");
                MessageBox.Show(smm.ToString());
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            finally { 
                conn.Close();
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qq = "select sum(tariff) from Passenger;";
            try
            {
                string smm;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataReader read = cmd.ExecuteReader();
                read.Read();
                smm = read.GetString("sum(tariff)");
                MessageBox.Show(smm.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
