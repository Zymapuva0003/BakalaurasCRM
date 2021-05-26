using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class parduotuveupdate : Form
    {
        public parduotuveupdate()
        {
            InitializeComponent();
            textBox1.Text = Main.pard1;
            textBox2.Text = Main.pard3;
            textBox3.Text = Main.pard4;
            textBox4.Text = Main.pard5;
            textBox5.Text = Main.pard6;
            textBox6.Text = Main.pard7;
            textBox7.Text = Main.pard2;
        }

        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void parduotuveupdate_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE PARDUOTUVE SET PARD_PASTAS = '" + textBox6.Text + "', PARD_PAV = '" + textBox2.Text + "', PARD_TERITORIJA = '" + textBox3.Text + "', PARD_MIESTAS = '" + textBox4.Text + "', PARD_ADRESAS = '" + textBox5.Text + "' WHERE PARD_KODAS = '" + textBox7.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Įrašas atnaujintas");
        }
    }
}