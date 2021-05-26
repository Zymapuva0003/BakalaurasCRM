using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class Naujapard : Form
    {
        public Naujapard()
        {
            InitializeComponent();
            Imones();
        }

        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public void Imones()
        {
            con.Open();
            try
            {
                string Imone = "SELECT * FROM IMONE";
                SqlDataAdapter SDA = new SqlDataAdapter(Imone, con); ;
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                comboBox1.ValueMember = "IMONES_ID";
                comboBox1.DisplayMember = "IMONES_PAV";
                comboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Ne visi langai užpildyti");
            }
            else
            {
                string query = "INSERT INTO PARDUOTUVE (IMONES_ID, PARD_PASTAS, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS) VALUES" + " ('" + comboBox1.SelectedValue.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "') ";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Pridėtas įrašas");
            }
            con.Close();
            this.Hide();
        }
    }
}