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
    public partial class Parduotuves : Form
    {
        string connectionString = @"Data Source=DESKTOP-3U38BT2;Initial Catalog=Kestutis;Integrated Security=True";
        public Parduotuves()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main ss = new Main();
            ss.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID", sqlCon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dataGridView2.DataSource = dt;
                sqlCon.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID", sqlCon);
                DataTable dtb2 = new DataTable();
                sqlDa.Fill(dtb2);
                dataGridView2.DataSource = dtb2;
                dataGridView2.Columns[0].HeaderCell.Value = "Imones pavadinimas";
                dataGridView2.Columns[1].HeaderCell.Value = "Parduotuves pavadinimas";
                dataGridView2.Columns[2].HeaderCell.Value = "Teritorija";
                dataGridView2.Columns[3].HeaderCell.Value = "Miestas";
                dataGridView2.Columns[4].HeaderCell.Value = "Adresas";
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                sqlCon.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                if (comboBox1.Text == "Imones pavadinimas")
                {        
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND Imone.IMONES_PAV LIKE '" + textBox1.Text + "%'", sqlCon);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].HeaderCell.Value = "Imones pavadinimas";
                    dataGridView2.Columns[1].HeaderCell.Value = "Parduotuves pavadinimas";
                    dataGridView2.Columns[2].HeaderCell.Value = "Teritorija";
                    dataGridView2.Columns[3].HeaderCell.Value = "Miestas";
                    dataGridView2.Columns[4].HeaderCell.Value = "Adresas";

                }
                else if (comboBox1.Text == "Parduotuves pavadinimas")
                {
                    //sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND Parduotuve.PARD_PAV LIKE '" + textBox1.Text + "%%'", sqlCon);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].HeaderCell.Value = "Imones pavadinimas";
                    dataGridView2.Columns[1].HeaderCell.Value = "Parduotuves pavadinimas";
                    dataGridView2.Columns[2].HeaderCell.Value = "Teritorija";
                    dataGridView2.Columns[3].HeaderCell.Value = "Miestas";
                    dataGridView2.Columns[4].HeaderCell.Value = "Adresas";
                    //sqlCon.Close();
                }
                else if (comboBox1.Text == "Parduotuves teritorija")
                {
                    //sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND Parduotuve.PARD_TERITORIJA LIKE '" + textBox1.Text + "%%'", sqlCon);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].HeaderCell.Value = "Imones pavadinimas";
                    dataGridView2.Columns[1].HeaderCell.Value = "Parduotuves pavadinimas";
                    dataGridView2.Columns[2].HeaderCell.Value = "Teritorija";
                    dataGridView2.Columns[3].HeaderCell.Value = "Miestas";
                    dataGridView2.Columns[4].HeaderCell.Value = "Adresas";
                    //sqlCon.Close();
                }
                else if (comboBox1.Text == "Parduotuves miestas")
                {
                    //sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND Parduotuve.PARD_MIESTAS LIKE '" + textBox1.Text + "%%'", sqlCon);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].HeaderCell.Value = "Imones pavadinimas";
                    dataGridView2.Columns[1].HeaderCell.Value = "Parduotuves pavadinimas";
                    dataGridView2.Columns[2].HeaderCell.Value = "Teritorija";
                    dataGridView2.Columns[3].HeaderCell.Value = "Miestas";
                    dataGridView2.Columns[4].HeaderCell.Value = "Adresas";
                    //sqlCon.Close();
                }
                else if (comboBox1.Text == "Parduotuves adresas")
                {
                    //sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND Parduotuve.PARD_ADRESAS LIKE '" + textBox1.Text + "%%'", sqlCon);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].HeaderCell.Value = "Imones pavadinimas";
                    dataGridView2.Columns[1].HeaderCell.Value = "Parduotuves pavadinimas";
                    dataGridView2.Columns[2].HeaderCell.Value = "Teritorija";
                    dataGridView2.Columns[3].HeaderCell.Value = "Miestas";
                    dataGridView2.Columns[4].HeaderCell.Value = "Adresas";
                    //sqlCon.Close();
                }

                sqlCon.Close();

            }
        }

        
    }
}
