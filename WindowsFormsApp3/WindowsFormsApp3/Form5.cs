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
    public partial class Form5 : Form
    {
        MySqlConnection conn;
        public Form5()
        {
            InitializeComponent();
            string constr = "server = localhost ; user = root ; password=; database=airaport; charset=utf8";
            conn = new MySqlConnection(constr);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Tb1();
            Tb2();
        }
        public void Frm_t()
        {
            try
            {
                dataGridView1.Columns["name"].HeaderText = "name";
                dataGridView1.Columns["surname"].HeaderText = "surname";
                dataGridView1.Columns["passportnumber"].HeaderText = "passportnumber";
                dataGridView1.Columns["tariff"].HeaderText = "cost";
            }
            catch (Exception ex)
            {

            }
        }
        public void Frm_t2()
        {
            try
            {
                dataGridView2.Columns["tariff"].HeaderText = "tariff";
                dataGridView2.Columns["cost"].HeaderText = "cost";
            }
            catch (Exception ex)
            {

            }
        }
        void Tb1 ()
        {
            string qq = "select * from Passenger;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                Frm_t();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
        void Tb2 ()
        {
            string qq = "select * from Tariff;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                DataTable tb = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                ad.Fill(tb);
                dataGridView2.DataSource = tb;
                Frm_t2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
