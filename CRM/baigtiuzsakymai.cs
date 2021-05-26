using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace CRM
{
    public partial class baigtiuzsakymai : Form
    {
        public baigtiuzsakymai()
        {
            string daataa;
            string laaaikas;
            DateTime time = DateTime.Now;
            InitializeComponent();
            textBox1.Text = Main.uzsakyymas;
            textBox2.Text = Main.dd;
            daataa = Main.data2;
            laaaikas = Main.laikas2;
            textBox3.Text = time.ToString(daataa);
            textBox4.Text = time.ToString(laaaikas);
            richTextBox2.Text = Main.aprasymas;
            textBox6.Text = darbvardas;
            textBox7.Text = darbtel;
            textBox8.Text = darbel;
            textBox9.Text = Main.sprendejas;
            textBox10.Text = Main.reakdata;
            textBox11.Text = Main.reaklaikas;
            textBox12.Text = Main.tipas;
            textBox13.Text = Main.uzsakyymas;
           
        }

        private string parduotuvepav = Main.pardpav.ToString();
        private string parduotuveadr = Main.pardadr.ToString();
        private string darbvardas = Main.vardas.ToString();
        private string darbtel = Main.telefonas.ToString();
        private string darbel = Main.elpastas.ToString();
        private string irangaaa = Main.irangaaa.ToString();
        private SqlConnection con = new SqlConnection ("Data Source=bakaluras.database.windows.net;Initial Catalog=Kestutis;User ID=bakalauras;Password=ZymPuv609*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Įveskite sprendimą");
            }
            else
            {
                con.Open();
                string query = "INSERT INTO BaigUzsak (UZSAKYMAS_NR, BAIGTI_APR, BAIGTI_SPREND, BAIGTI_DATA, BAIGTI_LAIKAS) VALUES" + " ('" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "') ";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uždaryta");
                this.Hide();
                UpdateFunkcija();
            }
        }

        public void UpdateFunkcija()
        {
           // Ataskaita();
            textBox5.Text = "Baigta";
            con.Open();
            string query = "UPDATE UZSAKYMAS2 SET UZSAKYMO_BUSENA='" + textBox5.Text + "' WHERE UZSAK_NR='" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ataskaita();
            Email();
        }

        private void Ataskaita()
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Ataskaita.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Image JPG = iTextSharp.text.Image.GetInstance("preview.jpg");
            JPG.ScaleToFit(250f, 250f);
            JPG.Alignment = Element.ALIGN_CENTER;
            doc.Add(JPG);
            // Paragraph paragraph = new Paragraph("Testuojama " + richTextBox1.Text + "");
            PdfPTable table = new PdfPTable(2);
            table.AddCell("Užsakymo numeris");
            table.AddCell(textBox1.Text);
            table.AddCell("Parduotuve");
            table.AddCell(parduotuvepav);
            table.AddCell("Parduotuves adresas");
            table.AddCell(parduotuveadr);
            table.AddCell("Kliento kontaktiniai duomenys");
            table.AddCell(darbvardas + ", " + darbtel + ", " + darbel);
            table.AddCell("Irangos pavadinimas");
            table.AddCell(irangaaa);
            table.AddCell("Atlikti darbai");
            table.AddCell(richTextBox1.Text);
            table.AddCell("Darbuotojas");
            table.AddCell(textBox2.Text);
            table.AddCell("Data");
            table.AddCell(textBox3.Text + " " + textBox4.Text);
            doc.Add(table);
            //doc.Add(paragraph);
            doc.Close();
        }

        private void Email()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("bakalaurodarbas123@gmail.com");
                mail.To.Add(darbel);
                mail.Subject = "Darbų ataskaita";
                mail.Body = "Sveiki, atsiunčiama Jums atliktų darbų ataskaita";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("C:/Users/Zyma/source/repos/CRM/CRM/bin/Debug/Ataskaita.pdf");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("bakalaurodarbas123", "Bakalauras123*");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Laiškas išsiųstas!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (String.IsNullOrEmpty(richTextBox2.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox10.Text) || String.IsNullOrEmpty(textBox11.Text) || String.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Negali būti tuščių langų");
            }
            else
            {
                string query = "UPDATE UZSAKYMAS2 SET UZSAKYMO_APRASAS = '" + richTextBox2.Text + "', UZSAKYMO_KONTAKTAS = '" + textBox6.Text + "', UZSAKYMO_TEL = '" + textBox7.Text + "', UZSAKYMO_PASTAS = '" + textBox8.Text + "', UZSAKymo_SPREND = '" + textBox9.Text + "', UZSAKYMO_REAKDATA = '" + textBox10.Text + "', UZSAKYMO_REAKLAIKAS = '" + textBox11.Text + "', UZSAKYMO_TIPAS = '" + textBox12.Text + "' WHERE UZSAK_NR = '" + textBox13.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Įrašas atnaujintas");
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ataskaita();
            Ataskaita ats = new Ataskaita();
            ats.Show();
        }

 
    }
}