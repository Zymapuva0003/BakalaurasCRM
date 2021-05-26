using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class irangaupdate : Form
    {
        public irangaupdate()
        {
            InitializeComponent();
            textBox1.Text = Main.irang1;
            textBox2.Text = Main.irang2;
            textBox3.Text = Main.irang3;
            textBox4.Text = Main.irang4;
            textBox5.Text = Main.irang5;
            textBox6.Text = Main.irang6;
            textBox7.Text = Main.irang7;
            textBox8.Text = Main.irang8;
            
        }
        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Ne visi langai užpildyti");
            }
            else
            {
                string query = "UPDATE IRANGA SET IRANGOS_APRASAS = '" + textBox2.Text + "', IRANGOS_GRUPE = '" + textBox3.Text + "', SUTARTIES_PRADZIA = '" + textBox4.Text + "', SUTARTIES_PABAIGA = '" + textBox5.Text + "', GARANTIJOS_PRADZIA = '" + textBox6.Text + "', GARANTIJOS_PABAIGA = '" + textBox7.Text + "', PASKUTINIOAP_DATA = '" + textBox8.Text + "' WHERE IRANGOS_NR = '" + textBox1.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Įrašas atnaujintas");
            }
            con.Close();
            this.Hide();
        }

        private void tabPage2_MouseClick(object sender, MouseEventArgs e)
        {
            {
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, IRANGOS_NR, UZSAKYMO_APRASAS, UZSAKYMO_BUSENA, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2 WHERE IRANGOS_NR = '" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].HeaderCell.Value = "Numeris";
                dataGridView1.Columns[1].HeaderCell.Value = "Įrangos nr";
                dataGridView1.Columns[2].HeaderCell.Value = "Aprašymas";
                dataGridView1.Columns[3].HeaderCell.Value = "Būsena";
                dataGridView1.Columns[4].HeaderCell.Value = "Sprendėjas";
                dataGridView1.Columns[5].HeaderCell.Value = "Kūrėjas";
                dataGridView1.Columns[6].HeaderCell.Value = "Data";
                con.Close();
            }
        }
    }
}
