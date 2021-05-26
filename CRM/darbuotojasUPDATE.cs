using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CRM
{
    public partial class darbuotojasUPDATE : Form
    {
        public darbuotojasUPDATE()
        {
            InitializeComponent();
            textBox1.Text = Main.darb1;
            textBox2.Text = Main.darb2;
            textBox3.Text = Main.darb3;
            textBox4.Text = Main.darb4;
            textBox5.Text = Main.darb5;
            textBox6.Text = Main.darb6;
        }
        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Ne visi langai užpildyti");
            }
            else
            {
                string query = "UPDATE DARBUOTOJAS SET DARB_PAV = '" + textBox2.Text + "', DARB_TERITORIJA = '" + textBox3.Text + "', DARB_PADALINYS = '" + textBox4.Text + "', DARB_TEL = '" + textBox5.Text + "', DARB_PASTAS = '" + textBox6.Text + "' WHERE DARB_ID = '" + textBox1.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Įrašas atnaujintas");
            }
            con.Close();
            this.Hide();
        }
    }
}
