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
    public partial class Form_Management : Form
    {
        private Form_Login frm_Login;
        private string MANV;


        QLQTSDataContext qLQTS = new QLQTSDataContext();

        BLAccount_NV dbNV = new BLAccount_NV();
        BLAccount_KH dbKH = new BLAccount_KH();
        BLMENU_HoaDon dbMN_HD = new BLMENU_HoaDon();

        //các biến bool
        bool Them;
        bool Sua;
        bool TimMa;
        bool TimGia;
        bool TimTen;
        bool TimChuc;
        bool TimSDT;
        bool TimDiaChi;


        string err;

        public Form_Management()
        {
            InitializeComponent();
        }

        public void getForm(Form_Login frmLogin, string MaNV)
        {
            frm_Login = frmLogin;
            MANV = MaNV;
        }

        void LoadData()
        {
            try
            {


                // Đưa dữ liệu lên DataGridView
                dgvNV.DataSource = dbNV.ListNV();

                dgvMenu.DataSource = dbMN_HD.ListMENU();

                // Thay đổi độ rộng cột
                dgvNV.AutoResizeColumns();

                dgvMenu.AutoResizeColumns();

                //set tên cột
                //Nhân viên
                dgvNV.Columns[0].HeaderText = "Mã NV";
                dgvNV.Columns[1].HeaderText = "Họ Và Tên";
                dgvNV.Columns[2].HeaderText = "Chức Vụ";
                dgvNV.Columns[3].HeaderText = "Số Điện Thoại";
                dgvNV.Columns[4].HeaderText = "Địa Chỉ";
                dgvNV.Columns[5].HeaderText = "Lương";
                //Menu
                dgvMenu.Columns[0].HeaderText = "Mã Món";
                dgvMenu.Columns[1].HeaderText = "Tên Món Ăn";
                dgvMenu.Columns[2].HeaderText = "Giá";


                //set độ rộng
                //Nhân viên
                dgvNV.Columns[0].Width = 60;
                dgvNV.Columns[1].Width = 200;
                dgvNV.Columns[2].Width = 100;
                dgvNV.Columns[3].Width = 150;
                dgvNV.Columns[4].Width = 250;
                dgvNV.Columns[5].Width = 100;
                //Menu
                dgvMenu.Columns[0].Width = 60;
                dgvMenu.Columns[1].Width = 400;
                dgvMenu.Columns[2].Width = 80;

                //
                plInfo.Enabled = false;
                plInfoM.Enabled = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NV. Lỗi rồi!!!");
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            Sua = true;
            Them = false;
            btnLuu.Enabled = true;
            plInfo.Enabled = true;
            txtLuong.Enabled = true;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                int r = dgvNV.CurrentCell.RowIndex;
                string manv = dgvNV.Rows[r].Cells[0].Value.ToString();
                dbNV.XoaNV(ref err, manv);
            }
            LoadData();
        }



        private void BtnLuu_Click(object sender, EventArgs e)
        {

            if (Them)
            {
                //tự tạo mã NV
                string manv = "NV";
                int count = dbNV.ListNV().Count() + 1;
                if (count < 10)
                {
                    manv = manv + "0" + count.ToString();
                }
                else
                {
                    manv += count.ToString();
                }

                dbNV.ThemNV(manv, txtHoTen.Text, txtChucVu.Text, txtSDT.Text, txtDiaChi.Text, int.Parse(txtLuong.Text), ref err);
            }
            else if (Sua)
            {
                int r = dgvNV.CurrentCell.RowIndex;
                string manv = dgvNV.Rows[r].Cells[0].Value.ToString();
                dbNV.CapNhatNV(manv, txtHoTen.Text, txtChucVu.Text, txtSDT.Text, txtDiaChi.Text, int.Parse(txtLuong.Text), ref err);
            }
            MessageBox.Show("Đã lưu!");
            LoadData();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<NV> listNV = dbNV.TimNV(txtHoTen.Text, txtChucVu.Text, txtSDT.Text, txtDiaChi.Text, ref err);
            // Đưa dữ liệu lên DataGridView
            dgvNV.DataSource = listNV;

            if (listNV.Count() == 0) MessageBox.Show("Không tìm thấy!");
            else
            {
                // Thay đổi độ rộng cột
                dgvNV.AutoResizeColumns();
                //reset text
                txtHoTen.ResetText();
                txtChucVu.ResetText();
                txtDiaChi.ResetText();
                txtSDT.ResetText();
                txtLuong.ResetText();
            }
        }

        private void BtnThemM_Click(object sender, EventArgs e)
        {
            Them = true;
            Sua = false;
            btnLuuM.Enabled = true;
            plInfoM.Enabled = true;
            txtGia.Enabled = true;

            //reset toàn bộ text
            txtMaMon.ResetText();
            txtTenMon.ResetText();
            txtGia.ResetText();

            //focus ô Tên NV
            txtMaMon.Focus();
        }

        private void BtnSuaM_Click(object sender, EventArgs e)
        {
            Sua = true;
            Them = false;
            btnLuuM.Enabled = true;
            plInfoM.Enabled = true;
            txtGia.Enabled = true;
        }

        private void BtnXoaM_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                int r = dgvMenu.CurrentCell.RowIndex;
                string mamon = dgvMenu.Rows[r].Cells[0].Value.ToString();
                dbMN_HD.XoaMonAn(ref err, mamon);
            }
            LoadData();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            
            plSearch.Enabled = !plSearch.Enabled;
            plInfo.Enabled = plSearch.Enabled;

            if (!plSearch.Enabled)
            {
                btnTim.BackColor = DefaultBackColor;
                btnTim.Text = "Tìm : OFF";
            }
            else
            {
                btnTim.BackColor = Color.Red;
                btnTim.Text = "Tìm : ON";
            }

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = !plSearch.Enabled;
            btnLuu.Enabled = txtLuong.Enabled = false;

            //
            radChucVu.Checked = plSearch.Enabled;
            radDiaChi.Checked = plSearch.Enabled;
            radSDT.Checked = plSearch.Enabled;
            radHoTen.Checked = plSearch.Enabled;

            //reset text
            txtHoTen.ResetText();
            txtChucVu.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtLuong.ResetText();

            //focus vào họ tên
            txtHoTen.Focus();
        }

        private void BtnTimM_Click(object sender, EventArgs e)
        {
            plSearchM.Enabled = !plSearchM.Enabled;
            plInfoM.Enabled = plSearchM.Enabled;
            if(!plSearchM.Enabled)
            {
                btnTimM.BackColor = DefaultBackColor;
                btnTimM.Text = "Tìm : OFF";
            }
            else
            {
                btnTimM.BackColor = Color.Red;
                btnTimM.Text = "Tìm : ON";
            }

            btnThemM.Enabled = btnSuaM.Enabled = btnXoaM.Enabled = !plSearchM.Enabled;
            btnLuuM.Enabled = txtGia.Enabled = false;

            //
            radTenMon.Checked = plSearchM.Enabled;
            radGia.Checked = plSearchM.Enabled;
            radMaMon.Checked = plSearchM.Enabled;

            //reset text
            txtMaMon.ResetText();
            txtTenMon.ResetText();
            txtGia.ResetText();

            //focus vào Mã món
            txtMaMon.Focus();

        }

        private void BtnLuuM_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                dbMN_HD.ThemMonAn(txtMaMon.Text, txtTenMon.Text, int.Parse(txtGia.Text), ref err);
            }
            else if (Sua)
            {
                int r = dgvMenu.CurrentCell.RowIndex;
                string mamon = dgvMenu.Rows[r].Cells[0].Value.ToString();
                dbMN_HD.CapNhatMonAn(mamon, txtTenMon.Text, int.Parse(txtGia.Text), ref err);
            }
            MessageBox.Show("Đã lưu!");
            LoadData();
        }

        private void BtnSearchM_Click(object sender, EventArgs e)
        {
            if(TimGia)
            {
                List<MENU> listMN = dbMN_HD.TimMN_Gia(int.Parse(txtMucGia.Text), ref err);

                // Đưa dữ liệu lên DataGridView
                dgvMenu.DataSource = listMN;


                if (listMN.Count() == 0) MessageBox.Show("Không tìm thấy!");
                else
                {
                    // Thay đổi độ rộng cột
                    dgvMenu.AutoResizeColumns();
                    //reset text
                    txtMaMon.ResetText();
                    txtTenMon.ResetText();
                    txtGia.ResetText();
                }
            }
            else
            {
                List<MENU> listMN = dbMN_HD.TimMN(txtMaMon.Text, txtTenMon.Text, ref err);
            
                // Đưa dữ liệu lên DataGridView
                 dgvMenu.DataSource = listMN;


                if (listMN.Count() == 0) MessageBox.Show("Không tìm thấy!");
                else
                {
                    // Thay đổi độ rộng cột
                    dgvMenu.AutoResizeColumns();
                    //reset text
                    txtMaMon.ResetText();
                    txtTenMon.ResetText();
                    txtGia.ResetText();
                } 
            }
            
        }

        private void PbReloadM_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void TrbMucGia_Scroll(object sender, EventArgs e)
        {
            txtMucGia.Text = (trbMucGia.Value * 1000).ToString();
        }

        private void RadMaMon_CheckedChanged(object sender, EventArgs e)
        {
            TimMa = true;
            TimTen = TimGia = false;

            txtMaMon.Enabled = true;
            txtTenMon.Enabled = txtGia.Enabled = !radMaMon.Checked;

            txtMaMon.Focus();
        }

        private void RadTenMon_CheckedChanged(object sender, EventArgs e)
        {
            TimTen = true;
            TimMa = TimGia = false;

            txtTenMon.Enabled = true;
            txtMaMon.Enabled = txtGia.Enabled = !radTenMon.Checked;

            txtTenMon.Focus();
        }

        private void RadGia_CheckedChanged(object sender, EventArgs e)
        {
            TimGia = true;
            TimMa = TimTen = false;

            plMucGia.Enabled = radGia.Checked;
            plInfoM.Enabled = !plMucGia.Enabled;
            trbMucGia.Value = 0;
        }

        private void Form_Management_Load(object sender, EventArgs e)
        {
            LoadData();
            plSearch.Enabled = false;
            btnLuu.Enabled = false;

            plSearchM.Enabled = false;
            btnLuuM.Enabled = false;
        }

        private void Form_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login.Show();
        }

        private void DgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvMenu.CurrentCell.RowIndex;
            txtMaMon.Text = dgvMenu.Rows[r].Cells[0].Value.ToString();
            txtTenMon.Text = dgvMenu.Rows[r].Cells[1].Value.ToString();
            txtGia.Text = dgvMenu.Rows[r].Cells[2].Value.ToString();

        }

        private void RadHoTen_CheckedChanged(object sender, EventArgs e)
        {
            TimTen = true;
            TimChuc = TimDiaChi = TimSDT = false;

            txtHoTen.Enabled = true;
            txtChucVu.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = !radHoTen.Checked;

            txtHoTen.Focus();
        }

        private void RadChucVu_CheckedChanged(object sender, EventArgs e)
        {
            TimChuc = true;
            TimTen = TimDiaChi = TimSDT = false;

            txtChucVu.Enabled = true;
            txtHoTen.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = !radChucVu.Checked;

            txtChucVu.Focus();
        }

        private void RadDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            TimDiaChi = true;
            TimChuc = TimTen = TimSDT = false;

            txtDiaChi.Enabled = true;
            txtChucVu.Enabled = txtHoTen.Enabled = txtSDT.Enabled = !radDiaChi.Checked;

            txtDiaChi.Focus();
        }

        private void RadSDT_CheckedChanged(object sender, EventArgs e)
        {
            TimSDT = true;
            TimChuc = TimDiaChi = TimTen = false;

            txtSDT.Enabled = true;
            txtChucVu.Enabled = txtDiaChi.Enabled = txtHoTen.Enabled = !radSDT.Checked;

            txtSDT.Focus();
        }

        private void PbReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void DgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvNV.CurrentCell.RowIndex;
            txtHoTen.Text = dgvNV.Rows[r].Cells[1].Value.ToString();
            txtChucVu.Text = dgvNV.Rows[r].Cells[2].Value.ToString();
            txtSDT.Text = dgvNV.Rows[r].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[r].Cells[4].Value.ToString();
            txtLuong.Text = dgvNV.Rows[r].Cells[5].Value.ToString();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            Sua = false;
            btnLuu.Enabled = true;
            plInfo.Enabled = true;
            txtLuong.Enabled = true;

            //reset toàn bộ text
            txtHoTen.ResetText();
            txtChucVu.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtLuong.ResetText();

            //focus ô Tên NV
            txtHoTen.Focus();
        }
    }
}
