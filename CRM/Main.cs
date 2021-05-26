using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRM
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            timer1.Start();
            textBox11.Text = Form1.username;
            fillcombobox7();
            textBox21.Text = comboBox7.Text;

            if (textBox11.Text != "admin")
            {
                button13.Hide();
                textBox13.Hide();
                button2.Hide();
                button17.Hide();
                button15.Hide();
                button20.Hide();
                button18.Hide();
                button21.Hide();
                textBox17.Hide();
                textBox19.Hide();
                textBox20.Hide();
            }
        }

        public static string uzsakyymas = "";
        public static string dd = "";
        public static string pardpav = "";
        public static string pardadr = "";
        public static string vardas = "";
        public static string irangaaa = "";
        public static string telefonas = "";
        public static string elpastas = "";
        public static string laikas2 = "HH:mm:ss";
        public static string data2 = "yyyy-MM-dd";
        public static string pard1 = "";
        public static string pard2 = "";
        public static string pard3 = "";
        public static string pard4 = "";
        public static string pard5 = "";
        public static string pard6 = "";
        public static string pard7 = "";
        public static string imon1 = "";
        public static string imon2 = "";
        public static string imon3 = "";
        public static string imon4 = "";
        public static string imon5 = "";
        public static string darb1 = "";
        public static string darb2 = "";
        public static string darb3 = "";
        public static string darb4 = "";
        public static string darb5 = "";
        public static string darb6 = "";
        public static string aprasymas = "";
        public static string sprendejas = "";
        public static string reakdata = "";
        public static string reaklaikas = "";
        public static string tipas = "";

        public static string irang1 = "";
        public static string irang2 = "";
        public static string irang3 = "";
        public static string irang4 = "";
        public static string irang5 = "";
        public static string irang6 = "";
        public static string irang7 = "";
        public static string irang8 = "";

        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void darbuotojas()
        {
            string imone = "select DARB_ID from Logins where username=@username";
            SqlDataAdapter SDA = new SqlDataAdapter(imone, con);
            SDA.SelectCommand.Parameters.AddWithValue("@username", textBox11.Text);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ar tikrai norite atsijungti?", "Atsijungti", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form1 ss = new Form1();
                ss.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label1.Text = datetime.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fillcombobox7();
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    uzsakyymas = row.Cells[0].Value.ToString();
                    pardpav = row.Cells[1].Value.ToString();
                    pardadr = row.Cells[2].Value.ToString();
                    irangaaa = row.Cells[3].Value.ToString();
                    aprasymas = row.Cells[4].Value.ToString();
                    vardas = row.Cells[5].Value.ToString();
                    telefonas = row.Cells[6].Value.ToString();
                    elpastas = row.Cells[7].Value.ToString();
                    sprendejas = row.Cells[13].Value.ToString();
                    reakdata = row.Cells[11].Value.ToString();
                    reaklaikas = row.Cells[12].Value.ToString();
                    tipas = row.Cells[10].Value.ToString();
                    dd = comboBox7.Text;
                    baigtiuzsakymai bu = new baigtiuzsakymai();
                    bu.Show();
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, IRANGOS_APRASAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE, IRANGA WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMAS2.IRANGOS_NR = IRANGA.IRANGOS_NR", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[0].HeaderCell.Value = "Darbo ID";
            dataGridView1.Columns[1].HeaderCell.Value = "Parduotuvės pavadinimas";
            dataGridView1.Columns[2].HeaderCell.Value = "Parduotuvės adresas";
            dataGridView1.Columns[3].HeaderCell.Value = "Įranga";
            dataGridView1.Columns[4].HeaderCell.Value = "Incidento aprašas";
            dataGridView1.Columns[5].HeaderCell.Value = "Užsakovas";
            dataGridView1.Columns[6].HeaderCell.Value = "Kontaktas";
            dataGridView1.Columns[7].HeaderCell.Value = "El. paštas";
            dataGridView1.Columns[8].HeaderCell.Value = "Prioritetas";
            dataGridView1.Columns[9].HeaderCell.Value = "Būsena";
            dataGridView1.Columns[10].HeaderCell.Value = "Tipas";
            dataGridView1.Columns[11].HeaderCell.Value = "Reakcijos data";
            dataGridView1.Columns[12].HeaderCell.Value = "Reakcijos laikas";
            dataGridView1.Columns[13].HeaderCell.Value = "Sprendėjas";
            dataGridView1.Columns[14].HeaderCell.Value = "Kūrėjas";
            dataGridView1.Columns[15].HeaderCell.Value = "Incidento data";
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kestutisDataSet8.DARBUOTOJAS' table. You can move, or remove it, as needed.
            this.dARBUOTOJASTableAdapter1.Fill(this.kestutisDataSet8.DARBUOTOJAS);
            // TODO: This line of code loads data into the 'iMONESFINALLY.IMONE' table. You can move, or remove it, as needed.
            this.iMONETableAdapter3.Fill(this.iMONESFINALLY.IMONE);
            // TODO: This line of code loads data into the 'kestutisDataSet7.IMONE' table. You can move, or remove it, as needed.
            this.iMONETableAdapter2.Fill(this.kestutisDataSet7.IMONE);
            // TODO: This line of code loads data into the 'parduotuve_adresas_imone.PARDUOTUVE' table. You can move, or remove it, as needed.
            this.pARDUOTUVETableAdapter3.Fill(this.parduotuve_adresas_imone.PARDUOTUVE);
            // TODO: This line of code loads data into the 'kestutisDataSet6.PARDUOTUVE' table. You can move, or remove it, as needed.
            this.pARDUOTUVETableAdapter2.Fill(this.kestutisDataSet6.PARDUOTUVE);
            // TODO: This line of code loads data into the 'kestutisDataSet5.IRANGA' table. You can move, or remove it, as needed.
            this.iRANGATableAdapter1.Fill(this.kestutisDataSet5.IRANGA);
            // TODO: This line of code loads data into the 'kestutisDataSet4.DARBUOTOJAS' table. You can move, or remove it, as needed.
            this.dARBUOTOJASTableAdapter.Fill(this.kestutisDataSet4.DARBUOTOJAS);
            // TODO: This line of code loads data into the 'iranga.IRANGA' table. You can move, or remove it, as needed.
            this.iRANGATableAdapter.Fill(this.iranga.IRANGA);
            // TODO: This line of code loads data into the 'pARD.PARDUOTUVE' table. You can move, or remove it, as needed.
            this.pARDUOTUVETableAdapter1.Fill(this.pARD.PARDUOTUVE);
            // TODO: This line of code loads data into the 'kestutisDataSet3.PARDUOTUVE' table. You can move, or remove it, as needed.
            this.pARDUOTUVETableAdapter.Fill(this.kestutisDataSet3.PARDUOTUVE);
            // TODO: This line of code loads data into the 'imonesPAV.IMONE' table. You can move, or remove it, as needed.
            this.iMONETableAdapter1.Fill(this.imonesPAV.IMONE);
            // TODO: This line of code loads data into the 'dATA.IMONE' table. You can move, or remove it, as needed.
            this.iMONETableAdapter.Fill(this.dATA.IMONE);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.iMONETableAdapter.FillBy(this.dATA.IMONE);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string format2 = "yyyy-MM-dd";
            con.Open();
            string query = "INSERT INTO UZSAKYMAS2 (PARD_KODAS, IRANGOS_NR, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA) VALUES" + " ('" + comboBox2.SelectedValue.ToString() + "','" + comboBox3.SelectedValue.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox4.Text + "','" + comboBox8.Text + "','" + comboBox5.Text + "','" + time.ToString(format2) + "','" + textBox6.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + time.ToString(format) + "') ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Incidentas sukurtas");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            textBox7.Text = " ";
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pardadresas();
            comboBox3.Text = " ";
            string iranga = "select * from IRANGA where PARD_KODAS=@PARD_KODAS";
            SqlDataAdapter SDA = new SqlDataAdapter(iranga, con);
            SDA.SelectCommand.Parameters.AddWithValue("@PARD_KODAS", comboBox2.SelectedValue.ToString());
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            con.Close();
            comboBox3.ValueMember = "IRANGOS_NR";
            comboBox3.DisplayMember = "IRANGOS_APRASAS";
            // textBox7.Text = "PARD_ADRESAS";
            comboBox3.DataSource = dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            {
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_NR, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE PARDUOTUVE.PARD_KODAS = IRANGA.PARD_KODAS", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.Columns[0].HeaderCell.Value = "Parduotuvės pavadinimas";
                dataGridView2.Columns[1].HeaderCell.Value = "Parduotuvės adresas";
                dataGridView2.Columns[2].HeaderCell.Value = "Parduotuvės miestas";
                dataGridView2.Columns[3].HeaderCell.Value = "Įrangos numeris";
                dataGridView2.Columns[4].HeaderCell.Value = "Įrangos aprašas";
                dataGridView2.Columns[5].HeaderCell.Value = "Įrangos grupė";
                dataGridView2.Columns[6].HeaderCell.Value = "Įrangos SN";
                dataGridView2.Columns[7].HeaderCell.Value = "Įrangos SN";
                dataGridView2.Columns[8].HeaderCell.Value = "Sutarties pradžia";
                dataGridView2.Columns[9].HeaderCell.Value = "Sutarties pabaiga";
                dataGridView2.Columns[10].HeaderCell.Value = "Garantijos pradžia";
                dataGridView2.Columns[11].HeaderCell.Value = "Garantijos pabaiga";
                dataGridView2.Columns[12].HeaderCell.Value = "Įrangos būsena";
                dataGridView2.Columns[13].HeaderCell.Value = "Paskutinio aptarnavimo data";
                con.Close();
            }
        }

       

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox9.Text == "Parduotuvė")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND PARD_PAV LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Parduotuvės adresas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND PARD_ADRESAS LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Miestas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND PARD_MIESTAS LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Įrangos numeris")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND IRANGOS_NR LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Įrangos aprašas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND IRANGOS_APRASAS LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Įrangos grupė")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND IRANGOS_GRUPE LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Sutarties numeris")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND SUTARTIES_NR LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Sutarties pradžia")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND SUTARTIES_PRADZIA LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Sutarties pabaiga")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND SUTARTIES_PABAIGA LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Garantijos pradžia")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND GARANTIJOS_PRADZIA LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Garantijos pabaiga")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND GARANTIJOS_PABAIGA LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Irangos būsena")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND IRANGOS_BUSENA LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "Paskutinio aptarnavimo data")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND PASKUTINIOAP_DATA LIKE '" + textBox9.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox9.Text == "<Nepasirinkta>")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT PARD_PAV, PARD_ADRESAS, PARD_MIESTAS, IRANGOS_NR, IRANGOS_APRASAS, IRANGOS_GRUPE, IRANGOS_SN, SUTARTIES_PRADZIA, SUTARTIES_PABAIGA, GARANTIJOS_PRADZIA, GARANTIJOS_PABAIGA, IRANGOS_BUSENA, PASKUTINIOAP_DATA FROM IRANGA, PARDUOTUVE WHERE IRANGA.PARD_KODAS = PARDUOTUVE.PARD_KODAS", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView2.DataSource = dt;
            }

            con.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        } 
        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox6.Text = "Nepasirinkta";
            fillcombobox1();
            fillcombobox3();
            fillcombobox7();
            comboBox8.Text = "Laukiama";
            comboBox5.Text = "Problema";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pagal prioritetą parenkamas reakcijos laikas ir data
            DateTime time = DateTime.Now;
            string laikas = "HH:mm:ss";
            string data = "yyyy-MM-dd ";
            if (comboBox4.Text == "Žemas")
            {
                textBox12.Text = "Reakcija 8h";
                time = time.AddHours(8);
                textBox5.Text = time.ToString(data);
                textBox6.Text = time.ToString(laikas);
            }
            else if (comboBox4.Text == "Vidutinis")
            {
                textBox12.Text = "Reakcija 4h";
                time = time.AddHours(4);
                textBox5.Text = time.ToString(data);
                textBox6.Text = time.ToString(laikas);
            }
            else if (comboBox4.Text == "Aukštas")
            {
                textBox12.Text = "Reakcija 2h";
                time = time.AddHours(2);
                textBox5.Text = time.ToString(data);
                textBox6.Text = time.ToString(laikas);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_Format(object sender, ListControlConvertEventArgs e)
        {
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            if (comboBox10.Text == "Darbo ID")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAK_NR LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Parduotuvės pavadinimas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND PARD_PAV LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Parduotuvės adresas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND PARD_ADRESAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Incidento aprašas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_APRASAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Užsakovas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_KONTAKTAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Kontaktas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_TEL LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "El. paštas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_PASTAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Prioritetas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_PRIORITETAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Būsena")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_BUSENA LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Tipas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_TIPAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Reakcijos data")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_REAKDATA LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Reakcijos laikas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_REAKLAIKAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Sprendėjas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_SPREND LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Kūrėjas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_KUREJAS LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "Incidento data")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS AND UZSAKYMO_DATA LIKE '" + textBox8.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox10.Text == "<Nepasirinkta>")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            con.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView3.DataSource = dt;
            dataGridView3.AutoResizeColumns();
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.Columns[0].HeaderCell.Value = "Pardavimo numeris";
            dataGridView3.Columns[1].HeaderCell.Value = "Parduotuvės numeris";
            dataGridView3.Columns[2].HeaderCell.Value = "Parduotos įrangos ID";
            dataGridView3.Columns[3].HeaderCell.Value = "Įrangos aprašymas";
            dataGridView3.Columns[4].HeaderCell.Value = "Įrangos S/N";
            dataGridView3.Columns[5].HeaderCell.Value = "Kaina";
            dataGridView3.Columns[6].HeaderCell.Value = "Įrangos grupė";
            dataGridView3.Columns[7].HeaderCell.Value = "Data";
            dataGridView3.Columns[8].HeaderCell.Value = "Laikas";
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // this.Hide();

            Form2 ss = new Form2();
            ss.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
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

        public void fillcombobox3()
        {
            con.Open();

            try
            {
                string imone = "select * from IRANGA";
                SqlDataAdapter SDA = new SqlDataAdapter(imone, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                comboBox3.ValueMember = "IRANGOS_NR";
                comboBox3.DisplayMember = "IRANGOS_NR";
                comboBox3.DataSource = dt;
                comboBox3.Width = comboBox1.Items[comboBox1.SelectedIndex].ToString().Length * 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void fillcombobox7()
        {
            con.Open();
            try
            {
                string darbuotojai = "select DARB_PAV from DARBUOTOJAS, Logins WHERE Logins.DARB_ID = DARBUOTOJAS.DARB_ID AND Logins.username = @username";
                SqlDataAdapter SDA = new SqlDataAdapter(darbuotojai, con);
                SDA.SelectCommand.Parameters.AddWithValue("@username", textBox11.Text);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                comboBox7.ValueMember = "DARB_ID";
                comboBox7.DisplayMember = "DARB_PAV";
                comboBox7.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void pardadresas()
        {
            string pard = "select * from PARDUOTUVE where PARD_PAV = '" + comboBox2.Text + "';";
            SqlCommand SDA = new SqlCommand(pard, con);
            SqlDataReader reader;
            con.Close();
            try
            {
                con.Open();

                reader = SDA.ExecuteReader();
                while (reader.Read())
                {
                    string miest = reader.GetString(5);
                    string adrs = reader.GetString(6);
                    textBox7.Text = adrs + " ," + miest;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            comboBox3.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ar tikrai norite ištrinti?", "Trinimas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                string query = "DELETE FROM UZSAKYMAS2 WHERE UZSAK_NR='" + textBox13.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("IŠTRINTA");
                rodytiuzsakymus();
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void rodytiuzsakymus()
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT UZSAK_NR, PARD_PAV, PARD_ADRESAS, UZSAKYMO_APRASAS, UZSAKYMO_KONTAKTAS, UZSAKYMO_TEL, UZSAKYMO_PASTAS, UZSAKYMO_PRIORITETAS, UZSAKYMO_BUSENA, UZSAKYMO_TIPAS, UZSAKYMO_REAKDATA, UZSAKYMO_REAKLAIKAS, UZSAKYMO_SPREND, UZSAKYMO_KUREJAS, UZSAKYMO_DATA FROM UZSAKYMAS2, PARDUOTUVE WHERE UZSAKYMAS2.PARD_KODAS = PARDUOTUVE.PARD_KODAS", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[0].HeaderCell.Value = "Darbo ID";
            dataGridView1.Columns[1].HeaderCell.Value = "Parduotuvės pavadinimas";
            dataGridView1.Columns[2].HeaderCell.Value = "Parduotuvės adresas";
            dataGridView1.Columns[3].HeaderCell.Value = "Užsakymo aprašas";
            dataGridView1.Columns[4].HeaderCell.Value = "Užsakovas";
            dataGridView1.Columns[5].HeaderCell.Value = "Kontaktas";
            dataGridView1.Columns[6].HeaderCell.Value = "El. paštas";
            dataGridView1.Columns[7].HeaderCell.Value = "Prioritetas";
            dataGridView1.Columns[8].HeaderCell.Value = "Būsena";
            dataGridView1.Columns[9].HeaderCell.Value = "Tipas";
            dataGridView1.Columns[10].HeaderCell.Value = "Reakcijos data";
            dataGridView1.Columns[11].HeaderCell.Value = "Reakcijos laikas";
            dataGridView1.Columns[12].HeaderCell.Value = "Sprendėjas";
            dataGridView1.Columns[13].HeaderCell.Value = "Kūrėjas";
            dataGridView1.Columns[14].HeaderCell.Value = "Užsakymo data";
            con.Close();
        }

        private void Rodyti_Click(object sender, EventArgs e)
        {
            {
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
                dataGridView4.AutoResizeColumns();
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.Columns[0].HeaderCell.Value = "Baigto incidento numeris";
                dataGridView4.Columns[1].HeaderCell.Value = "Buvusio incidento numeris";
                dataGridView4.Columns[2].HeaderCell.Value = "Aprašymas";
                dataGridView4.Columns[3].HeaderCell.Value = "Sprendėjas";
                dataGridView4.Columns[4].HeaderCell.Value = "Baigimo data";
                dataGridView4.Columns[5].HeaderCell.Value = "Baigimo laikas";
                con.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_KODAS, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView5.DataSource = dt;
            dataGridView5.AutoResizeColumns();
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.Columns[0].HeaderCell.Value = "Imones pavadinimas";
            dataGridView5.Columns[1].HeaderCell.Value = "Parduotuves kodas";
            dataGridView5.Columns[2].HeaderCell.Value = "Parduotuves pavadinimas";
            dataGridView5.Columns[3].HeaderCell.Value = "Teritorija";
            dataGridView5.Columns[4].HeaderCell.Value = "Miestas";
            dataGridView5.Columns[5].HeaderCell.Value = "Adresas";
            dataGridView5.Columns[6].HeaderCell.Value = "Paštas";
            con.Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            if (comboBox12.Text == "Įmonė")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND IMONES_PAV LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            else if (comboBox12.Text == "Parduotuvės kodas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND PARD_KODAS LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            else if (comboBox12.Text == "Parduotuvės pavadinimas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND PARD_PAV LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            else if (comboBox12.Text == "Teritorija")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND PARD_TERITORIJA LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            else if (comboBox12.Text == "Miestas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND PARD_MIESTAS LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            else if (comboBox12.Text == "Adresas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND PARD_ADRESAS LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            else if (comboBox12.Text == "Paštas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT IMONES_PAV, PARD_PAV, PARD_TERITORIJA, PARD_MIESTAS, PARD_ADRESAS, PARD_PASTAS FROM Parduotuve, Imone WHERE Parduotuve.IMONES_ID = Imone.IMONES_ID AND PARD_PASTAS LIKE '" + textBox15.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            con.Close();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            if (comboBox13.Text == "Baigto incidento numeris")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak WHERE BAIGTI_NR LIKE '" + textBox16.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            else if (comboBox13.Text == "Buvusio incidento numeris")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak WHERE UZSAKYMAS_NR LIKE '" + textBox16.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            else if (comboBox13.Text == "Baigimo aprašymas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak WHERE BAIGTI_APR LIKE '" + textBox16.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            else if (comboBox13.Text == "Sprendėjas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak WHERE BAIGTI_SPREND LIKE '" + textBox16.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            else if (comboBox13.Text == "Data")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak WHERE BAIGTI_DATA LIKE '" + textBox16.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            else if (comboBox13.Text == "Laikas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM BaigUzsak WHERE BAIGTI_LAIKAS LIKE '" + textBox16.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Naujapard parde = new Naujapard();
            parde.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM IMONE", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView6.DataSource = dt;
            dataGridView6.AutoResizeColumns();
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView6.Columns[0].HeaderCell.Value = "Imonės ID";
            dataGridView6.Columns[1].HeaderCell.Value = "Įmonės pavadinimas";
            dataGridView6.Columns[2].HeaderCell.Value = "Imonės PVM";
            dataGridView6.Columns[3].HeaderCell.Value = "Įmonės paštas";
            dataGridView6.Columns[4].HeaderCell.Value = "Įmonės adresas";
            con.Close();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text == "Įmonės ID")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM IMONE WHERE IMONES_ID LIKE '" + textBox14.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            else if (comboBox14.Text == "Įmonės pavadinimas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM IMONE WHERE IMONES_PAV LIKE '" + textBox14.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            else if (comboBox14.Text == "Įmonės PVM")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM IMONE WHERE IMONES_PVM LIKE '" + textBox14.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            else if (comboBox14.Text == "Įmonės paštas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM IMONE WHERE IMONES_PASTAS LIKE '" + textBox14.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            else if (comboBox14.Text == "Įmonės adresas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM IMONE WHERE IMONES_ADRESAS LIKE '" + textBox14.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView6.DataSource = dt;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            naujaimone naujaimone = new naujaimone();
            naujaimone.Show();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                pard1 = row.Cells[0].Value.ToString();
                pard2 = row.Cells[1].Value.ToString();
                pard3 = row.Cells[2].Value.ToString();
                pard4 = row.Cells[3].Value.ToString();
                pard5 = row.Cells[4].Value.ToString();
                pard6 = row.Cells[5].Value.ToString();
                pard7 = row.Cells[5].Value.ToString();
            }
            parduotuveupdate pardup = new parduotuveupdate();
            pardup.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox17.Text))
            {
                MessageBox.Show("Nepasirinktas parduotuvės kodas");
            }
            else
            {
                if (MessageBox.Show("Ar tikrai norite ištrinti?", "Trinimas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    string query = "DELETE FROM PARDUOTUVE WHERE PARD_KODAS ='" + textBox17.Text + "'";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("IŠTRINTA");
                    rodytiuzsakymus();
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "Pardavimo numeris")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARD_ID LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Parduotuvės numeris")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARD_KODAS LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Parduotos įrangos ID")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARDIRANG_ID LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Įrangos aprašymas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARDIRANG_APR LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Įrangos S/N")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARDIRANG_SN LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Kaina")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARD_KAINA LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Įrangos grupė")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARDIRANG_GR LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Data")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARD_DATA LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if (comboBox11.Text == "Laikas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM PARDAVIMAI WHERE PARD_LAIKAS LIKE '" + textBox10.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView3.DataSource = dt;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            {
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
                dataGridView7.AutoResizeColumns();
                dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView7.Columns[0].HeaderCell.Value = "Darbuotojo ID";
                dataGridView7.Columns[1].HeaderCell.Value = "Darbuotojo vardas";
                dataGridView7.Columns[2].HeaderCell.Value = "Darbo teritorija";
                dataGridView7.Columns[3].HeaderCell.Value = "Darbo miestas";
                dataGridView7.Columns[4].HeaderCell.Value = "Telefonas";
                dataGridView7.Columns[5].HeaderCell.Value = "El.paštas";
                con.Close();
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (comboBox15.Text == "Darbuotojo ID")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS WHERE DARB_ID LIKE '" + textBox18.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
            }
            else if (comboBox15.Text == "Darbuotojo vardas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS WHERE DARB_PAV LIKE '" + textBox18.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
            }
            else if (comboBox15.Text == "Darbo teritorija")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS WHERE DARB_TERITORIJA LIKE '" + textBox18.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
            }
            else if (comboBox15.Text == "Darbo miestas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS WHERE DARB_PADALINYS LIKE '" + textBox18.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
            }
            else if (comboBox15.Text == "Telefonas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS WHERE DARB_TEL LIKE '" + textBox18.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
            }
            else if (comboBox15.Text == "El.paštas")
            {
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM DARBUOTOJAS WHERE DARB_PASTAS LIKE '" + textBox18.Text + "%'", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView7.DataSource = dt;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            naujasdarb naujasdarb = new naujasdarb();
            naujasdarb.Show();
        }

        private void dataGridView6_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView6.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                imon5 = row.Cells[0].Value.ToString();
                imon1 = row.Cells[1].Value.ToString();
                imon2 = row.Cells[2].Value.ToString();
                imon3 = row.Cells[3].Value.ToString();
                imon4 = row.Cells[4].Value.ToString();
            }
            imoneUpdate imonup = new imoneUpdate();
            imonup.Show();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               // gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
               // populate the textbox from specific value of the coordinates of column and row.
                irang1 = row.Cells[3].Value.ToString();
                irang2 = row.Cells[4].Value.ToString();
                irang3 = row.Cells[5].Value.ToString();
                irang4 = row.Cells[8].Value.ToString();
                irang5 = row.Cells[9].Value.ToString();
                irang6 = row.Cells[10].Value.ToString();
                irang7 = row.Cells[11].Value.ToString();
                irang8 = row.Cells[13].Value.ToString();
            }
            irangaupdate irangaup = new irangaupdate();
            irangaup.Show();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView7_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                darb1 = row.Cells[0].Value.ToString();
                darb2 = row.Cells[1].Value.ToString();
                darb3 = row.Cells[2].Value.ToString();
                darb4 = row.Cells[3].Value.ToString();
                darb5 = row.Cells[4].Value.ToString();
                darb6 = row.Cells[5].Value.ToString();
            }
            darbuotojasUPDATE darbup = new darbuotojasUPDATE();
            darbup.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ar tikrai norite ištrinti?", "Trinimas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                string query = "DELETE FROM IMONE WHERE IMONES_ID ='" + textBox19.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("IŠTRINTA");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ar tikrai norite ištrinti?", "Trinimas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                string query = "DELETE FROM DARBUOTOJAS WHERE DARB_ID ='" + textBox20.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("IŠTRINTA");
                rodytiuzsakymus();
            }
        }
    }
}