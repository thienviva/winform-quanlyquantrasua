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
    public partial class Form_Login : Form
    {
        private Form_Signin frm_Signin;
        private Form_Menu frm_Menu;
        private Form_Management frm_Management;

        bool beNV;
        bool beKH;

        public string MAKH;
        public string MANV;

        QLQTSDataContext qLQTS = new QLQTSDataContext();


        BLAccount_NV dbANV = new BLAccount_NV();
        BLAccount_KH dbAKH = new BLAccount_KH();
        BLMENU_HoaDon dbMN_HD = new BLMENU_HoaDon();

        public Form_Login()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {

                if (beNV)
                {
                    // Xóa trống các đối tượng trong Panel
                    this.txtUserName.ResetText();
                    this.txtPassword.ResetText();
                    // Không cho thao tác trên các nút đăng ký
                    this.btnSignin.Enabled = false;
                }
                else if (beKH)
                {
                    // Xóa trống các đối tượng trong Panel
                    this.txtUserName.ResetText();
                    this.txtPassword.ResetText();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }

        private void BtnPass_Click(object sender, EventArgs e)
        {
            frm_Menu = new Form_Menu();
            frm_Menu.getForm(this, "KH00");
            frm_Menu.Show();
            this.Hide();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            if (beNV)
            {
                
                if (BLAccount_NV.checkANV(txtUserName.Text, txtPassword.Text) == false)
                {
                    MessageBox.Show("Tài khoản không đúng!!");
                    txtPassword.Clear();
                }
                else
                {
                    MANV = dbANV.LayMaNV(txtUserName.Text)[0].MaNV;
                    frm_Management = new Form_Management();
                    frm_Management.getForm(this, dbANV.LayMaNV(txtUserName.Text)[0].MaNV);
                    frm_Management.Show();
                    this.Hide();
                    
                }
                
            }
            else if (beKH)
            {
                
                if (BLAccount_KH.checkAKH(txtUserName.Text, txtPassword.Text) == false)
                {
                    MessageBox.Show("Tài khoản không đúng! Mời đăng kí hoặc có thể nhấn Bỏ qua!");
                    txtPassword.Clear();
                }
                else
                {
                    MAKH = dbAKH.LayMaKH(txtUserName.Text)[0].MaKH;
                    frm_Menu = new Form_Menu();
                    frm_Menu.getForm(this, dbAKH.LayMaKH(txtUserName.Text)[0].MaKH);
                    frm_Menu.Show();
                    this.Hide();
                    
                }
                
            }


        }

        private void BtnSignin_Click(object sender, EventArgs e)
        {
            frm_Signin = new Form_Signin();
            frm_Signin.getForm(this);
            frm_Signin.Show();
            this.Hide();
        }

        private void BtnKH_Click(object sender, EventArgs e)
        {
            btnSignin.Enabled = true;
            btnPass.Enabled = true;
            beKH = true;
            beNV = false;
            btnKH.BackColor = Color.Red;
            btnNV.BackColor = DefaultBackColor;
            txtUserName.ResetText();
            txtPassword.ResetText();
            txtUserName.Focus();
        }

        private void BtnNV_Click(object sender, EventArgs e)
        {
            btnSignin.Enabled = false;
            btnPass.Enabled = false;
            beNV = true;
            beKH = false;
            btnNV.BackColor = Color.Red;
            btnKH.BackColor = DefaultBackColor;
            txtUserName.ResetText();
            txtPassword.ResetText();
            txtUserName.Focus();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            LoadData();
            btnKH.PerformClick();
        }
    }
}
