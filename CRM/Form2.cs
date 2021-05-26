using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fillcombobox1();
            fillcombobox3();
        }

        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void label5_Click(object sender, EventArgs e)
        {
        }

        public void fillcombobox1()
        {
            con.Open();

            try
            {
                string imone = "select * from IMONE";
                SqlDataAdapter SDA = new SqlDataAdapter(imone, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                comboBox1.ValueMember = "IMONES_ID";
                comboBox1.DisplayMember = "IMONES_PAV";
                comboBox1.DataSource = dt;
                comboBox1.Width = comboBox1.Items[comboBox1.SelectedIndex].ToString().Length * 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void fillcombobox2()
        {
            con.Open();

            try
            {
                string pard = "select * from PARDUOTUVE";
                SqlDataAdapter SDA = new SqlDataAdapter(pard, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                comboBox2.ValueMember = "PARD_KODAS";
                comboBox2.DisplayMember = "PARD_PAV";
                comboBox2.DataSource = dt;
                comboBox2.Width = comboBox2.Items[comboBox2.SelectedIndex].ToString().Length * 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void fillcombobox3()
        {
            con.Open();
            try
            {
                string pard = "select * from PARDĮRANGA";
                SqlDataAdapter SDA = new SqlDataAdapter(pard, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                comboBox3.ValueMember = "IRANG_ID";
                comboBox3.DisplayMember = "IRANG_APR";
                comboBox3.DataSource = dt;
                comboBox3.Width = comboBox3.Items[comboBox3.SelectedIndex].ToString().Length * 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            comboBox3.Text = " ";
            string imone = "select * from PARDUOTUVE where IMONES_ID=@IMONES_ID";
            SqlDataAdapter SDA = new SqlDataAdapter(imone, con);
            SDA.SelectCommand.Parameters.AddWithValue("@IMONES_ID", comboBox1.SelectedValue.ToString());
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            con.Close();
            comboBox2.ValueMember = "PARD_KODAS";
            comboBox2.DisplayMember = "PARD_PAV";
            // textBox7.Text = "PARD_ADRESAS";
            comboBox2.DataSource = dt;
            comboBox2.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iranga = "select * from PARDĮRANGA where IRANG_APR = '" + comboBox3.Text + "';";
            SqlCommand SDA = new SqlCommand(iranga, con);
            SqlDataReader reader;
            con.Close();
            try
            {
                con.Open();

                reader = SDA.ExecuteReader();
                while (reader.Read())
                {
                    string irangapr = reader.GetString(1);
                    string irangsn = reader.GetString(3);
                    string irangkaina = reader.GetString(4);
                    string iranggrp = reader.GetString(2);
                    textBox1.Text = irangapr;
                    textBox2.Text = irangsn;
                    textBox3.Text = irangkaina;
                    textBox4.Text = iranggrp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ar viskas parinkta teisingai?", "Pardavimas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime time = DateTime.Now;
                string laikas = "HH:mm:ss";
                string data = "yyyy-MM-dd ";
                textBox5.Text = time.ToString(data);
                textBox6.Text = time.ToString(laikas);
                con.Open();
                string query = "INSERT INTO PARDAVIMAI (PARD_KODAS, PARDIRANG_ID, PARDIRANG_APR, PARDIRANG_SN, PARD_KAINA, PARDIRANG_GR, PARD_DATA, PARD_LAIKAS) VALUES" + " ('" + comboBox2.SelectedValue.ToString() + "','" + comboBox3.SelectedValue.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + time.ToString(data) + "','" + time.ToString(laikas) + "') ";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                this.Hide();
                MessageBox.Show("Prideta");
            }
        }
    }
}