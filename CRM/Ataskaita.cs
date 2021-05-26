using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    public partial class Ataskaita : Form
    {
        public Ataskaita()
        {
            InitializeComponent();
        }

        private void Ataskaita_Load(object sender, EventArgs e)
        {
                axAcroPDF1.src = "C:/Users/Zyma/source/repos/CRM/CRM/bin/Debug/Ataskaita.pdf";
        }
    }
}
