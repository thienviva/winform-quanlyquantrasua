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
using System.Data.Linq;
using System.Windows.Documents;

namespace _LINQ_QuanLy_QuanTraSua
{
    public partial class Form_Menu : Form
    {
        private Form_Login frm_Login;
        private Form_SuaThongTin frm_Sua;
        private Form_HoaDon frm_HoaDon;
        public string MAKH;

        //DataTable dtMenu = null;
        //DataTable dtKH = null;
        QLQTSDataContext qLQTS = new QLQTSDataContext();

        BLAccount_KH dbKH = new BLAccount_KH();
        BLAccount_NV dbNV = new BLAccount_NV();
        BLMENU_HoaDon dbMN_HD = new BLMENU_HoaDon();

        string err;

        public Form_Menu()
        {
            InitializeComponent();
        }

        public void getForm(Form_Login frmLogin, string MaKH)
        {
            this.frm_Login = frmLogin;
            MAKH = MaKH;
        }

        void LoadData()
        {
            try
            {
                
                if (MAKH != "KH00")
                {   
                    MAKH = frm_Login.MAKH;   
                    txtHoTen.Text = dbKH.LayKH(MAKH)[0].TenKH;
                    txtRank.Text = dbKH.LayKH(MAKH)[0].RankKH.ToString();
                }

                //Tạo list view hóa đơn
                livHoaDon.Clear();
                livHoaDon.View = View.Details;
                livHoaDon.Columns.Add("Tên món", 140);
                livHoaDon.Columns.Add("SL", 30);
                livHoaDon.Columns.Add("Giá", 45);
                livHoaDon.GridLines = true;
                livHoaDon.FullRowSelect = true;

                txtTong.Text = "0";

                // Đưa dữ liệu lên DataGridView
                dgvMenu.DataSource = dbMN_HD.ListMENU();
                // Thay đổi độ rộng cột
                dgvMenu.AutoResizeColumns();

                //set tên Menu
                dgvMenu.Columns[0].HeaderText = "Mã Món";
                dgvMenu.Columns[1].HeaderText = "Tên Món Ăn";
                dgvMenu.Columns[2].HeaderText = "Giá";
                //set độ rộng Menu
                dgvMenu.Columns[0].Width = 50;
                dgvMenu.Columns[1].Width = 250;
                dgvMenu.Columns[2].Width = 60;

                DgvMenu_CellClick(null, null);

                
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG. Lỗi rồi!!!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (livHoaDon.SelectedItems.Count > 0) {
                //tính sl món ăn cùng loại bị xóa
                int sl = int.Parse(livHoaDon.Items[livHoaDon.SelectedIndices[0]].SubItems[1].Text);
                //lấy giá của món ăn
                int gia = int.Parse(livHoaDon.Items[livHoaDon.SelectedIndices[0]].SubItems[2].Text);
                //tính tổng tiền
                int tong = int.Parse(txtTong.Text) - sl * gia;
                txtTong.Text = tong.ToString();
                //xóa món ăn
                livHoaDon.Items.RemoveAt(livHoaDon.SelectedIndices[0]);
            }
            else MessageBox.Show("Hãy chọn món cần xóa!");

        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            LoadData();

            string mahd = "HD";
            DateTime now = DateTime.Now;
            int count = dbMN_HD.ListHD().Count() + 1;
            if (count < 10)
            {
                mahd = mahd + "0" + count.ToString();
            }
            else
            {
                mahd += count.ToString();
            }
            dbMN_HD.ThemHoaDon(mahd, MAKH, int.Parse(txtTong.Text), now, ref err);
            for (int i = 0; i < livHoaDon.Items.Count; i++)
            {
                dbMN_HD.ThemCTHoaDon(mahd, dbMN_HD.LayMon(livHoaDon.Items[i].SubItems[0].Text)[0].MaMon, livHoaDon.Items[i].SubItems[0].Text , int.Parse(livHoaDon.Items[i].SubItems[1].Text), ref err);
            }


            if (MAKH != "KH00")
            {
                MAKH = dbKH.LayAKH_MaKH(frm_Login.MAKH)[0].MaKH;

                int tongchi = dbKH.LayKH(MAKH)[0].TongChiTieu;
                int tong = tongchi + int.Parse(txtTong.Text);
                dbKH.CapNhatTien(MAKH, tong, ref err);
                int rank = tong / 1000000;
                if (rank != dbKH.LayKH(MAKH)[0].RankKH)
                {
                    dbKH.CapNhatRank(MAKH, rank, ref err);
                }
                txtRank.Text = dbKH.LayKH(MAKH)[0].RankKH.ToString();

                int khuyenmai = dbKH.LayKH(MAKH)[0].KhuyenMai;
                if (khuyenmai < 50)
                {
                    int km = rank * 5;
                    dbKH.CapNhatKM(MAKH, km, ref err);
                }
            }
            
            MessageBox.Show("Đã thanh toán! Cảm ơn quý khách <3");

            frm_HoaDon = new Form_HoaDon();
            
            frm_HoaDon.Show();
            this.Hide();

        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            frm_Sua = new Form_SuaThongTin();
            frm_Sua.getForm(this, MAKH);
            frm_Sua.Show();
            this.Hide();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            int i = 0;
            //thêm item
            ListViewItem item = new ListViewItem();
            item.Text = txtTenMon.Text;
            item.SubItems.Add(nuSoluong.Value.ToString());
            item.SubItems.Add(dbMN_HD.LayMon(txtTenMon.Text)[0].Gia.ToString());
            livHoaDon.Items.Add(item);

            //tính tổng tiền
            int tong = int.Parse(txtTong.Text) + dbMN_HD.LayMon(txtTenMon.Text)[0].Gia * int.Parse(nuSoluong.Value.ToString());
            txtTong.Text = tong.ToString();
        }

        private void DgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvMenu.CurrentCell.RowIndex;
            txtTenMon.Text = dgvMenu.Rows[r].Cells[1].Value.ToString();
            nuSoluong.Value = 1;
        }

        private void Form_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login.Show();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            LoadData();
            if (MAKH == "KH00") btnChange.Enabled = false;
        }
    }
}
