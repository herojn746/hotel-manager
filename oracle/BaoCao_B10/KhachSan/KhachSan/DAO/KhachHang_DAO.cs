using KhachSan.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DAO
{
    public class KhachHang_DAO : dataProvider
    {
        public static List<KhachHang_DTO> getKhachHang()
        {
            OracleDataReader reader = get_KhachHang(DN.url + DN.User + "; PASSWORD = " + DN.pass);
            if (reader != null)
            {
                List<KhachHang_DTO> list = new List<KhachHang_DTO>();
                while (reader.Read())
                {
                    KhachHang_DTO khach = new KhachHang_DTO();
                    khach.setMaKH(reader.GetString(0));
                    khach.setTenKH(reader.GetString(1));
                    khach.setSDT(reader.GetString(2));
                    khach.setCMND(reader.GetString(3));
                    khach.setGioiTinh(reader.GetString(4));

                    list.Add(khach);
                }

                CloseConnection();
                reader.Close();
                return list;
            }

            return null;
        }

        public static bool add_new_khachHang(string maKH, string tenKH, string sdt, string cmnd, string gioiTinh)
        {
            bool result = add_KH(maKH, tenKH, sdt, cmnd, gioiTinh, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }


        public static bool suaKH(string maKh, string hoTen, string sdt, string cmnd, string gioiTinh)
        {
            if (suaKhachHang(maKh, hoTen, sdt, cmnd, gioiTinh, DN.url + DN.User + "; PASSWORD = " + DN.pass))
                return true;
            return false;
        }


        public static bool xoaKH(string maKH)
        {
            if (xoaKhachHang(maKH, DN.url + DN.User + "; PASSWORD = " + DN.pass))
                return true;
            return false;
        }

        public static List<KhachHang_DTO> search_KhachHang(string searchTheo, string search)
        {
            bool nvarchar = searchTheo == "HoTen" ? true : false;

            string query = "";

            if (nvarchar)
            {
                query = "select * from KhachHang where " + searchTheo + " like N'%" + search + "%'";

            }
            else
            {
                query = "select * from KhachHang where " + searchTheo + " like '%" + search + "%'";
            }

            OracleDataReader reader = getResult(query, DN.url + DN.User + "; PASSWORD = " + DN.pass);

            if(reader != null)
            {
                List<KhachHang_DTO> list = new List<KhachHang_DTO>();
                
                while(reader.Read())
                {
                    KhachHang_DTO khach = new KhachHang_DTO();
                    khach.setMaKH(reader.GetString(0));
                    khach.setTenKH(reader.GetString(1));
                    khach.setSDT(reader.GetString(2));
                    khach.setCMND(reader.GetString(3));
                    khach.setGioiTinh(reader.GetString(4));

                    list.Add(khach);
                }
                CloseConnection();
                reader.Close();
                return list;
            }

            return null;
        }
    }
}
