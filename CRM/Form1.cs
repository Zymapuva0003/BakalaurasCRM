using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static string username = "";

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.Logins WHERE username='" + textBox1.Text + "' AND password ='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                username = textBox1.Text;
                this.Hide();

                Main ss = new Main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Patikrinkite savo prisijungimus");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}