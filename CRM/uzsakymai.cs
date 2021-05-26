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

namespace CRM
{
    public partial class uzsakymai : Form
    {

        public uzsakymai()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3U38BT2;Initial Catalog=Kestutis;Integrated Security=True");

        private void uzsakymai_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main ss = new Main();
            ss.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sukurti filtravimą su combobox, patys items jau padaryti, lieka tik surašyti užklausas
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox7.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();
                textBox9.Text = row.Cells[9].Value.ToString();
                textBox10.Text = row.Cells[10].Value.ToString();
                textBox11.Text = row.Cells[11].Value.ToString();
                textBox12.Text = row.Cells[12].Value.ToString();
                textBox13.Text = row.Cells[13].Value.ToString();
                textBox14.Text = row.Cells[14].Value.ToString();
                textBox15.Text = row.Cells[2].Value.ToString();
                textBox16.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (SqlConnection sqlCon = new SqlConnection(connectionString))
                con.Open();
            String query2 = "SELECT UZSAKYMO_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS, PARDUOTUVE WHERE UZSAKYMAS.PARD_KODAS = PARDUOTUVE.PARD_KODAS";
            SqlDataAdapter SDA = new SqlDataAdapter(query2, con);
               DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "UPDATE UZSAKYMAS SET UZSAKYMO_APRASAS = '" + textBox3.Text + "', UZSAKYMO_KONTAKTAS = '" + textBox4.Text + "' WHERE UZSAKYMO_NR = '" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ITERPTA");

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //{
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM UZSAKYMAS WHERE UZSAKYMO_NR = '" + textBox1.Text + "'", con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ISTRINTA");
          //  }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
