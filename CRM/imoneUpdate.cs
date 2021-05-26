using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class imoneUpdate : Form
    {
        public imoneUpdate()
        {
            InitializeComponent();
            textBox1.Text = Main.imon1;
            textBox2.Text = Main.imon2;
            textBox3.Text = Main.imon3;
            textBox4.Text = Main.imon4;
            textBox5.Text = Main.imon5;
        }

        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void imoneUpdate_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Ne visi langai užpildyti");
            }
            else
            {
                string query = "UPDATE IMONE SET IMONES_PAV = '" + textBox1.Text + "', IMONES_PVM = '" + textBox2.Text + "', IMONES_PASTAS = '" + textBox3.Text + "', IMONES_ADRESAS = '" + textBox4.Text + "' WHERE IMONES_ID = '" + textBox5.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Įrašas atnaujintas");
            }
            con.Close();
            this.Hide();
        }
    }
}