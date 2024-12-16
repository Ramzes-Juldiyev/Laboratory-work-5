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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all data?", "message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MySqlConnection conn;
                string constr = "server = localhost ; user = root ; password=; database=airaport; charset=utf8";
                conn = new MySqlConnection(constr);
                string qq = "drop table Passenger;";
                string q2 = "drop table Tariff;";
                string q3 = "create table Passenger (id int  auto_increment,name varchar(50),surname varchar(50),passportnumber varchar(50),tariff decimal(50,2),primary key(id));";
                string q4 = "create table Tariff (id int  auto_increment,tariff varchar(50),cost decimal(50,2),primary key(id));";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(qq, conn);
                    cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand(q2, conn);
                    cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand(q3, conn);
                    cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand(q4, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ok");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conn.Close(); }
            }
            else
            {
                MessageBox.Show("Ok");
            }
        }
    }
}
