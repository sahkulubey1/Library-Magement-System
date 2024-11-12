using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ozans\OneDrive\Belgeler\LibraryDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string Username = "";

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from UserTbl where UName='"+UnameTb.Text+"' and UPass='"+UPassTb.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Username= UnameTb.Text;
                Billing obj = new Billing();
                obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password Or Username");
            }


            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
                AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }
    }
}
