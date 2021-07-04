using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace _LINQ_QuanLy_QuanTraSua
{
    public partial class Form_HoaDon : Form
    {
        public Form_HoaDon()
        {
            InitializeComponent();
        }

        private void Form_HoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLQTS_HD.INHD' table. You can move, or remove it, as needed.
            this.INHDTableAdapter.Fill(this.QLQTS_HD.INHD);

            this.rpvHoaDon.RefreshReport();
            this.rpvHoaDon.RefreshReport();
        }

        private void BtnSelectby_Click(object sender, EventArgs e)
        {

        }
    }
}
