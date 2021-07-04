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

namespace _LINQ_QuanLy_QuanTraSua.BSLayer
{
    class BLAccount_KH
    {

        public bool ThemAKH(string username, string password, string makh, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            TAIKHOANKH aKH = new TAIKHOANKH();
            aKH.MaKH = makh;
            aKH.UserName = username;
            aKH.Pass = password;

            qLQTS.TAIKHOANKHs.InsertOnSubmit(aKH);
            qLQTS.TAIKHOANKHs.Context.SubmitChanges();
            return true;
        }

        public bool ThemKH(string makh, string tenkh, string sdt, string diachi, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            KHACHHANG KH = new KHACHHANG();
            KH.MaKH = makh;
            KH.TenKH = tenkh;
            KH.SDT = sdt;
            KH.DiaChi = diachi;

            qLQTS.KHACHHANGs.InsertOnSubmit(KH);
            qLQTS.KHACHHANGs.Context.SubmitChanges();
            return true;
        }



        public bool CapNhatAKH(string username, string password, string makh, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from aKH in qLQTS.TAIKHOANKHs
                           where aKH.MaKH == makh
                           select aKH).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.UserName = username;
                tpQuery.Pass = password;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        public bool CapNhatKH(string makh, string tenkh, string sdt, string diachi, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from KH in qLQTS.KHACHHANGs
                           where KH.MaKH == makh
                           select KH).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TenKH = tenkh;
                tpQuery.SDT = sdt;
                tpQuery.DiaChi = diachi;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        public bool CapNhatTien(string makh, int tongchitieu, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from KH in qLQTS.KHACHHANGs
                           where KH.MaKH == makh
                           select KH).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TongChiTieu = tongchitieu;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        public bool CapNhatRank(string makh, int rank, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from KH in qLQTS.KHACHHANGs
                           where KH.MaKH == makh
                           select KH).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.RankKH = rank;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        public bool CapNhatKM(string makh, int km, ref string err)
        { 
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from KH in qLQTS.KHACHHANGs
                           where KH.MaKH == makh
                           select KH).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.KhuyenMai = km;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        

        public List<TAIKHOANKH> LayMaKH(string UserName)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
            var tpQuery = (from KH in qLQTS.TAIKHOANKHs
                          where KH.UserName == UserName
                          select KH).ToList();
            return tpQuery;
            }
        }


        public List<KHACHHANG> LayKH(string MaKH)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from KH in qLQTS.KHACHHANGs
                               where KH.MaKH == MaKH
                               select KH).ToList();

                return tpQuery;
            }
        }

        public static bool checkAKH(string UserName, string Pass)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var khQuery = from KH in qLQTS.TAIKHOANKHs
                              where KH.UserName == UserName && KH.Pass == Pass
                              select KH;
                if (khQuery.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<TAIKHOANKH> LayAKH()
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from KH in qLQTS.TAIKHOANKHs
                               select KH).ToList();
                
                return tpQuery;
            }
        }

        public List<TAIKHOANKH> LayAKH_MaKH(string MaKH)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from KH in qLQTS.TAIKHOANKHs
                               where KH.MaKH == MaKH
                               select KH).ToList();

                return tpQuery;
            }
        }





    }
}
