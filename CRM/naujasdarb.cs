using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class naujasdarb : Form
    {
        public naujasdarb()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Ne visi langai užpildyti");
            }
            else
            {
                string query = "INSERT INTO DARBUOTOJAS (DARB_PAV, DARB_TERITORIJA, DARB_PADALINYS, DARB_TEL, DARB_PASTAS) VALUES" + " ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "') ";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Pridėtas įrašas");
            }
            con.Close();
            this.Hide();
        }
    }
}