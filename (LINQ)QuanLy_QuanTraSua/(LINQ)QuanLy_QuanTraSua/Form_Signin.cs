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
    public partial class Form_Signin : Form
    {
        private string MAKH;
        private Form_Login frm_Login;

        //DataTable dtKH = null;
        BLAccount_NV dbANV = new BLAccount_NV();
        BLAccount_KH dbAKH = new BLAccount_KH();
        BLMENU_HoaDon dbMN_HD = new BLMENU_HoaDon();

        string err;
        public Form_Signin()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {


                this.txtUserName.ResetText();
                this.txtPassword.ResetText();

                //Tạo tự động mã khách hàng
                int i = dbAKH.LayAKH().Count;
                if (i < 10)
                {
                    MAKH = "KH0" + i.ToString();
                }
                else
                {
                    MAKH = "KH" + i.ToString();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }

        public void getForm(Form_Login frmLogin)
        {
            this.frm_Login = frmLogin;
        }

        private void BtnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                BLAccount_KH bLAccount_KH = new BLAccount_KH();
                bLAccount_KH.ThemKH(MAKH, txtHoTen.Text, txtSDT.Text, txtDiaChi.Text, ref err);
                bLAccount_KH.ThemAKH(txtUserName.Text, txtPassword.Text, MAKH, ref err);
                // Thông báo
                MessageBox.Show("Đã tạo tài khoản xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }

        private void Form_Signin_Load(object sender, EventArgs e)
        {
            LoadData();
            txtUserName.Focus();
        }

        private void Form_Signin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login.Show();
        }
    }
}
