using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LINQ_QuanLy_QuanTraSua.BSLayer;
using System.Windows.Forms;

namespace _LINQ_QuanLy_QuanTraSua
{
    public partial class Form_SuaThongTin : Form
    {
        private Form_Menu frm_Menu;
        private string MAKH;
        string err;

        BLAccount_KH dbKH = new BLAccount_KH();
        BLAccount_NV dbNV = new BLAccount_NV();
        BLMENU_HoaDon dbMN_HD = new BLMENU_HoaDon();

        public Form_SuaThongTin()
        {
            InitializeComponent();
        }

        public void getForm(Form_Menu frmMenu, string makh)
        {
            this.frm_Menu = frmMenu;
            this.MAKH = makh;
        }

        void LoadData()
        {
            try
            {

                MAKH = dbKH.LayAKH_MaKH(frm_Menu.MAKH)[0].MaKH;
                

                txtUserName.Text = dbKH.LayAKH_MaKH(frm_Menu.MAKH)[0].UserName;
                txtPassword.Text = dbKH.LayAKH_MaKH(frm_Menu.MAKH)[0].Pass;


                txtHoTen.Text = dbKH.LayKH(MAKH)[0].TenKH;
                txtSDT.Text = dbKH.LayKH(MAKH)[0].SDT;
                txtDiaChi.Text = dbKH.LayKH(MAKH)[0].DiaChi;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG và TAIKHOANKH. Lỗi rồi!!!");
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            dbKH.CapNhatAKH(txtUserName.Text, txtPassword.Text, MAKH, ref err);
            dbKH.CapNhatKH(MAKH, txtHoTen.Text, txtSDT.Text, txtDiaChi.Text, ref err);
            MessageBox.Show("Đã cập nhật!!!");
        }

        private void Form_SuaThongTin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Menu.Show();
        }

        private void Form_SuaThongTin_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
