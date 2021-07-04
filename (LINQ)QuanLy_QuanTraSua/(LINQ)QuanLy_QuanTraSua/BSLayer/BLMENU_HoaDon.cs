using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using _LINQ_QuanLy_QuanTraSua;
using System.Windows.Forms;
using System.Xml.Serialization.Configuration;
using _LINQ_QuanLy_QuanTraSua.QLQTS_HDTableAdapters;

namespace _LINQ_QuanLy_QuanTraSua.BSLayer
{
    class BLMENU_HoaDon
    {
        public List<MENU> ListMENU()
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from MN in qLQTS.MENUs.AsEnumerable()
                               select MN)
                              .Select(x => new MENU
                              {
                                  MaMon = x.MaMon,
                                  TenMon = x.TenMon,
                                  Gia = x.Gia
                              }).ToList();

                return tpQuery;
            }
        }

        public List<HOADON> ListHD()
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from HD in qLQTS.HOADONs.AsEnumerable()
                               select HD)
                              .Select(x => new HOADON
                              {
                                  MaHD = x.MaHD,
                                  MaKH = x.MaKH,
                                  TongChiPhi = x.TongChiPhi,
                                  NgayInHD = x.NgayInHD
                              }).ToList();

                return tpQuery;
            }
        }

        public List<CHITIETHD> ListCTHD()
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from HD in qLQTS.CHITIETHDs.AsEnumerable()
                               select HD)
                              .Select(x => new CHITIETHD
                              {
                                  MaHD = x.MaHD,
                                  MaMon = x.MaMon,
                                  SoLuongMon = x.SoLuongMon
                              }).ToList();

                return tpQuery;
            }
        }


        public List<MENU> LayMon(string tenmon)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from MN in qLQTS.MENUs
                               where MN.TenMon == tenmon
                               select MN).ToList();
                return tpQuery;
            }
        }

        public bool ThemMonAn(string MaMon, string TenMon, int Gia, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            MENU MN = new MENU();
            MN.MaMon = MaMon;
            MN.TenMon = TenMon;
            MN.Gia = Gia;

            qLQTS.MENUs.InsertOnSubmit(MN);
            qLQTS.MENUs.Context.SubmitChanges();
            return true;
        }

        public bool XoaMonAn(ref string err, string MaMon)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = from MN in qLQTS.MENUs
                          where MN.MaMon == MaMon
                          select MN;

            qLQTS.MENUs.DeleteAllOnSubmit(tpQuery);
            qLQTS.SubmitChanges();
            return true;
        }

        public bool CapNhatMonAn(string MaMon, string TenMon, int Gia, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from MN in qLQTS.MENUs
                           where MN.MaMon == MaMon
                           select MN).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TenMon = TenMon;
                tpQuery.Gia = Gia;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        public List<MENU> TimMN(string SearchMaMon, string SearchTenMon, ref string err)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from MN in qLQTS.MENUs.AsEnumerable()
                               where MN.MaMon.Contains(SearchMaMon)
                                     && MN.TenMon.Contains(SearchTenMon)
                               select MN)
                              .Select(x => new MENU
                              {
                                  MaMon = x.MaMon,
                                  TenMon = x.TenMon,
                                  Gia = x.Gia

                              }).ToList();

                return tpQuery;
            }
        }

        public List<MENU> TimMN_Gia(int SearchGia, ref string err)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from MN in qLQTS.MENUs.AsEnumerable()
                               where MN.Gia == SearchGia
                               select MN)
                              .Select(x => new MENU
                              {
                                  MaMon = x.MaMon,
                                  TenMon = x.TenMon,
                                  Gia = x.Gia

                              }).ToList();

                return tpQuery;
            }
        }

        public bool ThemHoaDon(string MaHD, string MAKH, int TongChiPhi, DateTime Ngay, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            HOADON HD = new HOADON();
            HD.MaHD = MaHD;
            HD.MaKH = MAKH;
            HD.TongChiPhi = TongChiPhi;
            HD.NgayInHD = Ngay;

            qLQTS.HOADONs.InsertOnSubmit(HD);
            qLQTS.HOADONs.Context.SubmitChanges();
            return true;
        }

        public bool ThemCTHoaDon(string MaHD, string MaMon,string TenMon, int SoLuongMon, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            CHITIETHD HD = new CHITIETHD();
            HD.MaHD = MaHD;
            HD.MaMon = MaMon;
            HD.TenMon = TenMon;
            HD.SoLuongMon = SoLuongMon;

            qLQTS.CHITIETHDs.InsertOnSubmit(HD);
            qLQTS.CHITIETHDs.Context.SubmitChanges();
            return true;
        }

        
    }
}
