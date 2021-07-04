using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using _LINQ_QuanLy_QuanTraSua;
using System.Threading;

namespace _LINQ_QuanLy_QuanTraSua.BSLayer
{
    class BLAccount_NV
    {

        public List<NV> ListNV()
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var tpQuery = (from NV in qLQTS.NVs.AsEnumerable()
                               select NV)
                              .Select(x => new NV
                              {
                                  MaNV = x.MaNV,
                                  TenNV = x.TenNV,
                                  ChucVu = x.ChucVu,
                                  SDT = x.SDT,
                                  DiaChi = x.DiaChi,
                                  Luong = x.Luong
                              }).ToList();

                return tpQuery;
            }
        }



        public bool ThemNV(string MaNV, string TenNV, string ChucVu, string SDT, string DiaChi, int Luong, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            NV NV = new NV();
            NV.MaNV = MaNV;
            NV.TenNV = TenNV;
            NV.ChucVu = ChucVu;
            NV.SDT = SDT;
            NV.DiaChi = DiaChi;
            NV.Luong = Luong;

            qLQTS.NVs.InsertOnSubmit(NV);
            qLQTS.NVs.Context.SubmitChanges();
            return true;
        }





        public bool XoaNV(ref string err, string MaNV)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = from NV in qLQTS.NVs
                          where NV.MaNV == MaNV
                          select NV;

            qLQTS.NVs.DeleteAllOnSubmit(tpQuery);
            qLQTS.SubmitChanges();
            return true;
        }

        public bool CapNhatNV(string MaNV, string TenNV, string ChucVu, string SDT, string DiaChi, int Luong, ref string err)
        {
            QLQTSDataContext qLQTS = new QLQTSDataContext();
            var tpQuery = (from NV in qLQTS.NVs
                           where NV.MaNV == MaNV
                           select NV).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TenNV = TenNV;
                tpQuery.ChucVu = ChucVu;
                tpQuery.SDT = SDT;
                tpQuery.DiaChi = DiaChi;
                tpQuery.Luong = Luong;
                qLQTS.SubmitChanges();
            }
            return true;
        }

        public List<NV> TimNV(string SearchTenNV, string SearchChucVu, string SearchSDT, string SearchDiaChi, ref string err)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext()) {
                var tpQuery = (from NV in qLQTS.NVs.AsEnumerable()
                               where NV.TenNV.Contains(SearchTenNV)
                                     && NV.ChucVu.Contains(SearchChucVu)
                                     && NV.SDT.Contains(SearchSDT)
                                     && NV.DiaChi.Contains(SearchDiaChi)
                               select NV)
                              .Select(x => new NV
                              {
                                  MaNV = x.MaNV,
                                  TenNV = x.TenNV,
                                  ChucVu = x.ChucVu,
                                  SDT = x.SDT,
                                  DiaChi = x.DiaChi,
                                  Luong = x.Luong
                              }).ToList(); 
                              
            return tpQuery;
            }
        }







        public List<TAIKHOANNV> LayMaNV(string UserName)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext()) 
            {
                var tpQuery = (from NV in qLQTS.TAIKHOANNVs
                               where NV.UserName == UserName
                               select NV).ToList();
            return tpQuery;
            }
        }

        public static bool checkANV(string UserName, string Pass)
        {
            using (QLQTSDataContext qLQTS = new QLQTSDataContext())
            {
                var nvQuery = from NV in qLQTS.TAIKHOANNVs
                              where NV.UserName == UserName && NV.Pass == Pass
                              select NV;
                if (nvQuery.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




    }
}
